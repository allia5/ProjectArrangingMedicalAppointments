using DTO;
using Newtonsoft.Json.Linq;
using Server.Models.CabinetMedicals;
using Server.Models.UserAccount;
using Server.Models.WorkDoctor;
using System;

namespace Server.Services.Foundation.WorkDoctorService
{
    public static class WorkDoctorServiceMapper
    {
        public static WorkDoctors MapperToWorkDoctor(Guid IdCabinet, Guid IdDoctor)
        {
            return new WorkDoctors
            {
                Id = Guid.NewGuid(),
                DateInvitation = DateTime.Now,
                StatusWork = StatusWork.still,
                statusServcie = Models.WorkDoctor.StatusService.OutService,
                statusReservation = StatusReservation.NotAvailable,
                IdCabinet = IdCabinet,
                 IdDoctor= IdDoctor,
                NbPatientAvailble = 0,
                TimeOfConsultation = 0,
                EndTime = DateTime.MinValue,
                ReadyTime = DateTime.MaxValue,
            };
        }
        public static MailRequest MapperMailRequest(User user, CabinetMedical cabinetMedical)
        {
            return new MailRequest
            {
                ToEmail = user.Email,
                Subject = "Notification",
                Body = " <h3> AliaMed.Com </h3> " +
                                $"<a>you are recived Invitation from Cabine {cabinetMedical.NameCabinet}</a>" + "<br/>"
            };
        }

    }
}

