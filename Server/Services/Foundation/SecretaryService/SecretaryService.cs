﻿using DTO;
using Microsoft.AspNetCore.Identity;
using Server.Managers.Storages.CabinetMedicalManager;
using Server.Managers.Storages.DoctorManager;
using Server.Managers.Storages.SecretaryManager;
using Server.Managers.Storages.SpecialitiesManager;
using Server.Managers.Storages.UserRoleManager;
using Server.Managers.Storages.WorkDoctorManager;
using Server.Managers.UserManager;
using Server.Models.secretary;
using Server.Models.UserAccount;
using Server.Services.Foundation.MailService;
using static Server.Services.Foundation.SecretaryService.SecretaryMapperService;

namespace Server.Services.Foundation.SecretaryService
{
    public partial class SecretaryService : ISecretaryService
    {
        public readonly UserManager<User> _userManager;
        public readonly ICabinetMedicalManager cabinetMedicalManager;
        public readonly IMailService mailService;
        public readonly IUserManager userManager;
        public readonly ISecretaryManager secretaryManager;
        public readonly IUserRoleManager userRoleManager;

        public SecretaryService(UserManager<User> _userManager, ICabinetMedicalManager cabinetMedicalManager, IMailService mailService, ISecretaryManager secretaryManager, IUserRoleManager userRoleManager)
        {
            this._userManager = _userManager;
            this.cabinetMedicalManager = cabinetMedicalManager;
            this.mailService = mailService;
            this.secretaryManager = secretaryManager;
            this.userRoleManager = userRoleManager;
        }
        public async Task<SecritaryDto> AddSecretaryService(string EmailSecretary, string EmailAdmin) =>
            await TryCatch(async () =>
            {
                ValidateEntry(EmailSecretary, EmailAdmin);
                var AdminUser = await this._userManager.FindByEmailAsync(EmailAdmin);
                ValidateUserIsNull(AdminUser);
                var SecretaryUser = await this._userManager.FindByEmailAsync(EmailSecretary);
                ValidateUserSecretaryIsNull(SecretaryUser);
                var Cabinet = await this.cabinetMedicalManager.SelectCabinetMedicalByUserId(AdminUser.Id);
                ValidateCabinetMedicalIsNull(Cabinet);
                var Secretary = await this.secretaryManager.SelectSecretaryByIdUserIdCabinet(SecretaryUser.Id, Cabinet.Id);
                ValidateSecritay(Secretary);
                var Listsecritary = await this.secretaryManager.SelectSecretayByIdUser(SecretaryUser.Id);
                Secretarys newSecretary = new Secretarys();
                if (Secretary == null)
                {
                    var MaperSecretary = MapperToSecritary(Cabinet.Id, SecretaryUser.Id);
                    newSecretary = await this.secretaryManager.InsertSecretary(MaperSecretary);
                    if (Listsecritary.Count() == 0)
                    {
                        var UserRole = MaperToUserRole(SecretaryUser.Id, Guid.Parse("0D518584-64A4-424B-B011-7283083394B8"));
                        await this.userRoleManager.InsertUserRoleAsync(UserRole);

                    }
                }
                else
                {
                    newSecretary = MapperSecretary(Secretary);
                    await this.secretaryManager.UpdateSecretary(newSecretary);
                }
                var mailRequest = MapperToMailRequest(SecretaryUser, Cabinet);
                await this.mailService.SendEmailNotification(mailRequest);
                return MapperToSecretaryDto(SecretaryUser, newSecretary);

            });

        public async Task<List<SecritaryDto>> GetAllSecretary(string Email) =>
            await TryCatch_(async () =>
            {
                List<SecritaryDto> resultList = new List<SecritaryDto>();
                ValidateEntry(Email);
                var AdminUser = await this._userManager.FindByEmailAsync(Email);
                ValidateUserIsNull(AdminUser);
                var Cabinet = await this.cabinetMedicalManager.SelectCabinetMedicalByUserId(AdminUser.Id);
                ValidateCabinetMedicalIsNull(Cabinet);
                var ListSecretary = await this.secretaryManager.SelectSecretaryByIdCabinet(Cabinet.Id);
                foreach (var item in ListSecretary)
                {
                    var UserAccount = await this._userManager.FindByIdAsync(item.IdUser);
                    ValidateUserIsNull(UserAccount);
                    var secretary = MapperToSecretaryDto(UserAccount, item);
                    resultList.Add(secretary);
                }
                return resultList;

            });


    }
}