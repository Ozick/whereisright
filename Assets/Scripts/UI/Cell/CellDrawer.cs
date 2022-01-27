using UnityEngine;

namespace whereisright
{
    public class CellDrawer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cell;

        [SerializeField]
        private GameObject _row;

        [SerializeField]
        private CardsShuffler _shuffler;

        [SerializeField]
        private LevelsPipeline _levels;

        [SerializeField]
        private AnswerChecker _checker;

        private void Start()
        {
            DG.Tweening.DOTween.Init();
        }

        public void DrawCard()
        {
            DrawCells(_shuffler.CurrentData, _levels.GetCurrentLevelData());
        }

        private void DrawCells(CardData[] data, LevelData level)
        {
            if (data.Length != level.CellsCount)
            {
                throw new System.Exception("The number of cards does not match the level.");
            }

            DestroyAllChilds();

            int index = 0;

            for (int y = 0; y < level.Rows; y++)
            {
                GameObject row = Instantiate(_row, transform);

                for (int x = 0; x < level.Columns; x++)
                {
                    CardData cellData = data[index++];
                    DrawCell(cellData, row.transform);
                }
            }
        }

        // Это нужно отдельным методом, чтобы указать этот метод в инспекторе события BlackScreen.AfterFadeIn
        public void DestroyAllChilds()
        {
            transform.DestroyAllChilds();
        }

        private void DrawCell(CardData data, Transform parent)
        {
            GameObject cellObject = Instantiate(_cell, parent);

            CellDataSetter cell = cellObject.GetComponent<CellDataSetter>();

            cell.SetData(data);
            cell.SetClickCallback(_checker.OnCellClick);

            // Эффект появления ячеек через bounce при запуске 1-го уровня
            if (_levels.GetCurrentLevel == 0)
            {
                cell.GetComponent<CellAnimator>().Rise();
            }
        }
    }
}