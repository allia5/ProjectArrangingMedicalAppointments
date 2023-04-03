﻿using Client.Services.Foundations.LocalStorageService;
using Client.Services.Foundations.MedicalPlanningService;
using DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Pages
{
    public class BookingMedicalInformationComponentBase : ComponentBase
    {
        protected string ErrorMessage = null;
        protected bool IsLoading = true;
        public AppointmentInformationDto appointmentInformation = null;
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IMedicalPlanningService medicalPlanningService { get; set; }
        [Inject]
        public ILocalStorageServices localStorageServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {

                var result = await this.AuthenticationStateProvider.GetAuthenticationStateAsync();
                if (result.User.Identity?.IsAuthenticated ?? false)
                {
                    var KeysReservation = await this.localStorageServices.GetItemAsync<KeysReservationMedicalDto>("KeysReservationMedical");
                    this.appointmentInformation = await this.medicalPlanningService.GetAppointmentInformationDto(KeysReservation);
                    IsLoading = false;
                }
                else
                {
                    NavigationManager.NavigateTo("/Login/PlanningMedicalInformation");
                }
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
                IsLoading = false;

            }


        }
    }
}
