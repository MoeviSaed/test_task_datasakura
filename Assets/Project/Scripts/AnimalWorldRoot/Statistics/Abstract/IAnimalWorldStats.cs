using System;

namespace AnimalWorld.Statistics
{
    public interface IAnimalWorldStats
    {
        event Action OnStatsChanged;

        int DeadPreyCount { get; }
        int DeadPredatorCount { get; }
    }
}
