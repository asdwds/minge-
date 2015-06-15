using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class PanelController : GimmickController
    {
        public float Speed;
        public float WaitTime;
        public List<Vector3> WayPoints;

        protected override void Awake()
        {
        }

        protected override void Start()
        {
            defaultPosition = transform.position;
        }

        public override void Initialize(List<double> values)
        {
            Speed = (float)values[0];
            WaitTime = (float)values[1];

            WayPoints = new List<Vector3>();

            for (var i = 0; i < (values.Count - 2) / 3; i++)
            {
                Vector3 point = new Vector3(
                    (float)values[2 + i * 3 + 0], 
                    (float)values[2 + i * 3 + 1], 
                    (float)values[2 + i * 3 + 2]
                );

                WayPoints.Add(point);
            }
        }

        public override List<double> GetValues()
        {
            List<double> values = new List<double>();
            values.Add(Speed);
            values.Add(WaitTime);
            for (var i = 0; i < WayPoints.Count; i++)
            {
                values.Add(WayPoints[i].x);
                values.Add(WayPoints[i].y);
                values.Add(WayPoints[i].z);
            }

            return values;
        }

        private Vector3 defaultPosition;
        private int nowPoint = 0;
        private bool forward = true;
        private float previoustime = 0;
        protected override void Update()
        {
            if (WayPoints == null || WayPoints.Count < 1) return;

            if (Time.fixedTime - previoustime < WaitTime) return;

            Vector3 direction;
            if (forward)
            {
                if (nowPoint == WayPoints.Count - 1)
                {
                    forward = false;
                    previoustime = Time.fixedTime;
                    return;
                }
                else
                {
                    direction = (WayPoints[nowPoint + 1] - WayPoints[nowPoint]).normalized;
                }
            }
            else
            {
                if (nowPoint == 0)
                {
                    forward = true;
                    previoustime = Time.fixedTime;
                    return;
                }
                else
                {
                    direction = (WayPoints[nowPoint - 1] - WayPoints[nowPoint]).normalized;
                }
            }

            this.transform.Translate(direction * Speed * Time.fixedDeltaTime);

            float distance = forward ? (WayPoints[nowPoint + 1] + defaultPosition - transform.position).magnitude : (WayPoints[nowPoint - 1] + defaultPosition - transform.position).magnitude;

            if (distance < 0.3f)
            {
                nowPoint += forward ? 1 : -1;
                previoustime = Time.fixedTime;
            }
        }

    }
}