namespace Api.TheSill.src.common.helpers {
    public class JwtPayload {
        public Guid Id { get; set; }

        public DateTime Expires { get; set; }
    }
}