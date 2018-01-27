using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Score : MonoBehaviour
    {
        [SerializeField] Text scoreText;

        public void SetScore()
        {
            scoreText.text = GameData.score.ToString("00");
        }
    }
}
