using DTO;
using Microsoft.Data.SqlClient;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;

namespace Server.Services.Foundation.WorkDoctorService
{
    public partial class WorkDoctorService
    {
        private delegate Task returningFunction();

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
    }
}
