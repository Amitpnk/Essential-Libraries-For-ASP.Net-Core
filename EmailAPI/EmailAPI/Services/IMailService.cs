using EmailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAPI.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

        Task SendWelcomeEmailAsync(WelcomeRequest request);

    }
}
