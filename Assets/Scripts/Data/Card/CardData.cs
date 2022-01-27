using UnityEngine;

namespace whereisright
{
    [System.Serializable]
    public class CardData
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private bool _rotate;

        public string ID => _id;

        public Sprite Icon => _icon;

        public bool Rotate => _rotate;
    }
}