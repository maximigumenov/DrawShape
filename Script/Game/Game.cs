using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] LevelData levels;
        [SerializeField] GameResource objectsGame;
        [SerializeField] MouseBehaviour mouse;
        [SerializeField] Timer timer;
        [SerializeField] Score score;
        [SerializeField] Score gameOverScore;
        [SerializeField] GameObject gameOverObject;
        [Header("Time Data")]
        [SerializeField]
        int second = 30;
        [SerializeField] int step = 5;
        [SerializeField] int min = 1;

        int _second = 0;

        private void Start()
        {
            Setting.SetOrthographic();
            _second = second;
            StartData();
        }

        private void StartData()
        {
            TimerData timerData = new TimerData();
            timerData.second = second;
            timer.SetData(timerData);
        }

        private void Update()
        {
            GameControl();
            ExitGame();
        }

        private void GameControl()
        {
            if (GameData.gameAction == GameData.GameAction.Game)
            {
                mouse.Update();
                objectsGame.cursor.SetMove();
                timer.UpdateTimer();
            }
            else if (GameData.gameAction == GameData.GameAction.GameOver)
            {
                Lose();
            }
        }

        private void ExitGame() {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        public void StartButton()
        {
            levels.Init();
            ShowShape();
            UnityEvent nextLevelEvent = new UnityEvent();
            nextLevelEvent.AddListener(() => ShowShape());
            nextLevelEvent.AddListener(() => Win());
            mouse.nextLevel = nextLevelEvent;
            mouse.SetData(levels.GetDataShape());
            objectsGame.buttonStart.gameObject.SetActive(false);
            gameOverObject.SetActive(false);
            GameData.score = 0;
            score.SetScore();
            GameData.gameAction = GameData.GameAction.Game;
        }

        public void ShowShape()
        {
            second -= step;
            if (second < min)
            {
                second = min;
            }
            TimerData timerData = new TimerData();
            timerData.second = second;
            timer.SetData(timerData);
            levels.NextLevel(objectsGame);
            mouse.SetData(levels.GetDataShape());
        }

        public void Win()
        {
            GameData.score++;
            score.SetScore();
        }

        public void Lose()
        {
            GameData.gameAction = GameData.GameAction.Start;
            second = _second;
            objectsGame.cursor.DeActiveParticle();
            gameOverScore.SetScore();
            gameOverObject.SetActive(true);
            StartData();
        }

    }
}
