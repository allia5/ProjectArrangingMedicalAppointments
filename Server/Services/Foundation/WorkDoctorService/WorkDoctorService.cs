using Microsoft.AspNetCore.Identity;
using Server.Managers.Storages.CabinetMedicalManager;
using Server.Managers.Storages.DoctorManager;
using Server.Managers.Storages.WorkDoctorManager;
using Server.Models.UserAccount;
using Server.Models.WorkDoctor;
using Server.Services.Foundation.MailService;
using static Server.Services.Foundation.WorkDoctorService.WorkDoctorServiceMapper;

namespace Server.Services.Foundation.WorkDoctorService
{
    public partial class WorkDoctorService : IWorkDoctorService
    {
        public readonly UserManager<User> _userManager;
        public readonly IDoctorManager doctorManager;
        public readonly ICabinetMedicalManager cabinetMedicalManager;
        public readonly IWorkDoctorManager workDoctorManager;
        public readonly IMailService mailService;
        public WorkDoctorService(UserManager<User> _userManager, IDoctorManager doctorManager, ICabinetMedicalManager cabinetMedicalManager, IWorkDoctorManager workDoctorManager, IMailService mailService)
        {
            this._userManager = _userManager;
            this.doctorManager = doctorManager;
            this.cabinetMedicalManager = cabinetMedicalManager;
            this.workDoctorManager = workDoctorManager;
            this.mailService = mailService;
        }
        public async Task PostNewInvitationWorkDoctor(string Email, string UserId) =>
            await TryCatch(async () =>
            {
                ValidateOnPostInvitationWorkDoctor(Email, UserId);
                var UserAdmin = await this._userManager.FindByEmailAsync(Email);
                ValidateUserIsNull(UserAdmin);
                var UserAccountDoctor = await this._userManager.FindByIdAsync(UserId);
                ValidateUserIsNull(UserAccountDoctor);
                var UserDoctor = await this.doctorManager.SelectDoctorByIdUser(UserId);
                ValidationDoctorIsNull(UserDoctor);
                var CabinetMedicalOfAdmin = await this.cabinetMedicalManager.SelectCabinetMedicalByUserId(UserAdmin.Id);
                ValidateCabinetMedicalIsNull(CabinetMedicalOfAdmin);
                var WorkDoctor = MapperToWorkDoctor(CabinetMedicalOfAdmin.Id, UserDoctor.Id);
                var WorkDoctorResultInsert = await this.workDoctorManager.InsertWorkDoctor(WorkDoctor);
                ValidateWorkDoctorIsNull(WorkDoctorResultInsert);
                var mailRequest = MapperMailRequest(UserAccountDoctor, CabinetMedicalOfAdmin);
                await this.mailService.SendEmailNotification(mailRequest);



            });


    }
}
