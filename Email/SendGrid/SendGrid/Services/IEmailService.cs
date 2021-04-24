using SendGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
