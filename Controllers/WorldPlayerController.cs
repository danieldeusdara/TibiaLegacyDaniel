using Microsoft.AspNetCore.Mvc;
using TibiaLegacyBusiness.Servicos;

namespace TibiaLegacy.Controllers
{
    public class WorldPlayerController : Controller
    {
        private readonly ILogger<WorldPlayerController> _logger;

        public WorldPlayerController(ILogger<WorldPlayerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Retorna uma lista com todos os mundos.
        [HttpGet]
        public IActionResult GetMundos()
        {
            try
            {
                _logger.LogInformation("Método GetMundos foi chamado.");

                var listaMundos = new WorldPlayerServicos().GetMundos();

                _logger.LogInformation("Retornando {count} mundos.", listaMundos.Count);

                return Json(new { data = listaMundos });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Retorna um objeto com todas informações de um char
        [HttpGet]
        public IActionResult GetCharacter(string name)
        {
            try
            {
                _logger.LogInformation("Método GetCharater foi chamado.");

                var character = new WorldPlayerServicos().GetCharacter(name);

                if (character.ErrorMessage == null && character.character != null)
                {
                    _logger.LogInformation("Retornando character: {name} ", character.character.character.name);
                    return Json(new { data = character });
                }
                else
                {
                    _logger.LogInformation(character.ErrorMessage);
                    throw new Exception(character.ErrorMessage);
                }                                   
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // Retorna os players online de um mundo específico
        [HttpGet]
        public IActionResult GetPlayersOnline(string mundo)
        {
            try
            {
                _logger.LogInformation("Método GetPlayersOnline foi chamado.");

                var playersOnline = new WorldPlayerServicos().GetPlayersOnline(mundo);

                _logger.LogInformation("Detalhes do mundo {mundo} retornado com sucesso.", mundo);

                return Json(new {
                    playersOnline.world.name,
                    status = playersOnline.world.online_players
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
