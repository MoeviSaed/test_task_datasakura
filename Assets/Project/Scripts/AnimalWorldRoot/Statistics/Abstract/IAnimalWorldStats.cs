using System;
using System.Collections.Generic;
using AnimalWorldRoot.AnimalsConfig;

namespace AnimalWorldRoot.Statistics
{
    public interface IAnimalWorldStats
    {
        event Action OnStatsChanged;

        int DeadPreyCount { get; }
        int DeadPredatorCount { get; }
        IReadOnlyDictionary<AnimalType, int> countByType { get; }
    }
}
