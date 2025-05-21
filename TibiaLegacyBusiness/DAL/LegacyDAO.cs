using Newtonsoft.Json;
using TibiaLegacyBusiness.DTOs;
using static TibiaLegacyBusiness.DTOs.BossBoostadoDTO;
using static TibiaLegacyBusiness.DTOs.CriaturasDTO;

namespace TibiaLegacyBusiness.DAL
{
    public class LegacyDAO
    {
        public const string API_CREATURES = "https://api.tibiadata.com/v4/creatures";
        public const string API_BOSS_BOOSTADO = "https://api.tibiadata.com/v4/boostablebosses";
      
        public async Task<Boostado> GetCriaturaBoostada()
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
                var criaturas = JsonConvert.DeserializeObject<CriaturasDTO>(content);

                var boostado = new Boostado();

                if (criaturas != null)
                    boostado = criaturas.creatures.boosted;

                return boostado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Boosted> GetBossBoostado()
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, API_BOSS_BOOSTADO);

            try
            {
                var response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var bossBoostado = JsonConvert.DeserializeObject<BossBoostadoDTO>(content);

                var boostado = new Boosted();

                if (bossBoostado != null)
                    boostado = bossBoostado.boostable_bosses.boosted;

                return boostado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
