using AnimalWorldRoot.Statistics;
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

            _text.text = string.Empty;

            _text.text += $"Prey dead: {_stats.DeadPreyCount}\n";
            _text.text += $"Predators dead: {_stats.DeadPredatorCount}\n";
        }
    }
}
