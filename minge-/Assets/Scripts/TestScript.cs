using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    public class TestScript : MonoBehaviour
    {
        public void Awake()
        {
            GameObject go;
            go = Instantiate(Resources.Load<GameObject>("Prefab/Player"));
            go.GetComponent<PlayerController>().Initialize(100, 6);
            go.name = "Player1";

            go = Instantiate(Resources.Load<GameObject>("Prefab/TestItem"), new Vector3(0, 0, 10), Quaternion.identity) as GameObject;
            go.GetComponent<ItemController>().Initialize(new TestItem(5));
        }

        public void Start()
        {

        }

        public void Update()
        {

        }
    }
}