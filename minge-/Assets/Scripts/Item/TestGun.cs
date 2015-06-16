using UnityEngine;
using System.Collections;
using System;

namespace Game
{
    public class TestGun : Item
    {
        public TestGun(int count = 20)
            :base(count < 0 ? 20 : count)
        {
            IsNumerable = true;
            IsSelectable = true;
            Size = 1;
        }
        public override bool Combine(Item item)
        {
            return false;
        }

        public override bool Use()
        {
            Debug.Log("Gun");
            return true;
        }
    }
}