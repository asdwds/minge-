using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    public class FlagController : MonoBehaviour
    {
        public const int PPS = 10;

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

        public void OnTriggerStay(Collider co)
        {
            //一秒ごとのとり方わからんかった・・・
            if ((Time.fixedTime - (int)Time.fixedTime) <= Time.fixedDeltaTime)
            {
                if (co.tag == "Player")
                {
                    switch (co.gameObject.GetComponent<PlayerController>().Team)
                    {
                        case Team.Red:
                            RedPoint++;
                            break;
                        case Team.Blue:
                            BluePoint++;
                            break;
                    }
                }
            }
        }
    }
}