using UnityEngine;
using System.Collections;
using Game;


namespace Game
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField]
        public Items item;

        public int Count = -1;

        public void Awake()
        {

        }

        public void Initialize(Items item)
        {
            this.item = item;
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
                bool b = co.gameObject.GetComponent<PlayerController>().GetItem(Item.Get(item, Count));
                if (b) Destroy(gameObject, 0.3f);
            }
        }
    }
}