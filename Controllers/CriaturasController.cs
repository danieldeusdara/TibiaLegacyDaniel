using Microsoft.AspNetCore.Mvc;
using TibiaLegacyBusiness.DTOs;
using TibiaLegacyBusiness.Servicos;

namespace TibiaLegacy.Controllers
{
    public class CriaturasController : Controller
    {
        private readonly ILogger<CriaturasController> _logger; // Propriedade para inje��o na controller que permite registrar mensagens em diferentes n�veis de log

        public CriaturasController(ILogger<CriaturasController> logger)
        {
            _logger = logger; // Inje��o de depend�ncia
        }

        // M�todo para carregar a view referente a controller, que ir� carregar a p�gina.
        public IActionResult Index() 
        {
            return View();
        }

        // Retorna uma lista com todas criaturas.
        [HttpGet]                           
        public IActionResult GetCriaturas() // IActionResult = Se precisar retornar varios tipos de resposta ou caso exija mais controle sobre a resposta HTTP
                                            // Action Result = Caso sempre retorne um objeto, caso o retorno seja sempre um tipo espec�fico.
        {                                   // Em quest�es perform�ticas a diferen�a entre os dois � minima, somente em cen�rios de altissimsa carga.
            try
            {
                _logger.LogInformation("M�todo GetCriaturas foi chamado."); // Registro de log

                var listaCriaturas = new CriaturasServicos().GetCriaturas();

                _logger.LogInformation("Retornando {count} criaturas.", listaCriaturas.Count);

                return Json(new { data = listaCriaturas });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
