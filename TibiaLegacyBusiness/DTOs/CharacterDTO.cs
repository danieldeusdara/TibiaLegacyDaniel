namespace TibiaLegacyBusiness.DTOs
{
    public class CharacterDTO
    {
        public Character character { get; set; }
        public Information information { get; set; }
        public string ErrorMessage { get; internal set; }

        public class Character
        {
            public List<AccountBadges> account_badges { get; set; }
            public AccountInformation account_information { get; set; }
            public List<Achievements> achievements { get; set; }

            public CharacterObject character { get; set; }

            public List<Deaths> deaths { get; set; }

            public bool deaths_truncated { get; set; }

            public List<OtherCharacters> other_characters { get; set; }
        }

        public class AccountBadges
        {
            public string description { get; set; }
            public string icon_url { get; set; }
            public string name { get; set; }
        }

        public class AccountInformation
        {
            public string created { get; set; }
            public string loyalty_title { get; set; }
            public string position { get; set; }
        }

        public class Achievements
        {
            public int grade { get; set; }
            public string name { get; set; }
            public bool secret { get; set; }
        }

        public class CharacterObject
        {
            public string account_status { get; set; }
            public int achievement_points { get; set; }
            public string comment { get; set; }
            public string deletion_date { get; set; }
            public string[] former_names { get; set; }
            public string[] former_worlds { get; set; }

            public Guild guild { get; set; }

            public List<Houses> houses { get; set; }
            public string last_login { get; set; }
            public int level { get; set; }
            public string married_to { get; set; }
            public string name { get; set; }
            public string position { get; set; }
            public string residence { get; set; }
            public string sex { get; set; }
            public string title { get; set; }
            public bool traded { get; set; }
            public int unlocked_titles { get; set; }
            public string vocation { get; set; }

            public string world { get; set; }
            public bool status { get; set; }
        }

        public class Guild
        {
            public string name { get; set; }
            public string rank { get; set; }
        }

        public class Houses
        {
            public int houseid { get; set; }
            public string name { get; set; }
            public string paid { get; set; }
            public string town { get; set; }
        }

        public class Deaths
        {
            public List<Assists> assists { get; set; }
            public List<Killers> killers { get; set; }
            public int level { get; set; }
            public string reason { get; set; }
            public string time { get; set; }
        }

        public class Assists
        {
            public string name { get; set; }
            public bool player { get; set; }
            public string summon { get; set; }
            public bool traded { get; set; }
        }

        public class Killers
        {
            public string name { get; set; }
            public bool player { get; set; }
            public string summon { get; set; }
            public bool traded { get; set; }
        }

        public class OtherCharacters
        {
            public bool deleted { get; set; }
            public bool main { get; set; }
            public string name { get; set; }
            public string position { get; set; }
            public string status { get; set; }
            public bool traded { get; set; }
            public string world { get; set; }
        }

        public class Information
        {
            public Api api { get; set; }
            public Status status { get; set; }

            public string[] tibia_urls { get; set; }
            public string timestamp { get; set; }
        }

        public class Api
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
    }
}
