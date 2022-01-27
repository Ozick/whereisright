using UnityEngine;
using System.Collections.Generic;

namespace whereisright
{
    public class RightAnswerSetter
    {
        private List<CardData> _pastQuests;

        public RightAnswerSetter()
        {
            _pastQuests = new List<CardData>();
        }

        public CardData GetNextQuest(CardData[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (_pastQuests.Contains(data[i]) == false)
                {
                    _pastQuests.Add(data[i]);
                    return data[i];
                }
                else
                {
                    continue;
                }
            }

            Debug.Log("Цели закончились. Начинаем заново!");

            _pastQuests.Clear();

            return GetNextQuest(data);
        }
    }
}