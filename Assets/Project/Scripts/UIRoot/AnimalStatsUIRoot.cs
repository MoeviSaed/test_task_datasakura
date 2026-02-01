using AnimalWorld.Statistics;

namespace UIRoot.Statistics
{
    public class AnimalStatsUIRoot
    {
        private readonly IStatsUI _statsUI;

        public AnimalStatsUIRoot(IStatsUI statsUI, IAnimalWorldStats stats)
        {
            _statsUI = statsUI;
            _statsUI.Init(stats);
        }
    }
}
