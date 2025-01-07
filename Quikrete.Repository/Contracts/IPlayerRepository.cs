using Quikrete.Domain.Models;
using Quikrete.Domain.RequestModels;

namespace Quikrete.Repository.Contracts
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayers(GetPlayersRequest request);

        Player? GetPlayerById(Guid id);

        Player CreatePlayer(Player player);

        Player UpdatePlayer(Player player);

        void DeletePlayer(Player player);
    }
}
