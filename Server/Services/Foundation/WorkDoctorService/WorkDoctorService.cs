using DTO;
using Microsoft.AspNetCore.Identity;
using Server.Managers.Storages.CabinetMedicalManager;
using Server.Managers.Storages.DoctorManager;
using Server.Managers.Storages.WorkDoctorManager;
using Server.Models.UserAccount;
using Server.Models.WorkDoctor;
using Server.Services.Foundation.MailService;
using static Server.Services.Foundation.WorkDoctorService.WorkDoctorServiceMapper;
using static Server.Utility.Utility;

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

        public async Task<List<InvitationsDoctorDto>> GetInvitationDoctor(string Email) =>
      await _TryCatch(async () =>
      {
          List<InvitationsDoctorDto> invitationsDoctors = new List<InvitationsDoctorDto>();
          ValidateEmailIsNull(Email);
          var UserAccount = await this._userManager.FindByEmailAsync(Email);
          ValidateUserIsNull(UserAccount);
          var Doctor = await this.doctorManager.SelectDoctorByIdUser(UserAccount.Id);
          ValidationDoctorIsNull(Doctor);
          var ListWorkDoctor = await this.workDoctorManager.SelectWorksDoctorByIdDoctor(Doctor.Id);
          //  ValidateListInvitationWorkDoctor(ListWorkDoctor);
          foreach (var item in ListWorkDoctor)
          {
              var cabinet = await this.cabinetMedicalManager.SelectCabinetMedicalById(item.IdCabinet);
              ValidateCabinetMedicalIsNull(cabinet);
              var invitation = MapperToInvitationsDoctorDto(cabinet, item);
              invitationsDoctors.Add(invitation);


          }
          return invitationsDoctors;



      });

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

        public async Task UpdateStatusServiceWorkDoctor(string Email, UpdateStatusWorkDoctorDto updateStatusWorkDoctorDto) =>
            await TryCatch(async () =>
            {
                ValidateOnUpdateStatusWorkDoctoter(Email, updateStatusWorkDoctorDto);
                var User = await this._userManager.FindByEmailAsync(Email);
                ValidateUserIsNull(User);
                var Doctor = await this.doctorManager.SelectDoctorByIdUser(User.Id);
                ValidationDoctorIsNull(Doctor);
                var WorkDoctor = await this.workDoctorManager.SelectWorkDoctorByIdDoctorWithIdWorkDoctor(DecryptGuid(updateStatusWorkDoctorDto.WorkId), Doctor.Id);
                ValidateWorkDoctorIsNull(WorkDoctor);
                var newWorkDoctor = MapperToNewWorkDoctorStatusService(WorkDoctor, updateStatusWorkDoctorDto);
                await this.workDoctorManager.UpdateWorkDoctor(WorkDoctor);

            });

        public async Task<List<JobsDoctorDto>> GetListJobsDoctorService(string Email) =>
            await TryCatch_(async () =>
            {
                List<JobsDoctorDto> jobsDoctorDtos = new List<JobsDoctorDto>();
                ValidateEmailIsNull(Email);
                var User = await this._userManager.FindByEmailAsync(Email);
                ValidateUserIsNull(User);
                var Doctor = await this.doctorManager.SelectDoctorByIdUser(User.Id);
                ValidationDoctorIsNull(Doctor);
                var ListJobsDoctor = await this.workDoctorManager.SelectWorksDoctorActiveByIdDoctor(Doctor.Id);
                foreach (var item in ListJobsDoctor)
                {
                    var Cabinet = await this.cabinetMedicalManager.SelectCabinetMedicalById(item.IdCabinet);
                    ValidateCabinetMedicalIsNull(Cabinet);
                    var JobDoctorDto = MapperToJobsDoctorDto(item.Id, Cabinet);
                    jobsDoctorDtos.Add(JobDoctorDto);
                }
                return jobsDoctorDtos;

            });







    }
}
