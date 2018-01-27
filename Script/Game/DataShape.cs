using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Redactor;

namespace Game
{
    public class DataShape
    {
        public Sprite sprite;
        public List<PointData> pointData = new List<PointData>();

        public void ResetHit()
        {
            for (int i = 0; i < pointData.Count; i++)
            {
                pointData[i].isHit = false;
            }
        }
    }
}
