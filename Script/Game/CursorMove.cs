using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class CursorMove : MonoBehaviour
    {
        [SerializeField] List<ParticlesData> particles;

        public void SetMove()
        {
            RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (Hit.collider != null)
            {
                Vector3 targetPosition = new Vector3(Hit.point.x, Hit.point.y, Hit.transform.position.z);
                transform.position = targetPosition;
            }
            SetParticle();
        }

        public void ActiveParticle()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].SetMax();
            }
        }

        public void DeActiveParticle()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].SetMin();
            }
        }

        void SetParticle()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ActiveParticle();
            }

            if (Input.GetMouseButtonUp(0))
            {
                DeActiveParticle();
            }
        }
    }
}
