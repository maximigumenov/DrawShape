using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class GameData
{
    public enum GameAction { Start, Game, GameOver }
    public static GameAction gameAction = GameAction.Start;
    public static int score = 0;
}

