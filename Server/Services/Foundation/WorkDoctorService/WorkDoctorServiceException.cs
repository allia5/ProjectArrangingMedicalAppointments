using DTO;
using Microsoft.Data.SqlClient;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;

namespace Server.Services.Foundation.WorkDoctorService
{
    public partial class WorkDoctorService
    {
        private delegate Task returningFunction();
        private delegate Task<List<InvitationsDoctorDto>> ReturningInvitationFunction();

        private async Task TryCatch(returningFunction returningFunction)
        {
            try
            {
                await returningFunction();
            }
            catch (NullException Ex)
            {
                throw new ValidationException(Ex);
            }
            catch (NullDataStorageException Ex)
            {
                throw new ServiceException(Ex);
            }

        }
        private async Task<List<InvitationsDoctorDto>> _TryCatch(ReturningInvitationFunction returningInvitationFunction)
        {
            try
            {
                return await returningInvitationFunction();
            }
            catch (NullException Ex)
            {
                throw new ValidationException(Ex);
            }
            catch (NullDataStorageException Ex)
            {
                throw new ServiceException(Ex);
            }

        }
    }
}
