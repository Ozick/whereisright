using UnityEngine;

namespace whereisright
{
    [CreateAssetMenu(fileName = "New Card Bundle", menuName = "Card Bundle Data")]
    class CardBundleData : ScriptableObject
    {
        [SerializeField]
        private CardData[] _cardData;

        public CardData[] CardData => _cardData;
    }
}