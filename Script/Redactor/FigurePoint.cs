using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using Save;

namespace Redactor
{
    [System.Serializable]
    public class FigurePoint
    {
        [Header("Color")]
        [SerializeField]
        Color startColor = Color.blue;
        [SerializeField] Color contactColor = Color.green;
        [SerializeField] Color breakColor = Color.red;
        [SerializeField] Color pointColor = Color.yellow;
        [Header("Objects")]
        [SerializeField]
        Transform parentTransform;
        [SerializeField] GameObject pointPrefab;
        [SerializeField] GameObject aimPrefab;

        IAimPoint Aim;
        Transform aimTransform;
        List<IPoint> listPoints = new List<IPoint>();
        bool isMouseover = false;

        public void Update()
        {
            Mouseover();
            CheckCollision();
            Press();
        }

        private void Mouseover()
        {
            RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (Hit.collider != null)
            {
                Vector3 targetPosition = new Vector3(Hit.point.x, Hit.point.y, Hit.transform.position.z);
                Aim.transformObj.position = targetPosition;
                isMouseover = true;
            }
            else
            {
                isMouseover = false;
            }
        }

        private void CheckCollision()
        {
            if (listPoints.Count > 0)
            {

            }
        }

        private void Press()
        {
            if (
                (isMouseover) &&
                (Input.GetMouseButtonDown(0))
                )
            {
                CreatePoint();
            }
        }


        private void CreatePoint()
        {
            if (isCreate())
            {
                GameObject obj = GameObject.Instantiate(pointPrefab);
                obj.transform.SetParent(parentTransform);
                obj.transform.position = aimTransform.position;
                IPoint point = obj.GetComponent<IPoint>();
                point.SetColor(pointColor);
                listPoints.Add(point);
            }
        }

        bool isCreate()
        {
            if (
                (listPoints.Count > 0) &&
                (Aim.isCreate)
                )
            {
                return true;
            }
            else if (listPoints.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetDataPoint(RedactorData redactorData, PointSave pointSave)
        {
            float diffX = Vector2.Distance(new Vector2(redactorData.minBorder.x, 0), new Vector2(redactorData.maxBorder.x, 0));
            float diffY = Vector2.Distance(new Vector2(0, redactorData.minBorder.y), new Vector2(0, redactorData.maxBorder.y));

            pointSave.saveData = new List<PointData>();
            for (int i = 0; i < listPoints.Count; i++)
            {
                PointData pointData = new PointData();
                pointData.X_data = GetPercent(listPoints[i].transformObj.localPosition.x, diffX, redactorData.minBorder.x);
                pointData.Y_data = GetPercent(listPoints[i].transformObj.localPosition.y, diffY, redactorData.minBorder.y);
                pointSave.saveData.Add(pointData);
            }



        }

        public void CreateAim()
        {
            GameObject obj = GameObject.Instantiate(aimPrefab);
            obj.transform.SetParent(parentTransform);
            aimTransform = obj.transform;
            Aim = obj.GetComponent<IAimPoint>();
            Aim.SetColor(startColor);
            Aim.SetOrder(10);
            UnityEvent enterEvent = new UnityEvent();
            enterEvent.AddListener(() => EnterAim());
            UnityEvent exitEvent = new UnityEvent();
            exitEvent.AddListener(() => ExitAim());
            Aim.SetEvents(enterEvent, exitEvent);
        }

        private void EnterAim()
        {
            Aim.SetColor(contactColor);
        }

        private void ExitAim()
        {
            Aim.SetColor(breakColor);
        }

        private float GetPercent(float length, float controlLength, float min)
        {
            float dist = Vector2.Distance(new Vector2(min, 0), new Vector2(length, 0));
            return dist = dist / controlLength;
        }
    }
}
