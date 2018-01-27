using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Save;
using Redactor;


public class PointSave : SaveObject
{
    public string nameLevel;
    public string nameImage = "555";
    public List<PointData> saveData = new List<PointData>();

}
