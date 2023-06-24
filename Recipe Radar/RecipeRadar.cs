using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Radar
{
    public class RecipeRadar
    {
        private DatabaseContext dbContext; // Објект за пристап до базата на податоци
        private MachineLearningModel recommendationModel; // Објект за модел на препораки

        public RecipeRadar(DatabaseContext context, MachineLearningModel model)
        {
            dbContext = context;
            recommendationModel = model;
        }

        public Obrok GenerirajObrok(List<Sostojka> sostojki)
        {
            // Логика за генерирање на оброкот на база на внесените состојки

            // Пример:
            List<Recept> primerkiRecepti = PronajdiReceptiSostojki(sostojki);

            if (primerkiRecepti.Count > 0)
            {
                // Користи моделот за препораки за да добиете најрелевантните рецепти
                List<Recept> preporacaniRecepti = recommendationModel.PredvidiPreporacaniRecepti(primerkiRecepti);

                // Избери случаен рецепт од препорачаните
                Random random = new Random();
                int randomIndex = random.Next(0, preporacaniRecepti.Count);
                Recept izbranRecept = preporacaniRecepti[randomIndex];

                // Создади објект од класата Obrok со податоците од избраниот рецепт и врати го
                Obrok generiranObrok = new Obrok(sostojki, izbranRecept);
                return generiranObrok;
            }
            else
            {
                return null;
            }
        }

        private List<Recept> PronajdiReceptiSostojki(List<Sostojka> sostojki)
        {
            // Логика за пребарување на рецепти со внесените состојки

            // Пример:
            List<Recept> primerkiRecepti = new List<Recept>();

            foreach (Sostojka sostojka in sostojki)
            {
                // Пребарај рецепти со внесената состојка во базата на податоци
                List<Recept> recepti = dbContext.Recepti
                    .Where(r => r.Sostojki.Any(s => s.Ime == sostojka.Ime))
                    .ToList();

                primerkiRecepti.AddRange(recepti);
            }

            return primerkiRecepti;
        }
    }
}
