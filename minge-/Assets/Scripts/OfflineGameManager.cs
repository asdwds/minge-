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
            this.Player1 = GameObject.Find("Player1").GetComponent<PlayerController>();
            //this.Player2 = GameObject.Find("Player2").GetComponent<PlayerController>();
        }

        public void Start()
        {

        }

        public void Update()
        {
        }

        public void StartStage()
        {

        }

        public void AcceptInput()
        {
            this.Player1.Move(Input.GetAxis("Player1_Vertical1"), Input.GetAxis("Player1_Horizontal1"));
            this.Player1.RotateCamera(Input.GetAxis("Player1_Vertical2"), Input.GetAxis("Player1_Horizontal2"));
        }
    }
}
