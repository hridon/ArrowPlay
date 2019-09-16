using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ArrowPlay;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// UIMap
/// </summary>
public class UIMapManager : MonoBehaviour
{

    public static UIMapManager Instance=null;

    [SerializeField] 
    private BulletManager m_BulletManager;
    [SerializeField]
    private MonsterManager m_MonsterManager;

    [SerializeField] 
    private PlayerManager m_PlayerManager;
    /// <summary>
    /// 地图高度
    /// </summary>
    [SerializeField]
    private float m_MapHeight = 2186;

    [SerializeField]
    private float m_MapWidht = 1232;

    [SerializeField] private float m_SingleGrid = 384f;

    [SerializeField]
    private int m_CenterImageNum = 3;

    [SerializeField] private Image MapImage;

    [SerializeField]
    private CanvasScaler MapCanvasScaler;

    [SerializeField]
    private Transform MapRectTransform;

    [SerializeField]
    private GameObject GameVictoryDoor;

    [SerializeField]
    private BoxCollider[] WallBoxColliders;

    [SerializeField] 
    private BoxCollider DoorBoxCollider;

    [SerializeField]
    private BoxCollider PlaneBoxCollider;

    [SerializeField]
    private int XmlID = 100;

    [SerializeField] private CameraFollowCtrl m_CameraFollowCtrl;

    private const float PLANEWIDHT = 11f;

    public CameraFollowCtrl CameraFollowCtrl
    {
        get { return m_CameraFollowCtrl; }
    }

    public BulletManager BulletManager
    {
        get { return m_BulletManager; }
    }

    public MonsterManager MonsterManager
    {
        get { return m_MonsterManager; }
    }

    public PlayerManager PlayerManager
    {
        get { return m_PlayerManager; }
    }

    public int CenterImageNum
    {
        get { return m_CenterImageNum; }
        set
        {
            m_CenterImageNum = value;
            Awake();
        }
    }

    float ratio
    {
        get
        {
            return Mathf.Cos(50f * (float)Math.PI / 180f);
        }
    }

    [ContextMenu("SetMap")]
    public void Awake()
    {
        Instance = this;

        SetUIMap();
        SetMapCameraCanvasScaler();
        SetBoxColliders();
    }

    private void SetUIMap()
    {
        MapImage.rectTransform.sizeDelta = new Vector2(m_MapWidht, m_MapHeight + m_SingleGrid * (CenterImageNum - 1));
        MapImage.transform.parent.localScale = Vector3.one * m_MapWidht / Screen.width;
    }

    private void SetMapCameraCanvasScaler()
    {
        MapCanvasScaler.referenceResolution = new Vector2(m_MapWidht, MapImage.rectTransform.sizeDelta.y);
    }

    private void SetBoxColliders()
    {
        
        float scaleChangeNum = MapImage.rectTransform.sizeDelta.y / m_MapHeight;
        //设置地板的长宽 这里直接设定box的长宽
        PlaneBoxCollider.transform.localScale = new Vector3(PLANEWIDHT * scaleChangeNum, 0.001f,
            PLANEWIDHT * scaleChangeNum * m_MapHeight / m_MapWidht);

        float zScale = m_SingleGrid * CenterImageNum * PLANEWIDHT / m_MapWidht;
        //设置五面墙体的宽高
        WallBoxColliders[0].transform.localScale = new Vector3(1, 1, zScale+2);
        WallBoxColliders[0].transform.localPosition = new Vector3(PLANEWIDHT/2f, 0, 0);

        WallBoxColliders[1].transform.localScale = new Vector3(1, 1, zScale+2f);
        WallBoxColliders[1].transform.localPosition = new Vector3(-PLANEWIDHT/2f, 0, 0);

        WallBoxColliders[2].transform.localScale = new Vector3(1, 1, zScale/2f);
        WallBoxColliders[2].transform.localPosition = new Vector3(0, 0, zScale/2f+1f);

        WallBoxColliders[3].transform.localScale = new Vector3(1, 1, zScale/2f);
        WallBoxColliders[3].transform.localPosition = new Vector3(0, 0, zScale / 2f+1f);

        WallBoxColliders[4].transform.localScale = new Vector3(1, 1, zScale);
        WallBoxColliders[4].transform.localPosition = new Vector3(0, 0, -zScale/2f-1f);

        //设置门的宽高
        DoorBoxCollider.transform.localScale = new Vector3(1, 1, 6f);
        DoorBoxCollider.transform.localPosition = new Vector3(0, 0, zScale / 2f+1f);
    }
}
