using Quikrete.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quikrete.Domain.RequestModels
{
    public class PlayerRequest
    {
        public PlayerPosition Position { get; set; }

        public required string Skill { get; set; }
    }
}
