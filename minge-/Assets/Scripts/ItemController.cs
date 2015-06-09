using UnityEngine;
using System.Collections;
using Game;


namespace Game
{
    public class ItemController : MonoBehaviour
    {
        public Item Item;

        public void Awake()
        {

        }

        public void Initialize(Item item)
        {
            Item = item;
        }
        
        public void Start()
        {

        }

        public void Update()
        {
        }
        
        private void OnTriggerEnter(Collider co)
        {
            if (co.gameObject.tag == "Player")
            {
                bool b = co.gameObject.GetComponent<PlayerController>().GetItem(Item);
                if (b) Destroy(gameObject, 0.3f);
            }
        }
    }
}