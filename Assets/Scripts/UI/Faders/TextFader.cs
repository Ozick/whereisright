using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace whereisright
{
    public class TextFader : Fader
    {
        [SerializeField]
        private Text _text;

        protected override Tween Fade(float value, float duration)
        {
            return _text.DOFade(value, duration);
        }
    }
}