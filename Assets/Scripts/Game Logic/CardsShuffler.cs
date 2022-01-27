using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace whereisright
{
    public class CardsShuffler : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onShuffleCard;

        [SerializeField]
        private CardBundleData[] _dataBundles;

        [SerializeField]
        private AnswerChecker _checker;

        [SerializeField]
        private LevelsPipeline _levels;

        private CardData[] _currentData;

        public CardData[] CurrentData => _currentData;

        private RightAnswerSetter _answerSetter;

        private void Start()
        {
            _answerSetter = new RightAnswerSetter();

            ShuffleCards();
        }

        public void ShuffleCards()
        {
            CardData[] data = _dataBundles[Random.Range(0, _dataBundles.Length)].CardData;

            CardData quest = _answerSetter.GetNextQuest(data);
            _checker.SetQuest(quest);

            CardData[] shuffledData = Shuffle(data);
            List<CardData> resizedData = Resize(shuffledData, _levels.GetCurrentLevelData().CellsCount).ToList();

            if (resizedData.Contains(quest) == false)
            {
                resizedData[Random.Range(0, resizedData.Count)] = quest;
            }

            _currentData = resizedData.ToArray();

            _onShuffleCard?.Invoke();
        }

        private CardData[] Shuffle(CardData[] data)
        {
            for (int i = data.Length - 1; i >= 0; i--)
            {
                int j = Random.Range(0, i + 1);
                CardData temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }

            return data;
        }

        private CardData[] Resize(CardData[] data, int size)
        {
            if (data.Length < size)
            {
                throw new System.IndexOutOfRangeException("The new array length is longer than the actual length.");
            }

            CardData[] newData = new CardData[size];

            for (int i = 0; i < size; i++)
            {
                newData[i] = data[i];
            }

            return newData;
        }
    }
}