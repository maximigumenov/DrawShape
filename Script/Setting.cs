using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Setting
{
    
    public static void SetOrthographic()
    {
        float ratio = 1f * Screen.height / Screen.width;
        float ortSize = (1920 * ratio) / 200f;
        Camera.main.orthographicSize = ortSize;
    }
}
