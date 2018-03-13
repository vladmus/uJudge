using System;
using System.Collections.Generic;
using System.Text;

namespace uJudge.Model
{
    class BaseFighterScores
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

        public void AddScore(int score)
        {
            lastScore = score;
            lastUpdateTime = DateTime.Now;
            
            var list = scoreTimeMap[score];
            list.Add(lastUpdateTime);               
        }

        public void CancelLastScore()
        {
            foreach (KeyValuePair<int, List<DateTime>> item in scoreTimeMap)
            {
                if (item.Value.Contains(lastUpdateTime))
                {
                    item.Value.Remove(lastUpdateTime);
                    break;
                }
            }
        }

        public Dictionary<int, int> getScoreSumMap()
        {
            foreach (KeyValuePair<int, List<DateTime>> item in scoreTimeMap)
            {
                scoreSumMap.Add(item.Key, item.Value.Count * item.Key);
            }

            return scoreSumMap;
        }

    }
}
