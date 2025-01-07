using Quikrete.Domain.Enums;

namespace Quikrete.Domain.RequestModels
{
    public class GetPlayersRequest
    {
        public PlayerRequest[]? Filter { get; set; }
    }
}
