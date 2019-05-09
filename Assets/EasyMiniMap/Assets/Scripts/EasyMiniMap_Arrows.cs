using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zjw
//CreateTime:2018-11-22
//Arrows property
namespace EasyMiniMap
{
    public class EasyMiniMap_Arrows : MonoBehaviour
    {
        public GameObject target;
        void Update()
        {
            this.transform.localEulerAngles = new Vector3(90, 0, -target.transform.eulerAngles.y);
        }
    }
}

