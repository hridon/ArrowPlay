using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderTest : MonoBehaviour
{

    [SerializeField] private GameObject m_StartPoint;
    [SerializeField] private GameObject m_TargetPoint;

    private LineRenderer lineRenderer;
    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.SetPosition(0, m_StartPoint.transform.position);
    }

    void Update()
    {
        TargetMove();

        lineRenderer.SetPosition(1, m_TargetPoint.transform.position);
    }

    void TargetMove()
    {
        m_TargetPoint.transform.Translate(Vector3.forward*Time.deltaTime,Space.World);
    }
}
