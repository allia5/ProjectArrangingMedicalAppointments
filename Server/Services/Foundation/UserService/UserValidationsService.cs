﻿using DTO;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;
using Server.Models.UserAccount;
using System.Drawing;

namespace Server.Services.UserService
{
    public partial class UserService
    {
        public async Task ValidateUsenOnCreate(RegistreAccountDto registreAccountDto)
        {
            await ValidateUserAccountIsNotInSystem(registreAccountDto.Email);
            ValidateRegistreUserIsNull(registreAccountDto);
            ValidateUserFields(registreAccountDto);
            ValidateInvalidAuditFields(registreAccountDto);


        }

        public void ValidateEntryConfirmeEmail(string id, string Token)
        {
            if (IsInvalid(id) == true && IsInvalid(Token) == true)
            {
                throw new NullException(nameof(id) + nameof(Token));
            }
            else if (IsInvalid(id) == true)
            {
                throw new NullException(nameof(id));
            }
            else if (IsInvalid(Token) == true)
            {
                throw new NullException(nameof(Token));
            }

        }

        public void ValidateUserIsNull(User user)
        {
            if (user == null)
            {
                throw new NullException(nameof(user));
            }
        }
        public void ValidateIdentityToken(IdentityResult identityResult)
        {
            if (identityResult.Succeeded == false)
            {
                throw new IdentityTokenException(nameof(identityResult));
            }
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



        private void ValidateInvalidAuditFields(RegistreAccountDto registreAccountDto)
        {
            switch (registreAccountDto)
            {
                case { } when !ChackNumberValidate(registreAccountDto.PhoneNumber):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.PhoneNumber),
                    parameterValue: registreAccountDto.PhoneNumber, nameof(registreAccountDto));
                /*case { } when !ChackNumberValidate(registreAccountDto.NationalNumber):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.NationalNumber),
                    parameterValue: registreAccountDto.NationalNumber, nameof(registreAccountDto));*/
                case { } when ChackUserSexe((int)registreAccountDto.Sexe):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.Sexe),
                    parameterValue: ((int)registreAccountDto.Sexe), nameof(registreAccountDto));
                case { } when ValidateDate(registreAccountDto.DateOfBirth):
                    throw new InvalidException(
                    parameterName: nameof(registreAccountDto.DateOfBirth),
                    parameterValue: registreAccountDto.DateOfBirth, nameof(registreAccountDto));

            }

        }
        private static void ValidateRegistreUserIsNull(RegistreAccountDto registreAccountDto)
        {
            if (registreAccountDto is null)
            {
                throw new NullException(nameof(registreAccountDto));
            }
        }


        public static bool IsInvalid(string input) => String.IsNullOrWhiteSpace(input);
        public static bool ValidateDate(DateTime Date)
        {
            if (DateTime.UtcNow > Date)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ChackNumberValidate(string Field) { int n; var isNumeric = Int32.TryParse(Field, out n); return isNumeric; }
        public static bool ChackUserSexe(int Sexe) { if (Sexe != 1 || Sexe != 2) { return false; } return true; }
        public static bool CheckUserIsNull(User user)
        {
            if (user is null)
            {
                return true;
            }
            return false;
        }

    }
}
