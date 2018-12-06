using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUTORized.Services.Abstract
{
    public interface IMessageService
    {
        Task SendAppointmentMadeEmailAsync(string email, string subject, string message);

        Task SendConfirmEmailAsync(string email, string subject, string message);
    }
}
