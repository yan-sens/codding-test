using Quikrete.Domain.Models;

namespace Quikrete.API.Validators
{
    public static class PlayerValidator
    {
        private static readonly List<string> _skills =
        [
            "defense",
            "attack",
            "speed",
            "strength",
            "stamina"
        ];

        public static ValidationResponse ValidatePlayer(Player player)
        {
            var response = new ValidationResponse();

            if(player.Skills.Count == 0)
            {
                response.Code = System.Net.HttpStatusCode.BadRequest;
                response.Message = "The player needs to have at least one skill.";
            }

            if(player.Skills.Any(skill => !_skills.Any(s => s == skill.Name)))
            {
                response.Code = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Unknown skill.";
            }

            return response;
        }
    }
}
