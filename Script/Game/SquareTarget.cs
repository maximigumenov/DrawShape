using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class SquareTarget
    {
        public Vector2 min;
        public Vector2 max;
        public float width;
        public float height;

        public void Reset()
        {
            min.x = (float)Screen.width;
            min.y = (float)Screen.height;
            max.x = 0;
            max.y = 0;
            width = 0;
            height = 0;
        }

        public List<Vector2> SetCoordinates(List<Vector3> mousePosition)
        {
            width = Vector2.Distance(new Vector2(min.x, 0), new Vector2(max.x, 0));
            height = Vector2.Distance(new Vector2(0, min.y), new Vector2(0, max.y));
            return GetDataCoordinate(mousePosition, new Vector2(width, height));
        }

        List<Vector2> GetDataCoordinate(List<Vector3> mousePosition, Vector2 WH)
        {

            float length = WH.x;
            if (WH.y > WH.x)
            {
                length = WH.y;
            }

            List<Vector2> result = new List<Vector2>();

            for (int i = 0; i < mousePosition.Count; i++)
            {
                Vector2 data = new Vector2();
                data.x = GetPercent(mousePosition[i].x, length, min.x);
                data.y = GetPercent(mousePosition[i].y, length, min.y);
                result.Add(data);
            }


            return result;
        }

        private float GetPercent(float length, float controlLength, float min)
        {
            float dist = Vector2.Distance(new Vector2(min, 0), new Vector2(length, 0));
            return dist = dist / controlLength;
        }
    }
}
