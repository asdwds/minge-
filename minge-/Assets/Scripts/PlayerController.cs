using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        private Transform tf;
        private Transform cameratf;
        private Transform modeltf;

        public void Awake()
        {
            this.tf = this.transform;
            this.cameratf = tf.FindChild("Camera");
            this.modeltf = tf.FindChild("Model");
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Move(float vertical, float horizontal)
        {
        }

        public void RotateCamera(float vertical, float horizontal)
        {

        }
    }
}