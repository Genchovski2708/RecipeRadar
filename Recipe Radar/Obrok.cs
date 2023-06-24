namespace Recipe_Radar
{
    public class Obrok
    {
        public List<Sostojka> Sostojki { get; set; }
        public HranlivaVrednost HranlivaVrednost { get; private set; }
        public Recept Recept { get; private set; }

        public Obrok(List<Sostojka> sostojki, Recept recept)
        {
            Sostojki = sostojki;
            Recept = recept;
            HranlivaVrednost = PresmetajHranlivaVrednost();
        }

        public void NacinNaPodgotovka()
        {
            Console.WriteLine("Nacin na podgotovka:");
            Console.WriteLine(Recept.Instrukcii);
        }

        private HranlivaVrednost PresmetajHranlivaVrednost()
        {
            float energySum = 0;
            float weightSum = 0;
            HranlivaVrednost.EnergyType energyType = Sostojki.FirstOrDefault()?.HranlivaVrednost.EnergyUnit ?? HranlivaVrednost.EnergyType.Kcal;
            HranlivaVrednost.WeightType weightType = Sostojki.FirstOrDefault()?.HranlivaVrednost.WeightUnit ?? HranlivaVrednost.WeightType.Gram;
            Dictionary<string, float> nutritionalTypes = new Dictionary<string, float>();

            foreach (Sostojka sostojka in Sostojki)
            {
                HranlivaVrednost hranlivaVrednost = sostojka.HranlivaVrednost;

                // Конверзија на енергетската вредност
                float convertedEnergy = ConvertEnergyValue(hranlivaVrednost.Energy, hranlivaVrednost.EnergyUnit, energyType);

                // Конверзија на тежината
                float convertedWeight = ConvertWeightValue(hranlivaVrednost.Weight, hranlivaVrednost.WeightUnit, weightType);

                energySum += convertedEnergy;
                weightSum += convertedWeight;

                // Собирање на нутритивните вредности
                foreach (KeyValuePair<string, float> nutritionalType in hranlivaVrednost.NutritionalTypes)
                {
                    if (nutritionalTypes.ContainsKey(nutritionalType.Key))
                    {
                        nutritionalTypes[nutritionalType.Key] += nutritionalType.Value;
                    }
                    else
                    {
                        nutritionalTypes.Add(nutritionalType.Key, nutritionalType.Value);
                    }
                }
            }

            return new HranlivaVrednost(nutritionalTypes, weightSum, weightType, energyType, energySum);
        }

        private float ConvertEnergyValue(float value, HranlivaVrednost.EnergyType sourceUnit, HranlivaVrednost.EnergyType targetUnit)
        {
            if (sourceUnit == targetUnit)
            {
                return value;
            }

            if (sourceUnit == HranlivaVrednost.EnergyType.Kcal && targetUnit == HranlivaVrednost.EnergyType.Kj)
            {
                return value * 4.184f;
            }
            else if (sourceUnit == HranlivaVrednost.EnergyType.Kj && targetUnit == HranlivaVrednost.EnergyType.Kcal)
            {
                return value / 4.184f;
            }

            throw new ArgumentException("Invalid energy unit conversion.");
        }

        private float ConvertWeightValue(float value, HranlivaVrednost.WeightType sourceUnit, HranlivaVrednost.WeightType targetUnit)
        {
            if (sourceUnit == targetUnit)
            {
                return value;
            }

            if (sourceUnit == HranlivaVrednost.WeightType.Gram && targetUnit == HranlivaVrednost.WeightType.Pounds)
            {
                return value / 453.6f;
            }
            else if (sourceUnit == HranlivaVrednost.WeightType.Pounds && targetUnit == HranlivaVrednost.WeightType.Gram)
            {
                return value * 453.6f;
            }

            throw new ArgumentException("Invalid weight unit conversion.");
        }
    }
}