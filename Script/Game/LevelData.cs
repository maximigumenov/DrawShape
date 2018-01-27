using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redactor;
using Save;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class LevelData
    {
        public List<string> levels;

        int nowNum = -1;
        List<DataShape> pointData = new List<DataShape>();

        public DataShape GetDataShape()
        {
            return pointData[nowNum];
        }

        public void Init()
        {
            for (int i = 0; i < levels.Count; i++)
            {
                DataShape pointShape = LoadLevel(levels[i]);
                pointData.Add(pointShape);
            }
        }

        public void NextLevel(GameResource resource)
        {
            nowNum++;
            if (nowNum >= pointData.Count)
            {
                nowNum = 0;
            }
            resource.showShape.sprite = pointData[nowNum].sprite;
        }

        DataShape LoadLevel(string levelName)
        {
            string levelData;
            SaveToTxt saveToTxt = new SaveToTxt();
            saveToTxt.ReadString(levelName, out levelData);
            PointSave pointSave = new PointSave();
            pointSave.InitObject();
            SaveController.Load<PointSave>(ref pointSave, levelData);
            DataShape shape = new DataShape();
            shape.sprite = Resources.Load<Sprite>("Shape/" + pointSave.nameImage);
            shape.pointData = pointSave.saveData;
            return shape;
        }
    }
}
