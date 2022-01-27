using UnityEngine;

namespace whereisright
{
    [System.Serializable]
    public class LevelData
    {
        [SerializeField]
        private int _rows;

        [SerializeField]
        private int _columns;

        public int Rows => _rows;

        public int Columns => _columns;

        public int CellsCount => _rows * _columns;
    }
}