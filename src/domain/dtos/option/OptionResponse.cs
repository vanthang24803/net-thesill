namespace Api.TheSill.src.domain.dtos.option {
    public class OptionResponse {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Price { get; set; }
        public long Quantity { get; set; }
        public int Sale { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}