using UnityEngine;
using System.Collections;
using Game;

public static class GameSetting
{
    public static string StageName;
    public static int TimeLimit;
    public static int SlotCount;

    public static Player Player1 = new Player();
    public static Player Player2 = new Player();

    public class Player
    {
        public Team Team;
        public int MaxHP;
        public int Speed;

        public Player()
        {
            Team = Team.Red;
            MaxHP = 100;
            Speed = 5;
        }
    }
}
