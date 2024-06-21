
namespace Api.TheSill.src.domain.dtos.photo {
    public class PhotoResponse {
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; }
    }
}