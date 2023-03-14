using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OtripleS.Web.Api.Models.Users.Exceptions;
using Server.Models.Doctor.Exceptions;
using Server.Models.UserAccount;

namespace Server.Services.UserService
{
    public partial class UserService
    {
        private delegate ValueTask<MessageResultDto> ReturningUserFunction();
        private delegate IQueryable<MessageResultDto> ReturningQueryableUserFunction();

        private async ValueTask<MessageResultDto> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return await returningUserFunction();
            }
            catch (NullException nullUserException)
            {
                throw new ValidationException(nullUserException);
            }
            catch (AlreadyExistsException AlreadyExistsException)
            {
                throw new ServiceException(AlreadyExistsException);
            }
            catch (InvalidException InvalidException)
            {
                throw new ServiceException(InvalidException);
            }
            catch (SqlException SqlException)
            {
                throw new FailedUserServiceException(SqlException);
            }
            catch (Exception exception)
            {
                throw new ServiceException(exception);


            }
        }
    }
}
