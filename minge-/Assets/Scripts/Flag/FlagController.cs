using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    public class FlagController : MonoBehaviour
    {
        public int PPS = 10;

        public int RedPoint { get; private set; }
        public int BluePoint { get; private set; }

        public void Awake()
        {
        }

        public void Initialize()
        {
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        private float previousTime = 0;
        public void OnTriggerStay(Collider co)
        {
            //一秒ごとのとり方わからんかった・・・
            if (Time.fixedTime - previousTime > 1)
            {
                if (co.tag == "Player")
                {
                    switch (co.gameObject.GetComponent<PlayerController>().Team)
                    {
                        case Team.Red:
                            RedPoint += PPS;
                            break;
                        case Team.Blue:
                            BluePoint += PPS;
                            break;
                    }
                    previousTime = Time.fixedTime;
                    Debug.Log("Red:" + RedPoint + ", Blue:" + BluePoint);
                }
            }
        }
    }
}