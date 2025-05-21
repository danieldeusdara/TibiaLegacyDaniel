using Microsoft.AspNetCore.Mvc;
using TibiaLegacyBusiness.DTOs;
using TibiaLegacyBusiness.Servicos;

namespace TibiaLegacy.Controllers
{
    public class CriaturasController : Controller
    {
        private readonly ILogger<CriaturasController> _logger; // Propriedade para injeção na controller que permite registrar mensagens em diferentes níveis de log

        public CriaturasController(ILogger<CriaturasController> logger)
        {
            _logger = logger; // Injeção de dependência
        }

        // Método para carregar a view referente a controller, que irá carregar a página.
        public IActionResult Index() 
        {
            return View();
        }

        // Retorna uma lista com todas criaturas.
        [HttpGet]                           
        public IActionResult GetCriaturas() // IActionResult = Se precisar retornar varios tipos de resposta ou caso exija mais controle sobre a resposta HTTP
                                            // Action Result = Caso sempre retorne um objeto, caso o retorno seja sempre um tipo específico.
        {                                   // Em questões performáticas a diferença entre os dois é minima, somente em cenários de altissimsa carga.
            try
            {
                _logger.LogInformation("Método GetCriaturas foi chamado."); // Registro de log

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
