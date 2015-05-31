using UnityEngine;
using System.Collections;
using Game;
using System;

namespace Game
{
    public class TestItem : Item
    {
        public TestItem(int count)
            :base(count)
        {
            IsNumerable = true;
            IsSelectable = true;
            Size = 2;
        }


        public override bool Use()
        {
            Count--;
            Debug.Log(Count);
            if (Count <= 0) return false;
            return true;
        }

        public override bool Combine(Item item)
        {
            if (item.GetType() == GetType())
            {
                Count += item.Count;
                return true;
            }
            else return false;
        }
    }
}