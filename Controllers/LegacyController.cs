using Microsoft.AspNetCore.Mvc;
using TibiaLegacyBusiness.Servicos;

namespace TibiaLegacy.Controllers
{
    public class LegacyController : Controller
    {
        private readonly ILogger<LegacyController> _logger;

        public LegacyController(ILogger<LegacyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Método para buscar a criatura boostada do dia
        public IActionResult GetCriaturaBoostada()
        {          
            try
            {
                _logger.LogInformation("Método GetCriaturaBoostada foi chamado.");

                var criaturaBoostada = new LegacyServicos().GetCriaturaBoostada();

                _logger.LogInformation("Criatura boostada {boostado} retornado com sucesso.", criaturaBoostada.name);

                return Json(new
                {
                    criaturaBoostada.image_url,
                    criaturaBoostada.name
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Método para buscar o boss boostado do dia
        public IActionResult GetBossBoostado()
        {
            try
            {
                _logger.LogInformation("Método GetBossBoostado foi chamado.");

                var bossBoostado = new LegacyServicos().GetBossBoostado();

                _logger.LogInformation("Boss boostado {boostado} retornado com sucesso.", bossBoostado.name);

                return Json(new
                {
                    bossBoostado.image_url,
                    bossBoostado.name
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
