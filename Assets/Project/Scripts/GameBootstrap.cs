using AnimalWorld.AnimalsConfig;
using Modules.ScreenBounds;
using UIRoot.Statistics;
using UnityEngine;

namespace Project
{
    // Почему Zeject / VContainer не использовались:
    // Для этого тестового задания использование стороннего DI избыточно.
    // Архитектура через Root-классы обеспечивает гибкость и расширяемость
    // без привязки к конкретной библиотеке.
    // Все зависимости инициализируются явно, что облегчает понимание кода и тестирование.

    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private AnimalsConfig _animalsConfig;
        [SerializeField] private Transform _animalsRoot;
        [SerializeField] private float _spawnIntervalMin = 1f;
        [SerializeField] private float _spawnIntervalMax = 2f; //TODO: config

        [Header("UI")]
        [SerializeField] private AnimalStatsUI _animalStatsUI;

        private AnimalWorld.Root _animalWorldRoot;

        private void Awake()
        {
            var screenBoundsRoot = new ScreenBoundsRoot(_camera);

            _animalWorldRoot = new AnimalWorld.Root(
                new AnimalWorld.Root.Context
                {
                    animalsConfig = _animalsConfig,
                    animalsRoot = _animalsRoot,
                    screenBounds = screenBoundsRoot.screenBounds,
                    spawnIntervalMin = _spawnIntervalMin,
                    spawnIntervalMax = _spawnIntervalMax
                }
            );

            var animalStatsUIRoot = new AnimalStatsUIRoot(_animalStatsUI, _animalWorldRoot.animalWorldStats);
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
