using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Redactor
{
    [System.Serializable]
    public class LevelData
    {
        public Text nameLevel;
        public Text nameImage;

        public void SetData(PointSave pointSave)
        {
            pointSave.nameLevel = nameLevel.text;
            pointSave.nameImage = nameImage.text;
        }
    }
}
