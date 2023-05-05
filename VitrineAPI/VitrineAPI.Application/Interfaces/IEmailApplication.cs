using VitrineAPI.Application.Dtos.Smtp;

namespace VitrineAPI.Application.Interfaces
{
    public interface IEmailApplication
    {
        public Task SendEmail(UserEmailOptions userEmailOptions, string emailTemplate);
    }
}