using System;
using System.Collections.Generic;
using System.Text;

namespace uJudge.Model
{
    public class MainViewModel
    {
        public RedFighterScores RedFighterScores;
        public BlueFighterScores BlueFighterScores;

        public MainViewModel()
        {
            RedFighterScores = new RedFighterScores();
            BlueFighterScores = new BlueFighterScores();
        }
    }
}
