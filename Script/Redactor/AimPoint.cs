using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Redactor
{
    public class AimPoint : MonoBehaviour, IAimPoint
    {

        [SerializeField] SpriteRenderer spriteRenderer;
        UnityEvent enterEvent = new UnityEvent();
        UnityEvent exitEvent = new UnityEvent();
        bool _isCreate = false;

        void OnTriggerStay2D(Collider2D col)
        {
            _isCreate = true;
            enterEvent.Invoke();
        }

        void OnTriggerExit2D(Collider2D col)
        {
            _isCreate = false;
            exitEvent.Invoke();
        }

        public Transform transformObj
        {
            get
            {
                return spriteRenderer.transform;
            }
        }

        public bool isCreate
        {
            get
            {
                return _isCreate;
            }
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void SetOrder(int order)
        {
            spriteRenderer.sortingOrder = order;
        }

        public void SetEvents(UnityEvent enter, UnityEvent exit)
        {
            enterEvent = enter;
            exitEvent = exit;
        }
    }
}
