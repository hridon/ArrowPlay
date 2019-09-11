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
    private float MapHeight = 1136;

    [SerializeField]
    private float MapWidht = 640;

    [SerializeField]
    private int CenterImageNum = 3;

    [SerializeField]
    private Image TopImage;

    [SerializeField]
    private Image CenterImage;

    [SerializeField]
    private Image DownImage;

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
        float ratio = (float) MapWidht / CenterImage.sprite.rect.width;
        MapCanvasScaler.transform.localScale = Vector3.one * ratio;
        //设置中间位置宽高 位置
        CenterImage.rectTransform.sizeDelta = new Vector2(MapWidht, CenterImage.sprite.rect.height * CenterImageNum * MapWidht / CenterImage.sprite.rect.width) / ratio;
        CenterImage.rectTransform.localPosition = Vector3.zero;

        //顶部
        TopImage.rectTransform.sizeDelta = new Vector2(MapWidht, TopImage.sprite.rect.height * MapWidht / TopImage.sprite.rect.width) / ratio;
        TopImage.rectTransform.localPosition = new Vector3(0, (TopImage.rectTransform.sizeDelta.y+CenterImage.rectTransform.sizeDelta.y)/2, 0);

        //底部
        DownImage.rectTransform.sizeDelta = new Vector2(MapWidht, DownImage.sprite.rect.height * MapWidht / DownImage.sprite.rect.width) / ratio;
        DownImage.rectTransform.localPosition = new Vector3(0, -(DownImage.rectTransform.sizeDelta.y + CenterImage.rectTransform.sizeDelta.y) / 2, 0);
    }

    private void SetMapCameraCanvasScaler()
    {
        MapCanvasScaler.referenceResolution = new Vector2(MapWidht, (CenterImage.rectTransform.sizeDelta + TopImage.rectTransform.sizeDelta + DownImage.rectTransform.sizeDelta).y);

        MapRectTransform.localPosition = new Vector3(0, -DownImage.rectTransform.localPosition.y-TopImage.rectTransform.localPosition.y, 0);
    }

    private void SetBoxColliders()
    {
        float curMapWidht = MapWidht * MapCanvasScaler.referenceResolution.y / MapHeight;
        float scaleChangeNum = MapCanvasScaler.referenceResolution.y / MapHeight;
        //设置地板的长宽 这里直接设定box的长宽
        PlaneBoxCollider.transform.localScale = new Vector3(PLANEWIDHT * scaleChangeNum, 0.001f,
            PLANEWIDHT * scaleChangeNum * (CenterImage.rectTransform.sizeDelta + TopImage.rectTransform.sizeDelta + DownImage.rectTransform.sizeDelta).y / curMapWidht);

        float zScale = CenterImage.rectTransform.sizeDelta.y * PLANEWIDHT / 640f;
        //设置五面墙体的宽高
        WallBoxColliders[0].transform.localScale = new Vector3(1, 1, zScale);
        WallBoxColliders[0].transform.localPosition = new Vector3(PLANEWIDHT/2f, 0, 0);

        WallBoxColliders[1].transform.localScale = new Vector3(1, 1, zScale);
        WallBoxColliders[1].transform.localPosition = new Vector3(-PLANEWIDHT/2f, 0, 0);

        WallBoxColliders[2].transform.localScale = new Vector3(1, 1, zScale/2f);
        WallBoxColliders[2].transform.localPosition = new Vector3(0, 0, zScale/2f);

        WallBoxColliders[3].transform.localScale = new Vector3(1, 1, zScale/2f);
        WallBoxColliders[3].transform.localPosition = new Vector3(0, 0, zScale / 2f);

        WallBoxColliders[4].transform.localScale = new Vector3(1, 1, zScale);
        WallBoxColliders[4].transform.localPosition = new Vector3(0, 0, -zScale/2f);

        //设置门的宽高
        DoorBoxCollider.transform.localScale = new Vector3(1, 1, 4f);
        DoorBoxCollider.transform.localPosition = new Vector3(0, 0, zScale / 2f);
    }
}
