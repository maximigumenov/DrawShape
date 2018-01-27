using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Redactor
{
    [System.Serializable]
    public class RedactorData
    {
        [Header("Border")]
        public Vector2 minBorder;
        public Vector2 maxBorder;
    }
}
