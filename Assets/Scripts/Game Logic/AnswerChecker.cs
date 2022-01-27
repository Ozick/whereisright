using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace whereisright
{
    public class AnswerChecker : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onRightAnswer;

        [SerializeField]
        private UnityEvent _onQuestSet;

        [SerializeField]
        private float _nextLevelDelay;

        [SerializeField]
        private LevelsPipeline _levels;

        private CardData _quest;

        public CardData RightAnswer => _quest;

        public delegate bool OnClick(CardData data);

        public void SetQuest(CardData data)
        {
            _quest = data;

            _onQuestSet?.Invoke();
        }

        public bool CheckAnswer(CardData data) => _quest.Equals(data);

        public bool OnCellClick(CardData data)
        {
            if (CheckAnswer(data))
            {
                StartCoroutine(NextLevelDelay(_nextLevelDelay));

                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerator NextLevelDelay(float time)
        {
            yield return new WaitForSeconds(time);

            if (_levels.TryNextLevel())
            {
                _onRightAnswer?.Invoke();
            }
        }
    }
}