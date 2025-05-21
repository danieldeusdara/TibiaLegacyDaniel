using Newtonsoft.Json;
using TibiaLegacyBusiness.DTOs;
using static TibiaLegacyBusiness.DTOs.MundosDTO;

namespace TibiaLegacyBusiness.DAL
{
    public class WorldPlayerDAO
    {
        public const string API_WORLDS = "https://api.tibiadata.com/v4/worlds";
        public const string API_PLAYERSONLINE = "https://api.tibiadata.com/v4/world/";
        public const string API_CHARACTER = "https://api.tibiadata.com/v4/character/";

        public async Task<List<RegularWorlds>> GetMundos()
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, API_WORLDS);

            try
            {
                // Enviar a requisição e obter a resposta
                var response = await httpClient.SendAsync(request);

                // Verificar se a resposta foi bem-sucedida
                response.EnsureSuccessStatusCode();

                // Ler o conteúdo da resposta como string
                var content = await response.Content.ReadAsStringAsync();

                // Deserializar o JSON para o objeto esperado
                var mundosData = JsonConvert.DeserializeObject<MundosDTO>(content);

                var mundosList = new List<RegularWorlds>();

                if (mundosData != null)
                    mundosList.AddRange(mundosData.Worlds.regular_worlds);

                return mundosList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CharacterDTO> GetCharacter(string name)
        {
            var httpClient = new HttpClient();

            try
            {
                // Concatena a URL com o parâmetro recebido no método
                var urlComParametro = $"{API_CHARACTER}{name}";

                var request = new HttpRequestMessage(HttpMethod.Get, urlComParametro);

                var response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var character = JsonConvert.DeserializeObject<CharacterDTO>(content);

                //Caso o char não seja encontrado, o mesmo está sendo tratado no response da chamada da API, onde a partir do javascript irá disparar o erro em tela de char não encontrado.                
                return character;
            }
            catch (Exception ex)
            {
                return new CharacterDTO { ErrorMessage = ex.Message };         
            }
        }

        public async Task<PlayersOnlineDTO> GetPlayersOnline(string world)
        {
            var httpClient = new HttpClient();

            try
            {
                var urlComParametro = $"{API_PLAYERSONLINE}{world}";

                var request = new HttpRequestMessage(HttpMethod.Get, urlComParametro);

                var response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var playersOnline = JsonConvert.DeserializeObject<PlayersOnlineDTO>(content);

                return playersOnline;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
