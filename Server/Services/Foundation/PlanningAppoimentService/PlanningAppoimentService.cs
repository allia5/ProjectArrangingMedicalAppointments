using DTO;
using Microsoft.AspNetCore.Identity;
using Server.Managers.Storages.CabinetMedicalManager;
using Server.Managers.Storages.DoctorManager;
using Server.Managers.Storages.PlanningAppoimentManager;
using Server.Managers.Storages.RolesManager;
using Server.Managers.Storages.SpecialitiesManager;
using Server.Managers.Storages.UserRoleManager;
using Server.Managers.Storages.WorkDoctorManager;
using Server.Managers.UserManager;
using Server.Models.Doctor.Exceptions;
using Server.Models.MedicalPlannings;
using Server.Models.UserAccount;
using Server.Models.UtilityModel;
using Server.Models.WorkDoctor;
using Server.Services.Foundation.JwtService;
using Server.Services.Foundation.MailService;
using System.Runtime.CompilerServices;
using static Server.Utility.Utility;
using static Server.Services.Foundation.PlanningAppoimentService.PlanningAppoimentMapperService;

namespace Server.Services.Foundation.PlanningAppoimentService
{
    public partial class PlanningAppoimentService : IPlanningAppoimentService
    {
        public IMailService mailService { get; set; }
        public readonly IUserRoleManager userRoleManager;
        public readonly UserManager<User> _userManager;
        public readonly IUserManager userManager;
        public readonly ICabinetMedicalManager cabinetMedicalManager;
        public readonly IWorkDoctorManager workDoctorManager;
        public readonly IDoctorManager doctorManager;
        public readonly ISpecialitiesManager specialitiesManager;
        public readonly IPlanningAppoimentManager planningAppoimentManager;
        public PlanningAppoimentService(IUserManager userManager, IMailService mailService, UserManager<User> _userManager, ICabinetMedicalManager cabinetMedicalManager, IWorkDoctorManager workDoctorManager, IDoctorManager doctorManager, ISpecialitiesManager specialitiesManager, IPlanningAppoimentManager planningAppoimentManager)
        {
            this.doctorManager = doctorManager;
            this.mailService = mailService;
            this.userManager = userManager;
            this._userManager = _userManager;
            this.workDoctorManager = workDoctorManager;
            this.cabinetMedicalManager = cabinetMedicalManager;
            this.specialitiesManager = specialitiesManager;
            this.planningAppoimentManager = planningAppoimentManager;
        }
        public async Task<AppointmentInformationDto> PostNewPlanningAppoimentMedical(string Email, KeysReservationMedicalDto keysReservationMedicalDto) =>
            await TryCatch(async () =>
            {
                ValidateEntryOnPostNewAppoimentPlanning(Email, keysReservationMedicalDto);
                var User = await this._userManager.FindByEmailAsync(Email);
                ValidateUserIsNull(User);
                ValidateStatusUser(User);
                var Doctor = await this.doctorManager.SelectDoctorByIdUser(DecryptGuid(keysReservationMedicalDto.IdUserDoctor).ToString());
                ValidationDoctorIsNull(Doctor);
                ValidateStatusDocotor(Doctor);
                var Cabinet = await this.cabinetMedicalManager.SelectCabinetMedicalOpenById(DecryptGuid(keysReservationMedicalDto.IdCabinet));
                ValidateCabinetMedicalIsNull(Cabinet);
                var Job = await this.workDoctorManager.SelectWorkDoctorByIdDoctorIdCabinetWithStatusActive(Doctor.Id, Cabinet.Id);
                ValidateWorkDoctorIsNull(Job);
                // var PlaningAppoiments = await this.planningAppoimentManager.SelectMedicalPlanningByIdDoctorIdCabinet(Doctor.Id, Cabinet.Id, DateTime.Now);
                // ValidateUserIsNotInListAppoiment(User.Id, PlaningAppoiments);
                var PlanningInformationModel = await GetDateReservation(Job, User);
                var MedicalPlanning = mapperToMedicalPlanning(PlanningInformationModel, Doctor, Cabinet, User.Id);
                await this.planningAppoimentManager.InsertMedicalPlanning(MedicalPlanning);
                var ListSpecilities = await this.specialitiesManager.SelectSpecialitiesByIdDoctor(Doctor.Id);
                var ListStringSpecialities = ListSpecilities.Select(e => e.NameSpecialite).ToList();
                var UserDoctor = await this.userManager.SelectUserByIdDoctor(Doctor.Id);
                ValidateUserIsNull(UserDoctor);
                var DoctorAppoimentInformation = mapperToDoctorInformationAppointmentDto(User, ListStringSpecialities, Job);
                var CabinetAppoimentInformation = MapperToCabinetInformationAppointmentDto(Cabinet);
                return MapperToAppointmentInformationDto(DoctorAppoimentInformation, CabinetAppoimentInformation, MedicalPlanning);
            });














        private async Task<PlanningInformationModel> GetDateReservation(WorkDoctors workDoctors, User user)
        {
            DateTime today = DateTime.Today;
            TimeSpan EndTime = workDoctors.EndTime.TimeOfDay;
            DateTime DateTimeEndTime = today.Add(EndTime);
            if (DateTime.Today > DateTimeEndTime)
            {
                var ListPlanningMedicalConfirmed = await this.planningAppoimentManager.SelectMedicalPlanningByIdDoctorIdCabinet(workDoctors.IdCabinet, workDoctors.IdDoctor, DateTime.Now.AddDays(1), StatusRequestPlanning.Confirmed);
                var ListPlanningMedicalNotConfirmed = await this.planningAppoimentManager.SelectMedicalPlanningByIdDoctorIdCabinet(workDoctors.IdCabinet, workDoctors.IdDoctor, DateTime.Now, StatusRequestPlanning.NotConfimed);
                if (ListPlanningMedicalConfirmed.Count() < workDoctors.NbPatientAvailble)
                {
                    ValidateUserIsNotInListAppoiment(user.Id, ListPlanningMedicalNotConfirmed);
                    return new PlanningInformationModel { DateAppoiment = DateTime.Now.AddDays(1), CountOfPatient = ListPlanningMedicalConfirmed.Count() + 1 };
                }
                else
                {
                    throw new NotFoundException("Date Reservation");
                }
            }
            else
            {
                var ListPlanningMedicalConfirmed = await this.planningAppoimentManager.SelectMedicalPlanningByIdDoctorIdCabinet(workDoctors.IdCabinet, workDoctors.IdDoctor, DateTime.Now, StatusRequestPlanning.Confirmed);
                var ListPlanningMedicalNotConfirmed = await this.planningAppoimentManager.SelectMedicalPlanningByIdDoctorIdCabinet(workDoctors.IdCabinet, workDoctors.IdDoctor, DateTime.Now, StatusRequestPlanning.NotConfimed);
                if (ListPlanningMedicalConfirmed.Count() < workDoctors.NbPatientAvailble)
                {
                    ValidateUserIsNotInListAppoiment(user.Id, ListPlanningMedicalNotConfirmed);
                    return new PlanningInformationModel { DateAppoiment = DateTime.Now, CountOfPatient = ListPlanningMedicalConfirmed.Count() + 1 };
                }
                else
                {
                    throw new NotFoundException("Date Reservation");
                }
            }

        }

    }
}
