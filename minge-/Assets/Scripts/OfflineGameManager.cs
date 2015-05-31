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
        }

        public void Start()
        {
            Player1 = GameObject.Find("Player1").GetComponent<PlayerController>();
            //this.Player2 = GameObject.Find("Player2").GetComponent<PlayerController>();
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
            if (Input.GetAxisRaw("Player1_Fire1") == 1) Player1.UseItem(1);
            if (Input.GetAxisRaw("Player1_Fire2") == 1) Player1.UseItem(2);
            Player1.MoveSlotIndex(1, (int)Input.GetAxisRaw("Player1_Side1"));
            Player1.MoveSlotIndex(2, (int)Input.GetAxisRaw("Player1_Side2"));
        }
    }
}
