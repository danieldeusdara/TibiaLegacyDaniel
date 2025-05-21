using TibiaLegacyBusiness.DAL;
using TibiaLegacyBusiness.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TibiaLegacyBusiness.DTOs.CharacterDTO;

namespace TibiaLegacyBusiness.Servicos
{
    public class WorldPlayerServicos
    {
        public CharacterDTO GetCharacter(string name)
        {
            var character = new WorldPlayerDAO().GetCharacter(name).Result;

            if (character.character != null)
            {
                // Caso não exista outros characters no objeto retornado, significa que o usuário tem a conta bloqueada, sendo assim precisamos chamar um outro endpoint para
                // conseguir identificar se o player está online
                if (character.character.other_characters == null)
                {
                    var playersOnline = GetPlayersOnline(character.character.character.world);

                    if (playersOnline.world.online_players.Any())
                    {
                        var status = playersOnline.world.online_players.Find(x => x.name == name);

                        if (status != null)
                            character.character.character.status = true;
                        else
                            character.character.character.status = false;
                    }
                    else
                    {
                        character.ErrorMessage = $"Error in returning online players from {character.character.character.world}";
                        return character;
                    }
                }
                else
                    // O operador de navegação segura "?" é usado para evitar exceções de referência nula. Ele permite acessar propriedades ou métodos de um objeto mesmo se algum dos objetos na cadeia de chamadas for nulo. 
                    character.character.character.status = character.character.other_characters?.Find(x => x.name == name)?.status == "online" ? true : false;
            }
            else
                character.ErrorMessage = "Character not found!";

            return character;
        }

        public List<MundosDTO.RegularWorlds> GetMundos()
        {
            var listaMundos = new WorldPlayerDAO().GetMundos().Result.ToList();

            return listaMundos;
        }

        public PlayersOnlineDTO GetPlayersOnline(string world)
        {
            var playersOnline = new WorldPlayerDAO().GetPlayersOnline(world).Result;

            return playersOnline;
        }
    }
}
