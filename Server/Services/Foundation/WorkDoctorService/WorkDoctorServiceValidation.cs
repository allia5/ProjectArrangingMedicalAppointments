using DTO;
using Server.Models.CabinetMedicals;
using Server.Models.Doctor;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;
using Server.Models.UserAccount;
using Server.Models.WorkDoctor;

namespace Server.Services.Foundation.WorkDoctorService
{
    public partial class WorkDoctorService
    {
        public void ValidateOnPostInvitationWorkDoctor(string Email, string IdUserDoctor)
        {
            if (IsInvalid(Email))
            {
                throw new NullException(nameof(Email));
            }
            else if (IsInvalid(IdUserDoctor))
            {
                throw new NullException(nameof(IdUserDoctor));
            }
        }
        public void ValidateUserIsNull(User user)
        {
            if (user == null)
            {
                throw new NullException(nameof(user));
            }
        }
        public void ValidationDoctorIsNull(Doctors doctor)
        {
            if (doctor == null)
            {
                throw new NullException(nameof(doctor));

            }
        }
        public void ValidateCabinetMedicalIsNull(CabinetMedical cabinetMedical)
        {
            if (cabinetMedical == null)
            {
                throw new NullDataStorageException(nameof(cabinetMedical));
            }
        }
        public void ValidateWorkDoctorIsNull(WorkDoctors workDoctors)
        {
            if (workDoctors == null)
            {
                throw new NullException(nameof(workDoctors));
            }
        }
        public static bool IsInvalid(string input) => String.IsNullOrWhiteSpace(input);
    }
}
