namespace Api.TheSill.src.domain.dtos.mail
{
    public class MailRequest
    {
        public string ToEmail { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}