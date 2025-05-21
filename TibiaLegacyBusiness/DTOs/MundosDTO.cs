namespace TibiaLegacyBusiness.DTOs
{
    public class MundosDTO
    {
        public Mundos Worlds { get; set; }

        public class Mundos
        {
            public int players_online { get; set; }
            public string record_date { get; set; }
            public int record_players { get; set; }
            public List<RegularWorlds> regular_worlds { get; set; }
        }

        public class RegularWorlds
        {
            public string battleye_date { get; set; }
            public bool battleye_protected { get; set; }
            public string game_world_type { get; set; }
            public string location { get; set; }
            public string name { get; set; }
            public int players_online { get; set; }
            public bool premium_only { get; set; }
            public string pvp_type { get; set; }
            public string status { get; set; }
            public string tournament_world_type { get; set; }
            public string transfer_type { get; set; }
        }
    }
}
