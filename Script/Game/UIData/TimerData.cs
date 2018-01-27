using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class TimerData
    {
        public bool isTime = false;
        public int second = 0;
        public int millisecond = 0;
        int step = 2;

        public void MinusStep()
        {
            millisecond -= step;
            if (millisecond < 0)
            {
                millisecond = 98;
                if (second > 0)
                {
                    second--;
                }
                else
                {
                    StopTimer();
                }
            }
        }

        void StopTimer()
        {
            second = 0;
            millisecond = 0;
            isTime = false;
            GameData.gameAction = GameData.GameAction.GameOver;
        }
    }
}
