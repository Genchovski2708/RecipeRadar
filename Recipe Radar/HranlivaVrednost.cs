using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Radar
{
    public class HranlivaVrednost
    {
        public enum EnergyType
        {
            Kcal,
            Kj
        }

        public enum WeightType
        {
            Gram,
            Pounds
        }

        public Dictionary<string, float> NutritionalTypes { get; set; }
        public float Weight { get; set; }
        public WeightType WeightUnit { get; set; }
        public EnergyType EnergyUnit { get; set; }
        public float Energy { get; set; }
        public HranlivaVrednost(Dictionary<string, float> nutritionalTypes, float weight, WeightType weightUnit, EnergyType energyUnit, float energy)
        {
            NutritionalTypes = nutritionalTypes;
            Weight = weight;
            WeightUnit = weightUnit;
            EnergyUnit = energyUnit;
            Energy = energy;
        }
    }
}
