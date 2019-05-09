using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zjw
//CreateTime:2018-11-22
//Operating Instructions
namespace EasyMiniMap
{
    public class EasyMiniMap_Describe : MonoBehaviour
    {
        private void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.fontSize = 20;
            GUI.Label(new Rect(10,Screen.height-80,600,20), "This is a demo of a small map.You can click on the objects on the small map to interact!",style);
            GUI.Label(new Rect(10,Screen.height-50,600,20), "Set the screen resolution to 1024*768!",style);
        }
    }
}

