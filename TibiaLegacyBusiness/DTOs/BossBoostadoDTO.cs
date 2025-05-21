namespace TibiaLegacyBusiness.DTOs
{
    public class BossBoostadoDTO
    {
        public BossesBoostado boostable_bosses { get;set; }
        public InformationBosses information { get;set; }

        public class BossesBoostado
        {
            public List<BossesBoostadoList> boostable_boss_list { get; set; }
            public Boosted boosted {  get; set; }
        }

        public class BossesBoostadoList
        {
            public bool featured { get; set; }
            public string image_url { get; set; }
            public string name { get; set; }
        }

        public class Boosted
        {
            public string name { get; set; }
            public string image_url { get; set; }
            public bool featured { get; set; }
        }

        public class InformationBosses
        {
            public ApiBosses api { get; set; }
            public StatusBosses status { get; set; }
            public string[] tibia_urls { get; set; }
            public string timestamp { get; set; }
        }

        public class ApiBosses
        {
            public string commit { get; set; }
            public string release { get; set; }
            public int version { get; set; }
        }

        public class StatusBosses
        {
            public int error { get; set; }
            public int http_code { get; set; }
            public string message { get; set; }
        }
    }
}
