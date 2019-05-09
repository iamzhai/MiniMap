using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zjw
//CreateTime:2018-11-22
//Effect
namespace EasyMiniMap
{
    public class EasyMiniMap_Effect : MonoBehaviour
    {
        public GameObject go;
        public void Select()
        {
            if (!go.activeSelf)
            {
                StartCoroutine(TaskSelect());
            }
        }
        IEnumerator TaskSelect()
        {
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
        }
    }
}
