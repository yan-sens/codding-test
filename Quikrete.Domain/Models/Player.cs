
using Quikrete.Domain.Enums;

namespace Quikrete.Domain.Models
{
    public class Player : BaseModel
    {
        public required string Name { get; set; }

        public required PlayerPosition Position { get; set; }

        public required List<PlayerSkill> Skills { get; set; }
    }
}
