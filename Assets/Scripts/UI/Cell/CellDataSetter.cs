using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace whereisright
{
    public class CellDataSetter : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Button _button;

        [SerializeField]
        private RectTransform _rect;

        [SerializeField]
        private UnityEvent _onRightAnswer;

        [SerializeField]
        private UnityEvent _onWrongAnswer;

        private CardData _data;

        public void SetData(CardData data)
        {
            _icon.sprite = data.Icon;

            if (data.Rotate)
            {
                _rect.rotation = Quaternion.Euler(0, 0, -90);
            }

            _data = data;
        }

        public void SetClickCallback(AnswerChecker.OnClick callback)
        {
            _button.onClick.AddListener(() =>
            {
                if ((bool)callback?.Invoke(_data))
                {
                    _onRightAnswer?.Invoke();
                }
                else
                {
                    _onWrongAnswer?.Invoke();
                }
            });
        }
    }
}