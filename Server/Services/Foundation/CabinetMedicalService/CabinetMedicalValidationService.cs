using Server.Models.CabinetMedicals;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;
using Server.Models.UserAccount;

namespace Server.Services.Foundation.CabinetMedicalService
{
    public partial class CabinetMedicalService
    {
        public void ValidateUserIsNull(User user)
        {
            if (user == null)
            {
                throw new NullException(nameof(user));
            }
        }
        public void ValidateEntryString(string Entry)
        {
            if (Entry == null)
            {
                throw new NullException(nameof(Entry));
            }
        }
        public void ValidateCabinetMedicalIsNull(CabinetMedical cabinetMedical)
        {
            if (cabinetMedical == null)
            {
                throw new NullDataStorageException(nameof(cabinetMedical));
            }
        }
    }
}
