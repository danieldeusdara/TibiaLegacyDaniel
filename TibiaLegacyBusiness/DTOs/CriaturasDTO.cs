namespace TibiaLegacyBusiness.DTOs
{
    public class CriaturasDTO
    {
        public Criaturas creatures { get; set; }

        public class Criaturas
        {
            public Boostado boosted { get; set; }
            public List<CreatureList> creature_list { get; set; }
        }

        public class Boostado
        {
            public string name { get; set; }
            public string race { get; set; }
            public string image_url { get; set; }
            public bool featured { get; set; }
        }

        public class CreatureList
        {
            public string name { get; set; }
            public string race { get; set; }
            public string image_url { get; set; }
            public bool featured { get; set; }
        }
    }
}
