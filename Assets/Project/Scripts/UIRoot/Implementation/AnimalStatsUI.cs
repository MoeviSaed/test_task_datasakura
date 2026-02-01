using AnimalWorld.Statistics;
using TMPro;
using UnityEngine;

namespace UIRoot.Statistics
{
    public class AnimalStatsUI
        : MonoBehaviour,
          IStatsUI
    {
        [SerializeField] private TextMeshProUGUI _text;

        private IAnimalWorldStats _stats;

        public void Init(IAnimalWorldStats stats)
        {
            _stats = stats;
            _stats.OnStatsChanged += UpdateView;
            UpdateView();
        }

        private void OnDestroy()
        {
            if (_stats != null)
            {
                _stats.OnStatsChanged -= UpdateView;
            }
        }

        private void UpdateView()
        {
            if (_stats == null)
            {
                return;
            }

            _text.SetText("Prey dead: {0}\nPredators dead: {1}", 
                _stats.DeadPreyCount, 
                _stats.DeadPredatorCount);
        }
    }
}
