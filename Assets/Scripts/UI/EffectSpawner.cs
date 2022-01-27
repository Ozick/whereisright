using UnityEngine;

namespace whereisright
{
    public class EffectSpawner : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particles;

        public void Spawn()
        {
            _particles.Play();
        }
    }
}