using TibiaLegacyBusiness.DAL;
using TibiaLegacyBusiness.DTOs;
using Inflector;

namespace TibiaLegacyBusiness.Servicos
{
    public class CriaturasServicos
    {
        public List<CriaturasDTO.CreatureList> GetCriaturas()
        {
            var listaCriaturas = new CriaturasDAO().GetCriaturas().Result.ToList();

            var listaNomesErro = new List<CriaturasDTO.CreatureList>();

            foreach (var item in listaCriaturas)
            {
                string originalName = item.name; // Armazena o valor original
                string singularized = item.name.Singularize();

                if (!string.IsNullOrEmpty(singularized))
                {
                    item.name = singularized;
                }
                else
                {
                    item.name = originalName; // Rollback caso fique nulo
                    listaNomesErro.Add(item);
                }
            }

            PluralParaSingular(listaNomesErro);

            return listaCriaturas;
        }

        private static List<CriaturasDTO.CreatureList> PluralParaSingular(List<CriaturasDTO.CreatureList> lista)
        {
            string[] palavras;

            foreach (var item in lista)
            {
                palavras = item.name.Split(' ');

                for (int i = 0; i < palavras.Length; i++)
                {
                    string singular = palavras[i].Singularize();
                    // Se a conversão não retornar nulo ou a mesma palavra, substituímos
                    if (!string.IsNullOrEmpty(singular) && singular != palavras[i])
                    {
                        palavras[i] = singular;
                        break; // Para no primeiro plural encontrado
                    }
                }

                var teste = string.Join(" ", palavras);
                item.name = teste;
            }

            // Reconstroi a frase
            return lista;
        }
    }
}
