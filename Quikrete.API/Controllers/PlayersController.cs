using Microsoft.AspNetCore.Mvc;
using Quikrete.API.Validators;
using Quikrete.Domain.Models;
using Quikrete.Domain.RequestModels;
using Quikrete.Repository.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace Quikrete.API.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IPlayerRepository _playerRepository;

        public PlayersController(ILogger<PlayersController> logger, IPlayerRepository playerRepository)
        {
            _logger = logger;
            _playerRepository = playerRepository;
        }

        [HttpPost("list")]
        [SwaggerOperation(Summary = "Get filtered players.")]
        public ObjectResult GetPlayers(GetPlayersRequest request)
        {
            var response = this._playerRepository.GetPlayers(request);
            return Ok(response);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete player by player id.")]
        public ObjectResult DeletePlayer(Guid playerId)
        {
            var playerToDelete = _playerRepository.GetPlayerById(playerId);
            if (playerToDelete == null)
            {
                return new NotFoundObjectResult(playerId);
            }

            _playerRepository.DeletePlayer(playerToDelete);

            return Ok(playerId);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update player.")]
        public ObjectResult UpdatePlayer(Player player)
        {
            var playerToDelete = _playerRepository.GetPlayerById(player.Id);
            if (playerToDelete == null)
            {
                return new NotFoundObjectResult(player.Id);
            }

            var response = _playerRepository.UpdatePlayer(player);
            return Ok(response);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new player.")]
        public ObjectResult CreatePlayer(Player player)
        {
            var validationResult = PlayerValidator.ValidatePlayer(player);
            if (validationResult.Code != System.Net.HttpStatusCode.OK) 
            {
                this._logger.LogError(validationResult.Message);
                return StatusCode((int)validationResult.Code, validationResult.Message);
            }

            try
            {
                var response = this._playerRepository.CreatePlayer(player);
                return Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
