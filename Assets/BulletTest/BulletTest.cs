using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 反弹测试
/// </summary>
public class BulletTest : MonoBehaviour
{

    [SerializeField] private float m_BulletSpeed = 1f;

    private bool isCanRebound = true;

    void Start()
    {
      transform.LookAt(Vector3.zero);
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
                Vector3 nextDir = Vector3.Reflect(curDir, point.normal);
                transform.rotation = Quaternion.FromToRotation(Vector3.forward, nextDir);
                transform.localPosition = point.point;
            }
        }

    }
}
