using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public abstract class GimmickController : MonoBehaviour
    {
        protected abstract void Awake();

        public abstract void Initialize(List<double> values);
        public abstract List<double> GetValues();

        protected abstract void Start();
        protected abstract void Update();
    }
}