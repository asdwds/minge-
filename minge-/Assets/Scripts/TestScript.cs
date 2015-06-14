using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    public class TestScript : MonoBehaviour
    {
        public void Awake()
        {
        }

        public void Start()
        {
            GameSetting.StageName = "Test";
            GameSetting.TimeLimit = 30;
            GameSetting.SlotCount = 10;
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Application.LoadLevel("TestStage");
            }
        }
    }
}