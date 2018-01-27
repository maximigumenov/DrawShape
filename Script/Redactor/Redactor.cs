using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Save;
using UnityEngine.SceneManagement;

namespace Redactor
{
    public class Redactor : MonoBehaviour
    {
        [SerializeField] FigurePoint points;
        [SerializeField] RedactorData data;
        [SerializeField] LevelData level;

        private void Start()
        {
            points.CreateAim();
        }

        private void Update()
        {
            points.Update();
        }

        [ContextMenu("GetData")]
        public void GetData()
        {
            SaveToTxt save = new SaveToTxt();
            PointSave pointSave = new PointSave();
            pointSave.InitObject();
            points.GetDataPoint(data, pointSave);
            level.SetData(pointSave);
            string saveText;
            SaveController.Save<PointSave>(pointSave, out saveText);
            save.WriteString(pointSave.nameLevel, saveText);
            SceneManager.LoadScene("Redactor");
        }
    }
}
