using Quikrete.Domain.Models;
using Quikrete.Domain.RequestModels;
using Quikrete.Repository.Contracts;

namespace Quikrete.Repository.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players = [];

        public Player CreatePlayer(Player player)
        {
            _players.Add(player);

            return player;
        }

        public void DeletePlayer(Player player)
        {
            _players.Remove(player);
        }

        public Player? GetPlayerById(Guid id)
        {
            return _players.FirstOrDefault(player => player.Id == id);
        }

        public IEnumerable<Player> GetPlayers(GetPlayersRequest request)
        {
            if(request.Filter!.Length == 0)
            {
                return _players;
            }

            var response = new List<Player>();

            request.Filter!.ToList().ForEach(filter =>
            {
                var matchedPlayers = _players.Where(player =>
                                        player.Position == filter.Position
                                        && player.Skills.Any(skill => skill.Name == filter.Skill));

                if (matchedPlayers.Any())
                {
                    Array.Sort(matchedPlayers.ToArray(), (player1, player2) =>
                    {
                        var player1SkillValue = player1.Skills.FirstOrDefault(skill => skill.Name == filter.Skill);
                        var player2SkillValue = player2.Skills.FirstOrDefault(skill => skill.Name == filter.Skill);

                        return (player1SkillValue?.Value ?? 0) - (player2SkillValue?.Value ?? 0);
                    });

                    response.Add(matchedPlayers.Last());
                }
            });

            return response;
        }

        public Player UpdatePlayer(Player player)
        {
            var playerToUpdate = GetPlayerById(player.Id);
            playerToUpdate!.Name = player.Name;
            playerToUpdate!.Position = player.Position;
            playerToUpdate!.Skills = player.Skills;

            return playerToUpdate;
        }
    }
}
