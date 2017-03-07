using RQEnchant.PropertyData;

namespace RQEnchant.Core
{
    public abstract class RoadCalculatorBase : IRoadCalculator
    {
        protected EnchCalcResult EnchCalcResult { get; }

        protected RoadCalculatorBase(EnchPropertyData enchProperyData, StonePrices stonePrice)
        {
            EnchCalcResult = new EnchCalcResult(enchProperyData, stonePrice);
        }

        public abstract EnchCalcResult Calculate(int startLvl, int endLvl);

    }
}