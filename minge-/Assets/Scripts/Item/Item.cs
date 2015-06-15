using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    public enum Items
    {
        None, ConnectedSlot, TestItem,
    }

    public abstract class Item
    {
        /// <summary>
        /// countを負の数（デフォルト）にするとそのアイテムごとに決まった数のCountでアイテムが作られる
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static Item Get(Items item, int count = -1)
        {
            Item result = null;
            switch(item)
            {
                case Items.None:
                    result = null;
                    break;
                case Items.ConnectedSlot:
                    result = null;
                    break;
                case Items.TestItem:
                    result = new TestItem(count);
                    break;
            }

            return result;
        }
        /// <summary>
        /// 数えられるかどうか
        /// </summary>
        public bool IsNumerable { get; protected set; }

        /// <summary>
        /// アイテムを選べる（使える）かどうか
        /// </summary>
        public bool IsSelectable { get; protected set; }

        /// <summary>
        /// アイテムの個数
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// アイテムが占めるスロットの個数
        /// </summary>
        public int Size { get; protected set; }

        public PlayerController Player { get; protected set; }
        
        public Item(int count = 0)
        {
            Count = count;
        }

        //所持しているプレイヤーを設定
        public void SetPlayer(PlayerController player)
        {
            Player = player;
        }

        /// <summary>
        /// アイテムを使う
        /// アイテムが無くなったらfalseを返す
        /// </summary>
        /// <returns></returns>
        public abstract bool Use();

        /// <summary>
        /// すでにitemを所持していた時に、それに獲得したアイテムを足す
        /// </summary>
        /// <param name="item"></param>
        /// <returns>アイテムを足せたかどうか</returns>
        public abstract bool Combine(Item item);
    }
}