using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [System.Serializable]
    public class MouseBehaviour
    {
        [SerializeField] float corrective = 0.1f;
        bool isPress = false;
        List<Vector3> positionMouse = new List<Vector3>();
        List<Vector2> positionData = new List<Vector2>();
        SquareTarget square = new SquareTarget();
        DataShape dataShape = new DataShape();
        [HideInInspector] public UnityEvent nextLevel = new UnityEvent();

        public void Update()
        {
            Press();
            AddData();
        }

        public void SetData(DataShape data)
        {
            dataShape = data;
        }

        private void Press()
        {
            if (Input.GetMouseButtonDown(0))
            {
                positionMouse = new List<Vector3>();
                isPress = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isPress = false;
                GetLenght();
            }
        }

        private void AddData()
        {
            if (isPress)
            {
                float c = Screen.height * 0.02f;
                if (
                    (positionMouse.Count > 0) &&
                    (Vector3.Distance(Input.mousePosition, positionMouse[positionMouse.Count - 1]) > c)
                    )
                {
                    positionMouse.Add(Input.mousePosition);
                }
                else if (positionMouse.Count == 0)
                {
                    positionMouse.Add(Input.mousePosition);
                }
            }
        }

        private void GetLenght()
        {
            square.Reset();

            for (int i = 0; i < positionMouse.Count; i++)
            {
                if (positionMouse[i].x < square.min.x)
                {
                    square.min.x = positionMouse[i].x;
                }

                if (positionMouse[i].x > square.max.x)
                {
                    square.max.x = positionMouse[i].x;
                }

                if (positionMouse[i].y < square.min.y)
                {
                    square.min.y = positionMouse[i].y;
                }

                if (positionMouse[i].y > square.max.y)
                {
                    square.max.y = positionMouse[i].y;
                }
            }

            positionData = square.SetCoordinates(positionMouse);
            CompareCoordinate(positionData, dataShape, corrective);
        }

        private void CompareCoordinate(List<Vector2> position, DataShape dataShape, float corrective)
        {
            int coincides = 0;
            int notCoincides = 0;
            int shapeUse = 0;
            int shapeNotUse = 0;
            dataShape.ResetHit();

            //Corresponds to the position
            for (int i = 0; i < position.Count; i++)
            {
                HitData hit = new HitData();
                hit.position = position[i];
                hit.dataShape = dataShape;
                hit.corrective = corrective;

                if (IsHit(hit))
                {
                    coincides++;
                }
                else
                {
                    notCoincides++;
                }

            }

            //All points are used
            for (int j = 0; j < dataShape.pointData.Count; j++)
            {
                if (dataShape.pointData[j].isHit)
                {
                    shapeUse++;
                }
                else
                {
                    shapeNotUse++;
                }
            }

            if (
                (coincides > notCoincides) &&
                (shapeUse > shapeNotUse)
                )
            {
                nextLevel.Invoke();
            }

        }

        private bool IsHit(HitData hitData)
        {

            for (int i = 0; i < hitData.dataShape.pointData.Count; i++)
            {
                float dist = Vector2.Distance(hitData.position, new Vector2(hitData.dataShape.pointData[i].X_data, hitData.dataShape.pointData[i].Y_data));
                if (dist < hitData.corrective)
                {
                    hitData.dataShape.pointData[i].isHit = true;
                    return true;
                }
            }
            return false;
        }
    }
}
