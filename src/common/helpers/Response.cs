namespace Api.TheSill.src.common.helpers
{
    public class Response<T>
    {
        public int Status { get; set; } 
        public required T Result { get; set; }
    }
}