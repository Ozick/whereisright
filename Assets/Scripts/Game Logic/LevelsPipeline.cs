using UnityEngine;
using UnityEngine.Events;

namespace whereisright
{
    public class LevelsPipeline : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onRestart;

        [SerializeField]
        private UnityEvent _onEndLevel;

        [SerializeField]
        private LevelBundleData _levels;

        private int _currentLevel;

        public int GetCurrentLevel => _currentLevel;

        public bool TryNextLevel()
        {
            if (_currentLevel + 1 < _levels.Levels.Length)
            {
                _currentLevel++;

                return true;
            }
            else
            {
                _onEndLevel?.Invoke();

                return false;
            }
        }

        public LevelData GetCurrentLevelData() => _levels.Levels[_currentLevel];

        public void Restart()
        {
            _currentLevel = 0;

            _onRestart?.Invoke();
        }
    }
}