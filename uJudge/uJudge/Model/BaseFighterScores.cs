using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace uJudge.Model
{
    public class BaseFighterScores : INotifyPropertyChanged
    {
        Dictionary<int, List<DateTime>> scoreTimeMap;
        int lastScore;
        DateTime lastUpdateTime;
        Dictionary<int, int> scoreSumMap;

        public BaseFighterScores()
        {
            scoreTimeMap = new Dictionary<int, List<DateTime>>();
            scoreTimeMap.Add(1, new List<DateTime>());
            scoreTimeMap.Add(2, new List<DateTime>());
            scoreTimeMap.Add(3, new List<DateTime>());
            scoreSumMap = new Dictionary<int, int>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddScore(int score)
        {
            lastScore = score;
            lastUpdateTime = DateTime.Now;
            
            var list = scoreTimeMap[score];
            list.Add(lastUpdateTime);
            updateScoreSumMap();

            string propertyName = null;
            switch(score)
            {
                case 1:
                    propertyName = "OneSum";
                    break;
                case 2:
                    propertyName = "TwoSum";
                    break;
                case 3:
                    propertyName = "ThreeSum";
                    break;
            }

            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CancelLastScore()
        {
            foreach (KeyValuePair<int, List<DateTime>> item in scoreTimeMap)
            {
                if (item.Value.Contains(lastUpdateTime))
                {
                    item.Value.Remove(lastUpdateTime);
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Score"));
                    }
                    break;
                }
            }

            updateScoreSumMap();
        }

        public Dictionary<int, int> updateScoreSumMap()
        {
            scoreSumMap = new Dictionary<int, int>();

            foreach (KeyValuePair<int, List<DateTime>> item in scoreTimeMap)
            {
                scoreSumMap.Add(item.Key, item.Value.Count * item.Key);
            }

            return scoreSumMap;
        }


        public int ThreeSum { get => scoreSumMap.ContainsKey(3) ? scoreSumMap[3] : 0;  }
        public int TwoSum { get => scoreSumMap.ContainsKey(2) ? scoreSumMap[2] : 0; }
        public int OneSum { get => scoreSumMap.ContainsKey(1) ? scoreSumMap[1] : 0; }

    }
}
