
using Api.TheSill.src.domain.dtos.mail;

namespace Api.TheSill.src.interfaces {
    public interface IMailService {
        Task SendMailAsync(MailRequest mailRequest);
    }
}