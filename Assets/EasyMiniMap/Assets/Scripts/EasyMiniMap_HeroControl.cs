using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zjw
//CreateTime:2018-11-22
//MiniMap-Hero Control
namespace EasyMiniMap
{
    public class EasyMiniMap_HeroControl : MonoBehaviour
    {
        public static EasyMiniMap_HeroControl instance;
        public Camera m_Camera;
        public Rigidbody m_Rigidbody;
        bool isMove;
        Vector3 targetPos_Pos;
        Vector3 targetPos_Rot;
        void Start()
        {
            instance = this;
        }
        void Update()
        {
            MoveUpdate();
        }
        void LateUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                float rotationX = Input.GetAxis("Mouse X");
                float rotationY = Input.GetAxis("Mouse Y");
                m_Camera.transform.localEulerAngles += new Vector3(-rotationY, rotationX, 0);
            }
            float h = Input.GetAxis("Horizontal") * 0.1f;
            float v = Input.GetAxis("Vertical") * 0.1f;
            Vector3 currentPos = this.transform.position;
            currentPos += m_Camera.transform.forward * v + m_Camera.transform.right * h;
            m_Rigidbody.MovePosition(currentPos);
        }
        public void MoveTarget(Vector3 target)
        {
            isMove = true;
            targetPos_Pos = new Vector3(target.x, this.transform.position.y, target.z);
            targetPos_Rot = new Vector3(target.x, m_Camera.transform.position.y, target.z); ;
        }
        public void MoveUpdate()
        {
            if (isMove)
            {
                if (Vector3.Distance(this.transform.position, targetPos_Pos) > 1.5f)
                {
                    Quaternion wantRot = Quaternion.LookRotation(targetPos_Rot - m_Camera.transform.position);//要旋转的向量物体是垂直这条线的【注视旋转】
                    m_Camera.transform.rotation = Quaternion.Slerp(m_Camera.transform.rotation, wantRot, 2 * Time.deltaTime);//缓慢的旋转//
                    Vector3 dir = (targetPos_Pos - this.transform.position).normalized;//设置移动的单位向量
                    transform.Translate(dir * 2 * Time.deltaTime, Space.World);
                }
                else
                {
                    isMove = false;
                }
            }
        }
    }
}

