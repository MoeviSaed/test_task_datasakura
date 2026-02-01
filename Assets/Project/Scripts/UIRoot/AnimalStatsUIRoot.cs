using AnimalWorldRoot.Statistics;

namespace UIRoot.Statistics
{
    public class AnimalStatsUIRoot
    {
        private readonly IStatsUI _ui;

        public AnimalStatsUIRoot(IStatsUI ui, IAnimalWorldStats stats)
        {
            _ui = ui;
            _ui.Init(stats);
        }
    }
}
