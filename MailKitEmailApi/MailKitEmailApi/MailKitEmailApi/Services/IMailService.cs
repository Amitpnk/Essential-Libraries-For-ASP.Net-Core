using MailKitEmailApi.Models;
using System.Threading.Tasks;

namespace MailKitEmailApi.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

        Task SendWelcomeEmailAsync(WelcomeRequest request);

    }
}
