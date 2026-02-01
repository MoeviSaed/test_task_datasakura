using AnimalWorldRoot.AnimalsConfig;
using AnimalWorldRoot.Statistics;
using Modules.ScreenBounds;
using UIRoot.Statistics;
using UnityEngine;

namespace Project
{
    // Почему Zeject / VContainer не использовались:
    // Для этого тестового задания использование стороннего DI избыточно.
    // Архитектура через Root-классы и GameContext обеспечивает гибкость и расширяемость
    // без привязки к конкретной библиотеке.
    // Все зависимости инициализируются явно, что облегчает понимание кода и тестирование.
    
    // Добавление новых типов животных
    // Просто расширяешь AnimalType enum и добавляешь соответствующие классы животных.
    //     Статистика автоматически поддерживает новые типы через словари или событие смерти.
    
    public class GameBootstrap : MonoBehaviour
    {
        private IAnimalWorldStats _animalWorldStats => _animalWorldRoot.animalWorldStats;
        [SerializeField] private Camera _camera;
        [SerializeField] private AnimalsConfig _animalsConfig;
        [SerializeField] private Transform _animalsRoot;
        [SerializeField] private float _spawnIntervalMin = 1f;
        [SerializeField] private float _spawnIntervalMax = 2f; //TODO: config

        [Header("UI")]
        [SerializeField] private AnimalStatsUI _animalStatsUI;

        private AnimalStatsUIRoot _animalStatsUIRoot;
        private AnimalWorldRoot.AnimalWorldRoot _animalWorldRoot;

        private void Awake()
        {
            var screenBoundsRoot = new ScreenBoundsRoot(_camera);

            _animalWorldRoot = new AnimalWorldRoot.AnimalWorldRoot(
                _animalsConfig,
                _animalsRoot,
                screenBoundsRoot.screenBounds,
                _spawnIntervalMin,
                _spawnIntervalMax
            );

            _animalStatsUIRoot = new AnimalStatsUIRoot(_animalStatsUI, _animalWorldStats);
        }

        private void FixedUpdate()
        {
            _animalWorldRoot?.FixedTick(Time.deltaTime); //TODO: TickManager
        }

        private void Update()
        {
            _animalWorldRoot?.Tick(Time.deltaTime); //TODO: TickManager
        }
    }
}
