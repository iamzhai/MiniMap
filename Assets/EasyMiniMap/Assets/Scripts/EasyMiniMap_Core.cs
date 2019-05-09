using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zjw
//CreateTime:2018-11-22
//MiniMap-core work
namespace EasyMiniMap
{
    public class EasyMiniMap_Core : MonoBehaviour
    {
        public Camera m_Camera;
        public Transform leftPos1;//left position
        public Transform rightPos2;//right position
        public Color[] materialColor = new Color[] { Color.red, Color.yellow, Color.blue, Color.grey, Color.black };
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 inputPos = Input.mousePosition;
                if (inputPos.x >= 0 && inputPos.x < rightPos2.position.x && inputPos.y >= leftPos1.position.y && inputPos.y <= rightPos2.position.y)
                {
                    //Click on the coordinates and switch to the window coordinates
                    float x = inputPos.x / 300;
                    float y = (inputPos.y - leftPos1.position.y) / 300;
                    Ray ray = m_Camera.ViewportPointToRay(new Vector3(x, y, 0));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "Cube")
                        {
                            int colorType = Random.Range(0, 4);
                            hit.transform.GetComponent<MeshRenderer>().material.color = materialColor[colorType];
                            hit.transform.GetComponent<EasyMiniMap_Effect>().Select();
                        }
                        if (hit.transform.tag == "Plane")
                        {
                            EasyMiniMap_HeroControl.instance.MoveTarget(hit.point);
                        }
                        Debug.Log("click:" + hit.transform.name);
                        Debug.DrawLine(ray.origin, hit.point, Color.red);
                    }
                }
            }
        }
    }
}

