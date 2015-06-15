using UnityEngine;
using System.Collections;
using Game;
using System;

namespace Game
{
    public class ConnectedSlot : Item
    {
        public ConnectedSlot(Item item)
            :base(0)
        {
            IsNumerable = false;
            IsSelectable = false;
            Size = 1;
        }

        public override bool Use()
        {
            return true;
        }

        public override bool Combine(Item item)
        {
            return false;
        }
    }
}