using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Redactor
{
    interface IPoint
    {
        Transform transformObj { get; }
        void SetColor(Color color);
        
    }
}
