using DTO;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Net.Http.Headers;
using Server.Models.Doctor.Exceptions;
using Server.Models.UserAccount;
using System.Drawing;

namespace Server.Services.UserService
{
    public partial class UserService
    {
        public void ValidateUsenOnCreate(RegistreAccountDto registreAccountDto)
        {
            ValidateUserAccountIsNotInSystem(registreAccountDto.Email);
            ValidateRegistreUserIsNull(registreAccountDto);
            ValidateUserFields(registreAccountDto);
            ValidateInvalidAuditFields(registreAccountDto);


        }

        private void ValidateUserFields(RegistreAccountDto registreAccountDto)
        {
            switch (registreAccountDto)
            {
                case { } when IsInvalid(registreAccountDto.Password):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.Password),
                    parameterValue: registreAccountDto.Password, nameof(registreAccountDto));
                case { } when IsInvalid(registreAccountDto.Email):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.Email),
                    parameterValue: registreAccountDto.Email, nameof(registreAccountDto));
                case { } when IsInvalid(registreAccountDto.NationalNumber):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.NationalNumber),
                    parameterValue: registreAccountDto.NationalNumber, nameof(registreAccountDto));
                case { } when IsInvalid(registreAccountDto.PhoneNumber):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.PhoneNumber),
                    parameterValue: registreAccountDto.PhoneNumber, nameof(registreAccountDto));
                case { } when IsInvalid(registreAccountDto.ConfirmePassword):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.ConfirmePassword),
                    parameterValue: registreAccountDto.ConfirmePassword, nameof(registreAccountDto));




            }
        }

        private async void ValidateUserAccountIsNotInSystem(string Email)
        {
            var UserAccount = await this._userManager.FindByEmailAsync(Email);
            var Exception = new Exception();

            if (CheckUserIsNull(UserAccount))
            {
                throw new AlreadyExistsException(nameof(UserAccount));
            }
        }

        private void ValidateInvalidAuditFields(RegistreAccountDto registreAccountDto)
        {
            switch (registreAccountDto)
            {
                case { } when ChackNumberValidate(registreAccountDto.PhoneNumber):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.PhoneNumber),
                    parameterValue: registreAccountDto.PhoneNumber, nameof(registreAccountDto));
                case { } when ChackNumberValidate(registreAccountDto.NationalNumber):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.NationalNumber),
                    parameterValue: registreAccountDto.NationalNumber, nameof(registreAccountDto));
                case { } when ChackUserSexe((int)registreAccountDto.Sexe):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.Sexe),
                    parameterValue: ((int)registreAccountDto.Sexe), nameof(registreAccountDto));

            }

        }
        private static void ValidateRegistreUserIsNull(RegistreAccountDto registreAccountDto)
        {
            if (registreAccountDto is null)
            {
                throw new NullException(nameof(registreAccountDto));
            }
        }


        private static bool IsInvalid(string input) => String.IsNullOrWhiteSpace(input);
        private static bool ChackNumberValidate(string Field) { int n; var isNumeric = int.TryParse(Field, out n); return isNumeric; }
        private static bool ChackUserSexe(int Sexe) { if (Sexe != 1 || Sexe != 2) { return false; } return true; }
        private static bool CheckUserIsNull(User user)
        {
            if (user is null)
            {
                return true;
            }
            return false;
        }

    }
}
