using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Redactor
{
    public class Point : MonoBehaviour, IPoint
    {

        [SerializeField] SpriteRenderer spriteRenderer;
        
        public Transform transformObj
        {
            get
            {
                return spriteRenderer.transform;
            }
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}
