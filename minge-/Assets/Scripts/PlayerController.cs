using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        private Transform tf;
        private Transform cameratf;
        private Transform modeltf;

        public Team Team { get; private set; }

        public int MaxHP { get; private set; }

        public int HP { get; private set; }

        public float Speed { get; private set; }

        public int SlotCount { get; private set; }

        public int SlotIndex1 { get; private set; }

        public int SlotIndex2 { get; private set; }

        List<Item> ItemSlot;

        public void Awake()
        {
            this.tf = this.transform;
            this.cameratf = tf.FindChild("Camera");
            this.modeltf = tf.FindChild("Model");
        }

        /// <summary>
        /// Instantiateとかした直後にこれを実行
        /// 実質コンストラクタ
        /// </summary>
        /// <param name="maxHP"></param>
        /// <param name="slotcount"></param>
        public void Initialize(Team team, int maxHP, float speed, int slotcount)
        {
            Team = team;
            MaxHP = maxHP;
            Speed = speed;
            SlotCount = slotcount;
            ItemSlot = new List<Item>();
            for(var i = 0;i < slotcount;i++)
            {
                ItemSlot.Add(null);
            }
        }

        public void Initialize(GameSetting.Player setting, int slotcount)
        {
            Initialize(setting.Team, setting.MaxHP, setting.Speed, slotcount);
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        /// <summary>
        /// 動け
        /// </summary>
        /// <param name="vertical"></param>
        /// <param name="horizontal"></param>
        public void Move(float vertical, float horizontal)
        {
            float mag = Mathf.Sqrt(Mathf.Pow(vertical, 2) + Mathf.Pow(horizontal, 2));
            if (mag != 0)
            {
                tf.position = tf.position + Quaternion.AngleAxis(-CameraPhi * Mathf.Rad2Deg, Vector3.up) * ((Speed / 100f) * new Vector3(horizontal / mag, 0, vertical / mag));
            }
        }

        public void Jump()
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        }


        #region Camera
        #region Cameraの変数たち
        private float cameraHeight = 0.5f;
        public float CameraHeight
        {
            get { return cameraHeight; }
            private set { cameraHeight = value; }
        }
        private float cameraDistance = 5;
        public float CameraDistance
        {
            get { return cameraDistance; }
            private set { cameraDistance = 1 < value ? (value < 30 ? value : 30) : 1; }
        }
        private float cameraPhi = 0;
        public float CameraPhi
        {
            get { return cameraPhi; }
            private set { cameraPhi = 0 < value ? (value < 2 * Mathf.PI ? value : value - 2 * Mathf.PI) : value + 2 * Mathf.PI; }
        }
        private float cameraTheta = 0.5f * Mathf.PI;
        public float CameraTheta
        {
            get { return cameraTheta; }
            private set { cameraTheta = 0 < value ? (value < Mathf.PI ? value : Mathf.PI) : 0; }
        }
        #endregion

        /// <summary>
        /// カメラ動け
        /// </summary>
        /// <param name="vertical"></param>
        /// <param name="horizontal"></param>
        public void RotateCamera(float vertical, float horizontal)
        {
            CameraPhi += horizontal / 20f;
            CameraTheta += vertical / 20f;
            cameratf.localPosition = new Vector3(
                CameraDistance * Mathf.Sin(CameraPhi) * Mathf.Sin(CameraTheta),
                CameraHeight + CameraDistance * Mathf.Cos(CameraTheta),
                -1 * CameraDistance * Mathf.Cos(CameraPhi) * Mathf.Sin(CameraTheta));
            cameratf.rotation = Quaternion.Euler(-CameraTheta * Mathf.Rad2Deg + 90, -CameraPhi * Mathf.Rad2Deg, 0);
        }

        #endregion

        #region Item
        /// <summary>
        /// アイテムを獲得する
        /// </summary>
        /// <param name="item"></param>
        /// <returns>アイテムを獲得したかどうか
        /// スロットの関係などで獲得できなかった場合はfalseを返す</returns>
        public bool GetItem(Item item)
        {
            AlignItems();
            bool result = false;

            //既に持っていてそれに重ねることができる場合はそうする
            for(var i = 0;i < SlotCount;i++)
            {
                if(ItemSlot[i] != null && ItemSlot[i].Combine(item))
                {
                    result = true;
                    break;
                }
            }

            if (!result)
            {
                //アイテムスロットの空きを取得
                int brank = ItemSlot.FindAll((i) => i == null).Count;

                //獲得するアイテムが要するスロット数を満たしていれば
                //アイテムを獲得する
                if(item.Size < brank)
                {
                    ItemSlot[SlotCount - brank] = item;
                    for(var i = 0;i < item.Size - 1;i++)
                    {
                        ItemSlot[SlotCount - brank + 1 + i] = new ConnectedSlot(item);
                    }
                    item.SetPlayer(this);
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// アイテムを使う
        /// </summary>
        /// <param name="firebutton">Fire1ボタンが押されたら1、みたいな感じで</param>
        public void UseItem(int firebutton)
        {
            int index = firebutton == 1 ? SlotIndex1 : (firebutton == 2 ? SlotIndex2 : -1);
            if (index < 0 || SlotCount - 1 < index) return;
            if (ItemSlot[index] != null) ItemSlot[index].Use();
        }

        public void MoveSlotIndex(int ii, int a)
        {
            if (ii != 1 && ii != 2) return;
            int index = ii == 1 ? SlotIndex1 : (ii == 2 ? SlotIndex2 : -1);
            if (ii != -1)
            {
                for(int i = 0;i < SlotCount;i++)
                {
                    index += a;
                    Item item = ItemSlot[index];
                    if(item == null || !item.IsSelectable)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (ii == 1) SlotIndex1 = index;
            else if (ii == 2) SlotIndex2 = index;
        }

        /// <summary>
        /// ItemSlotを、nullがListのインデックスの大きい所へ来るようにソートする
        /// たとえば、｛Item1, Item2, Connected, null, Item3, null｝とかだったら
        /// ｛Item1, Item2, Connected, Item3, null, null｝になってほしい
        /// </summary>
        public void AlignItems()
        {
            Item[] items = new Item[ItemSlot.Count];
            ItemSlot.CopyTo(items);
            List<Item> list = new List<Item>(items);
            list.RemoveAll(i => i == null || i.GetType() == typeof(ConnectedSlot));
            for(var i = 0;i < SlotCount - 1;i++)
            {
                ItemSlot[i] = null;
            }
            int index = 0;
            foreach(var item in list)
            {
                ItemSlot[index] = item;
                for(var i = 0;i < item.Size - 1;i++)
                {
                    ItemSlot[index + i + 1] = new ConnectedSlot(item);
                }
                index += item.Size;
            }
        }

        #endregion
    }

    public enum Team
    {
        Red, Blue, 
    }
}