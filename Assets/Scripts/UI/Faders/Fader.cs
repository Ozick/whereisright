using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace whereisright
{
    public abstract class Fader : MonoBehaviour
    {
        [SerializeField]
        private float _fadeDuration;

        [SerializeField]
        private float _fadeInValue;

        [SerializeField]
        private float _fadeOutValue;

        [SerializeField]
        private UnityEvent BeforeFadeIn;

        [SerializeField]
        private UnityEvent BeforeFadeOut;

        [SerializeField]
        private UnityEvent AfterFadeIn;

        [SerializeField]
        private UnityEvent AfterFadeOut;

        public void FadeIn()
        {
            BeforeFadeIn?.Invoke();

            Sequence sequence = DOTween.Sequence();

            sequence.Append(Fade(_fadeInValue, _fadeDuration));

            sequence.AppendCallback(() =>
            {
                AfterFadeIn?.Invoke();
            });

            sequence.Play();
        }

        public void FadeOut()
        {
            BeforeFadeOut?.Invoke();

            Sequence sequence = DOTween.Sequence();

            sequence.Append(Fade(_fadeOutValue, _fadeDuration));

            sequence.AppendCallback(() =>
            {
                AfterFadeOut?.Invoke();
            });

            sequence.Play();
        }

        protected abstract Tween Fade(float value, float duration);
    }
}