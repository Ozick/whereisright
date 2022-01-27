using UnityEngine;
using UnityEngine.UI;

namespace whereisright
{
    public class QuestText : MonoBehaviour
    {
        [SerializeField]
        private Text _questText;

        [SerializeField]
        private string _questStartText;

        [SerializeField]
        private AnswerChecker _checker;

        public void SetQuest()
        {
            _questText.text = _questStartText + " " + _checker.RightAnswer.ID;
        }
    }
}