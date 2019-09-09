using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using AnimationState = Spine.AnimationState;

/// <summary>
/// 反弹测试
/// </summary>
public class BulletTest : MonoBehaviour
{

    [SerializeField] private float m_BulletSpeed = 1f;

    private bool isCanRebound = true;

    void Start()
    {
        transform.LookAt(new Vector3(0, transform.localPosition.y, 0));
    }

    void Update()
    {
        transform.Translate(Vector3.forward * m_BulletSpeed * Time.deltaTime, Space.Self);
    }


    private void OnCollisionEnter(Collision other)
    {
        if ((LayerMask.LayerToName( other.gameObject.layer)=="Box"))
        {
            if (!isCanRebound)
            {
                gameObject.SetActive(false);
            }
            else
            {
                ContactPoint point = other.contacts[0];
                Vector3 curDir = transform.TransformDirection(Vector3.forward);
                Vector3 normal = new Vector3(point.normal.x,0,point.normal.z);
                Vector3 nextDir = Vector3.Reflect(curDir, normal);
                transform.rotation = Quaternion.FromToRotation(Vector3.forward, nextDir);
                transform.localPosition = new Vector3(point.point.x, transform.localPosition.y, point.point.z); 
            }
        }
    }

}
