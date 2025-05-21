using TibiaLegacyBusiness.DAL;
using TibiaLegacyBusiness.DTOs;

namespace TibiaLegacyBusiness.Servicos
{
    public class LegacyServicos
    {      
        public CriaturasDTO.Boostado GetCriaturaBoostada()
        {
            var boostado = new LegacyDAO().GetCriaturaBoostada().Result;

            return boostado;
        }

        public BossBoostadoDTO.Boosted GetBossBoostado()
        {
            var bossBoostado = new LegacyDAO().GetBossBoostado().Result;

            return bossBoostado;
        }
    }
}
