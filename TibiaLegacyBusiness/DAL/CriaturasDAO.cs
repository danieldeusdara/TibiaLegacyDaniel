using Newtonsoft.Json;
using TibiaLegacyBusiness.DTOs;
using static TibiaLegacyBusiness.DTOs.BossBoostadoDTO;
using static TibiaLegacyBusiness.DTOs.CriaturasDTO;

namespace TibiaLegacyBusiness.DAL
{
    public class CriaturasDAO
    {
        public const string API_CREATURES = "https://api.tibiadata.com/v4/creatures";
        public const string API_BOSS_BOOSTADO = "https://api.tibiadata.com/v4/boostablebosses";

        // Esse método consome a mesma API que o próximo, talvez seja possível usar apenas um e tratar o retorno no service de acordo com o que é necessário.
        public async Task<List<CreatureList>> GetCriaturas()
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, API_CREATURES);

            try
            {
                // Enviar a requisição e obter a resposta
                var response = await httpClient.SendAsync(request);

                // Verificar se a resposta foi bem-sucedida
                response.EnsureSuccessStatusCode();

                // Ler o conteúdo da resposta como string
                var content = await response.Content.ReadAsStringAsync();

                // Deserializar o JSON para o objeto esperado
                var mundosData = JsonConvert.DeserializeObject<CriaturasDTO>(content);

                var mundosList = new List<CreatureList>();

                if (mundosData != null)
                    mundosList.AddRange(mundosData.creatures.creature_list);

                return mundosList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
