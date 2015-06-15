using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    public class OfflineGameManager : MonoBehaviour
    {
        public PlayerController Player1;
        public PlayerController Player2;

        public void Awake()
        {
            Stage.Load(GameSetting.StageName);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            Player1 = players[0].GetComponent<PlayerController>();
            Player1.Initialize(GameSetting.Player1, GameSetting.SlotCount);
        }

        public void Start()
        {
        }

        public void Update()
        {
            AcceptInput();
        }

        public void StartStage()
        {

        }

        public void AcceptInput()
        {
            this.Player1.Move(Input.GetAxis("Player1_Vertical1"), Input.GetAxis("Player1_Horizontal1"));
            this.Player1.RotateCamera(Input.GetAxis("Player1_Vertical2"), Input.GetAxis("Player1_Horizontal2"));
            if(Input.GetAxisRaw("Player1_Jump") == 1)this.Player1.Jump();
            if (Input.GetAxisRaw("Player1_Fire1") == 1) Player1.UseItem(1);
            if (Input.GetAxisRaw("Player1_Fire2") == 1) Player1.UseItem(2);
            Player1.MoveSlotIndex(1, (int)Input.GetAxisRaw("Player1_Side1"));
            Player1.MoveSlotIndex(2, (int)Input.GetAxisRaw("Player1_Side2"));
        }
    }
}
