using UnityEngine;
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace whereisright
{
    public class CellAnimator : MonoBehaviour
    {
        [Header("Shake")]

        [SerializeField]
        private float _shakeDuration;

        [SerializeField]
        private float _shakeStrength;

        [Header("Bounce")]

        [SerializeField]
        private float _bounceDuration;

        [SerializeField]
        [Range(0, 1)]
        private float _bounceStrength;

        [Header("Rise")]

        [SerializeField]
        private float _riseDuration;

        [SerializeField]
        [Range(0, 1)]
        private float _riseStrength;

        public void Shake()
        {
            transform.DOShakePosition(_shakeDuration, Vector3.right * _shakeStrength).SetEase(Ease.InBounce);
        }

        public void Bounce()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DOScale(1 + _bounceStrength, _bounceDuration / 4).SetEase(Ease.InOutQuad));
            sequence.Append(transform.DOScale(1 - _bounceStrength, _bounceDuration / 2).SetEase(Ease.InOutQuad));
            sequence.Append(transform.DOScale(1f, _bounceDuration / 4).SetEase(Ease.InOutQuad));

            sequence.Play();
        }

        public void Rise()
        {
            transform.localScale = Vector3.one * _riseStrength;
            transform.DOScale(1, _riseDuration).SetEase(Ease.OutBounce);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CellAnimator))]
    public class CellAnimatorInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Shake"))
            {
                ((CellAnimator)target).Shake();
            }

            if (GUILayout.Button("Bounce"))
            {
                ((CellAnimator)target).Bounce();
            }

            if (GUILayout.Button("Rise"))
            {
                ((CellAnimator)target).Rise();
            }

            if (GUILayout.Button("Reset scale"))
            {
                ((CellAnimator)target).transform.localScale = Vector3.one;
            }
        }
    }
}
#endif