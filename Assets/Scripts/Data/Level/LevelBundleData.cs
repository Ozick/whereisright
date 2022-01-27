using UnityEngine;

namespace whereisright
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "Level Data")]
    class LevelBundleData : ScriptableObject
    {
        [SerializeField]
        private LevelData[] _levels;

        public LevelData[] Levels => _levels;
    }
}