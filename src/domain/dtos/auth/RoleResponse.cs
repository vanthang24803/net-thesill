using System.Text.Json.Serialization;
using Api.TheSill.src.domain.enums;

namespace Api.TheSill.src.domain.dtos.role
{
    public class RoleResponse
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }
        public DateTime CreateAt { get; set; }

    }
}