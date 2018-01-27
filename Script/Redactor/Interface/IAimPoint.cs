using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Redactor
{
    interface IAimPoint : IPoint
    {
        bool isCreate { get; }
        void SetEvents(UnityEvent enter, UnityEvent exit);
        void SetOrder(int order);
    }
}
