using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] Text textTimer;
        TimerData timer = new TimerData();

        private void FixedUpdate()
        {
            if (GameData.gameAction == GameData.GameAction.Game)
            {
                UpdateTimer();
            }
        }

        public void SetData(TimerData timerData)
        {
            timer = timerData;
            timer.isTime = true;
            OutText();
        }

        public void UpdateTimer()
        {
            if (timer.isTime)
            {
                timer.MinusStep();
                OutText();
            }
        }

        void OutText()
        {
            textTimer.text = timer.second.ToString("00") + " : " + timer.millisecond.ToString("00");
        }
    }
}
