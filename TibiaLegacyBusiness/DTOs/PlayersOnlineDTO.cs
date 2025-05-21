namespace TibiaLegacyBusiness.DTOs
{
    public class PlayersOnlineDTO
    {
        public Information information { get; set; }
        public World world { get; set; }
        public string ErrorMessage { get; internal set; }
    }

    public class Information
    {
        public API api { get; set; }
        public Status status { get; set; }
        public string[] tibia_urls { get; set; }
        public string timestamp { get; set; }
    }

    public class API
    {
        public string commit { get; set; }
        public string release { get; set; }
        public int version { get; set; }
    }

    public class Status
    {
        public int error { get; set; }
        public int http_code { get; set; }
        public string message { get; set; }
    }

    public class World
    {
        public string battleye_data { get; set; }
        public bool battleye_protected { get; set; }
        public string creation_date { get; set; }
        public string game_world_type { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public List<OnlinePlayers> online_players { get; set; }
        public int players_online { get; set; }
        public bool premium_only { get; set; }
        public string pvp_type { get; set; }
        public string record_date { get; set; }
        public int record_players {  get; set; }
        public string status { get; set; }
        public string tournament_world_type { get; set; }
        public string transfer_type { get; set; }
        public string[] world_quests_titles { get; set; }
    }

    public class OnlinePlayers
    {
        public int level { get; set; }
        public string name { get; set; }
        public string vocation { get; set; }
    }
}
