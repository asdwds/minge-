using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Game;

namespace Game
{
    public class OfflineGameManager : MonoBehaviour
    {
        public PlayerController Player1;
        public PlayerController Player2;

        public PlayerController[] Players;

        private float elapsedTime = 0;

        private bool isStarted = false;
        private bool isFinished = false;

        private bool isPaused = false;

        public void Awake()
        {
            Stage.Load(GameSetting.StageName);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            Player1 = players[0].GetComponent<PlayerController>();
            Player1.Initialize(GameSetting.Player1, GameSetting.SlotCount);

            Player2 = players[1].GetComponent<PlayerController>();
            Player2.Initialize(GameSetting.Player2, GameSetting.SlotCount);

            for(var i = 0;i < players.Length;i++)
            {
                Players[i] = players[i].GetComponent<PlayerController>();
            }
        }

        public void Start()
        {
        }

        public void Update()
        {
            if (isPaused)
            {
                elapsedTime += Time.fixedDeltaTime;

                //シーンがロードされてから4秒経ってからゲームを開始する
                if (!isStarted && 4 < elapsedTime)
                {
                    isStarted = true;
                    SwitchToPlayingUI();
                    elapsedTime = 0;
                }

                //ゲームが開始されてから指定された制限時間が経つとゲームを終了する
                if (isStarted && GameSetting.TimeLimit < elapsedTime)
                {
                    isFinished = true;
                    SwitchToPostPlayingUI();
                    elapsedTime = 0;
                }

                //ゲームが終了してから一定時間経つとリザルト画面へ行く
                if(isFinished && 5 < elapsedTime)
                {

                }

                if (!isStarted)
                {
                    DrawPrePlayingUI();
                }
                else if (isStarted && !isFinished)
                {
                    AcceptInput();
                    DrawPlayingUI();
                }
                else if (isFinished)
                {
                    DrawPostPlayingUI();
                }
            }
        }

        public void StartStage()
        {

        }

        public void AcceptInput()
        {
            Player1.Move(Input.GetAxis("Player1_Vertical1"), Input.GetAxis("Player1_Horizontal1"));
            Player1.RotateCamera(Input.GetAxis("Player1_Vertical2"), Input.GetAxis("Player1_Horizontal2"));
            if(Input.GetAxisRaw("Player1_Jump") == 1) Player1.Jump();
            if (Input.GetAxisRaw("Player1_Fire1") == 1) Player1.UseItem(1);
            if (Input.GetAxisRaw("Player1_Fire2") == 1) Player1.UseItem(2);
            Player1.MoveSlotIndex(1, (int)Input.GetAxisRaw("Player1_Side1"));
            Player1.MoveSlotIndex(2, (int)Input.GetAxisRaw("Player1_Side2"));

            Player2.Move(Input.GetAxis("Player2_Vertical1"), Input.GetAxis("Player2_Horizontal1"));
            Player2.RotateCamera(Input.GetAxis("Player2_Vertical2"), Input.GetAxis("Player2_Horizontal2"));
            if (Input.GetAxisRaw("Player2_Jump") == 1) Player2.Jump();
            if (Input.GetAxisRaw("Player2_Fire1") == 1) Player2.UseItem(1);
            if (Input.GetAxisRaw("Player2_Fire2") == 1) Player2.UseItem(2);
            Player2.MoveSlotIndex(1, (int)Input.GetAxisRaw("Player2_Side1"));
            Player2.MoveSlotIndex(2, (int)Input.GetAxisRaw("Player2_Side2"));
        }

        #region UI
        private Text[] CountDownTexts;

        public void DrawPrePlayingUI()
        {
            string s = 1 < elapsedTime ? ((int)(5 - elapsedTime)).ToString() : "";
            if (elapsedTime - (int)elapsedTime > 0.8f) s = "";
            s = (s == "0" || s == "4") ? "" : s;

            
        }

        public void SwitchToPlayingUI()
        {

        }

        public void　DrawPlayingUI()
        {

        }

        public void SwitchToPostPlayingUI()
        {

        }

        public void DrawPostPlayingUI()
        {

        }

        private void InitializeUI()
        {
            Transform canvas1 = GameObject.Find("/Canvas/Player1Canvas/PrePlayingCanvas").transform;
            Transform canvas2 = GameObject.Find("/Canvas/Player2Canvas/PrePlayingCanvas").transform;

            Transform[] canvases = new Transform[Players.Length];

        }
        #endregion
    }
}
