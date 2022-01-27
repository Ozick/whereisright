using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace whereisright
{
    public class ImageFader : Fader
    {
        [SerializeField]
        private Image _image;

        protected override Tween Fade(float value, float duration)
        {
            return _image.DOFade(value, duration);
        }
    }
}