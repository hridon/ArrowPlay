using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ArrowPlay
{
    public class HomeMenuEvent : UGuiForm
    {
        [SerializeField]
        private GameObject left;
        [SerializeField]
        private GameObject right;
        [SerializeField]
        private Image scene_image;
        [SerializeField]
        private Image mapName_image;
        [SerializeField]
        private Image sceneBG_image;
        [SerializeField]
        private GameObject Lock;
        [SerializeField]
        private GameObject choice;


        //-----------------------导航栏
        [SerializeField]
        private GameObject box_image;
        [SerializeField]
        private GameObject equip_image;
        [SerializeField]
        private GameObject map_image;
        [SerializeField]
        private GameObject dower_image;
        [SerializeField]
        private GameObject set_image;

        [SerializeField]
        private GameObject boxbg_image;
        [SerializeField]
        private GameObject equipbg_image;
        [SerializeField]
        private GameObject mapbg_image;
        [SerializeField]
        private GameObject dowerbg_image;
        [SerializeField]
        private GameObject setbg_image;


        [SerializeField]
        private GameObject point1;
        [SerializeField]
        private GameObject point2;
        [SerializeField]
        private GameObject point3;
        [SerializeField]
        private GameObject point4;
        [SerializeField]
        private GameObject point5;

        [SerializeField]
        private GameObject pointL1;
        [SerializeField]
        private GameObject pointL2;
        [SerializeField]
        private GameObject pointL3;
        [SerializeField]
        private GameObject pointL4;
        [SerializeField]
        private GameObject pointL5;

        [SerializeField]
        private GameObject pointR1;
        [SerializeField]
        private GameObject pointR2;
        [SerializeField]
        private GameObject pointR3;
        [SerializeField]
        private GameObject pointR4;
        [SerializeField]
        private GameObject pointR5;

        [SerializeField]
        private GameObject pointS1;
        [SerializeField]
        private GameObject pointS2;
        [SerializeField]
        private GameObject pointS3;
        [SerializeField]
        private GameObject pointS4;
        [SerializeField]
        private GameObject pointS5;


        //public GameObject prefab;
        //------------------------data
        private DRScene SceneData;
        private int SceneNum = 4;                    //场景总数量**

        private List<GameObject> baseObject;
        private List<GameObject> baseBGObject;
        private List<GameObject> points;
        private List<GameObject> pointLs;
        private List<GameObject> pointRs;
        private List<GameObject> pointSs;
        private int lastCloickIndex = 2;
        private bool ismovebg = true;
        //------------------------test
        [SerializeField]
        private Text id_text;
        // Use this for initialization
        private void Awake()
        {
            Data.GetInstance().SaveData_standAlone_Get();
            SceneData = TableDataExtension.GetTableData<DRScene>(Data.GetInstance().getcurrentSceneID());
        }
        void Start()
        {
            baseManage();
            CreateHomeMenuEvent();
            //Debug.Log("我滴个妈妈耶都少钱   "+Data.GetInstance().getCoin() );
        }
        private void OnEnable()
        {
            UIInfoShowBySceneID();
        }

        // Update is called once per frame
        void Update()
        {
            //***模拟解锁章节
            //****模拟关卡
            //if (Input.GetMouseButton(0))
            //{

            //}

        }
        public void CreateHomeMenuEvent()
        {
            //GameEntry.UI.OpenUIForm(UIFormId.HomeMenu, this);
            //prefab = Resources.Load<GameObject>("UI/UIForms/HomeMenu");
            //GameObject clo = Instantiate(prefab);



            var ClickLeftEvent = new UnityEvent();
            ClickLeftEvent.AddListener(ClickLeftButton);
            CommonButton.Get(left).m_OnClick = ClickLeftEvent;

            var ClickRightEvent = new UnityEvent();
            ClickRightEvent.AddListener(ClickRightButton);
            CommonButton.Get(right).m_OnClick = ClickRightEvent;

        }


        // 下发这个章节对应数据信息


        private void ClickLeftButton()
        {
            if (SceneData.SceneOrder == 1)
            {
                //Debug.Log("场景开始");
                return;
            }
            Data.GetInstance().pluscurrentSceneID(-1);
            SceneData = TableDataExtension.GetTableData<DRScene>(Data.GetInstance().getcurrentSceneID());

            UIInfoShowBySceneID();
            //测试
            //Data.GetInstance().plusCoin(50.1f);

        }
        private void ClickRightButton()
        {
            if (SceneData.SceneOrder == SceneNum || Data.GetInstance().getcurrentSceneID() + 1 > Data.GetInstance().getmaxSceneID())
            {
                //Debug.Log("可用场景结束");
                return;
            }

            Data.GetInstance().pluscurrentSceneID(1);
            SceneData = TableDataExtension.GetTableData<DRScene>(Data.GetInstance().getcurrentSceneID());

            UIInfoShowBySceneID();
            //测试
            //Data.GetInstance().plusCoin(-60.1f);
        }
        private void UIInfoShowBySceneID()
        {
            SceneData = TableDataExtension.GetTableData<DRScene>(Data.GetInstance().getcurrentSceneID());
            if (SceneData.SceneOrder <= 2)
            {
                scene_image.sprite = Resources.Load<Sprite>("UI/UIphoto/homeMenuUI/scene_" + SceneData.SceneOrder);
                sceneBG_image.sprite = Resources.Load<Sprite>("UI/UIphoto/homeMenuUI/sceneBG_" + SceneData.SceneOrder);
            }
            else
            {
                scene_image.sprite = Resources.Load("UI/UIphoto/Number_" + SceneData.SceneOrder, typeof(Sprite)) as Sprite;
                sceneBG_image.sprite = Resources.Load<Sprite>("UI/UIphoto/homeMenuUI/sceneBG_" + 1);
            }
            mapName_image.sprite = Resources.Load("UI/UIphoto/" + SceneData.NameAsset, typeof(Sprite)) as Sprite;
            //测试
            //Debug.Log("当前场景 ID" + Data.GetInstance().getcurrentSceneID());
            id_text.text = Data.GetInstance().getcurrentSceneID() + "";
        }



        public void OnClickEvent()
        {
            GameObject currentObj = EventSystem.current.currentSelectedGameObject;
            if (currentObj == baseObject[lastCloickIndex])
            {
                return;
            }
            float choicebgMove = currentObj.GetComponent<RectTransform>().rect.width / 2;
            if (currentObj == baseObject[3] || currentObj == baseObject[4])
            {
                choicebgMove *= -1;
            }
            else if (currentObj == baseObject[2])
            {
                choicebgMove = 0;
            }
            int dex = 0;
            for (int i = 0; i < baseObject.Count; i++)
            {
                if (baseObject[i] == EventSystem.current.currentSelectedGameObject)
                {
                    dex = i;
                    //baseObject[i].transform.position = pointSs[i].transform.position;
                    baseObject[i].transform.position = new Vector3(pointSs[i].transform.position.x, pointSs[i].transform.position.y + 30f, pointSs[i].transform.position.z);
                    if (ismovebg)
                    {
                        baseBGObject[i].transform.position = pointSs[i].transform.position;//1
                    }
                    baseObject[i].transform.Find("name").GetComponent<Image>().enabled = true;
                }
                else
                {
                    baseObject[i].transform.Find("name").GetComponent<Image>().enabled = false;
                }
            }
            //--ps:选择滑块 特殊微调
            if (dex == 4)
            {
                choicebgMove -= 9;
            }
            else if (dex == 3)
            {
                choicebgMove -= 7.8f;
            }
            else if (dex == 2)
            {
                choicebgMove += 5.4f;
            }
            else if (dex == 1)
            {
                choicebgMove -= 5f;
            }
            //---
            Vector3 position = new Vector3(points[dex].transform.position.x + choicebgMove, points[dex].transform.position.y, points[dex].transform.position.z);
            iTween.MoveTo(choice, position, 0.8f);
            //---------------已上无误
            //for (int i = 0; i < baseObject.Count; i++)
            //{
            //    if (currentObj == baseObject[i] && currentObj != baseObject[2])
            //    {
            //        if (i < 2)
            //        {
            //            baseObject[i].transform.position = new Vector3(points[i].transform.position.x + 50f, points[i].transform.position.y + 5f, points[i].transform.position.z);
            //        }
            //        else if (i > 2)
            //        {
            //            baseObject[i].transform.position = new Vector3(points[i].transform.position.x - 50f, points[i].transform.position.y + 5f, points[i].transform.position.z);
            //        }

            //    }
            //    else
            //    {
            //        baseObject[i].transform.position = points[i].transform.position;
            //    }
            //}


            //return;
            for (int i = 0; i < baseObject.Count; i++)
            {
                //if (i >= lastCloickIndex && i <= dex)//位置需要发什么变化的图标（包括上次本次点击对象）
                //{
                float otherMove = points[dex].GetComponent<RectTransform>().rect.width / 2;
                if (dex > lastCloickIndex)//右移
                {
                    if (i >= lastCloickIndex && i < dex)
                    {
                        //if (currentObj == baseObject[dex])
                        //{
                        //    Debug.Log("右 当前点击下标" + dex);
                        //    baseObject[i].transform.position = pointSs[i].transform.position;
                        //}
                        //else
                        //{//受到影响的  往左移动
                        //    baseObject[i].transform.position = pointLs[i].transform.position;
                        //Debug.Log("右移  需要位移的 下标（向左走）：" + (i));
                        //}
                        baseObject[i].transform.position = pointLs[i].transform.position;
                        if (ismovebg)
                        {
                            baseBGObject[i].transform.position = pointLs[i].transform.position;//2
                        }

                        //baseObject[i].transform.position = new Vector3(points[i].transform.position.x - 50f, points[i].transform.position.y , points[i].transform.position.z);
                        //baseBGObject[i].transform.position = new Vector3(baseBGObject[i].transform.position.x - otherMove, baseBGObject[i].transform.position.y, baseBGObject[i].transform.position.z);
                        //baseObject[i].transform.Translate(Vector2.left * 50f);
                        //baseBGObject[i].transform.Translate(Vector2.left * 50f);

                    }
                    else
                    {
                        if (currentObj != baseObject[i])
                        {
                            if (i == 2)
                            {//不许要移动情况下  地图 单独处理
                                if (dex > i)
                                {
                                    baseObject[i].transform.position = pointLs[i].transform.position;//只剩地图单独处理

                                    if (ismovebg)
                                    {
                                        baseBGObject[i].transform.position = pointLs[i].transform.position;//3
                                    }
                                }
                                else
                                {
                                    baseObject[i].transform.position = pointRs[i].transform.position;//只剩地图单独处理

                                    if (ismovebg)
                                    {
                                        baseBGObject[i].transform.position = pointRs[i].transform.position;//4
                                    }
                                }
                            }
                            else
                            {
                                baseObject[i].transform.position = points[i].transform.position;

                                if (ismovebg)
                                {
                                    baseBGObject[i].transform.position = points[i].transform.position;//5
                                }
                            }
                        }

                    }
                }
                else if (dex < lastCloickIndex)//左移
                {
                    if (i <= lastCloickIndex && i > dex)
                    {
                        //if (currentObj== baseObject[dex])
                        //{
                        //    Debug.Log("左 当前点击下标" + dex);
                        //    baseObject[i].transform.position = pointSs[i].transform.position;
                        //}
                        //else
                        //{//受到影响的  往右移动
                        //    baseObject[i].transform.position = pointRs[i].transform.position;

                        //Debug.Log("左移  需要位移的 下标（向右走）：" + (i));
                        //}
                        baseObject[i].transform.position = pointRs[i].transform.position;

                        if (ismovebg)
                        {
                            baseBGObject[i].transform.position = pointRs[i].transform.position;//6
                        }
                        //baseObject[i].transform.position = new Vector3(points[i].transform.position.x + 50f, points[i].transform.position.y , points[i].transform.position.z);
                        //baseBGObject[i].transform.position = new Vector3(baseBGObject[i].transform.position.x + otherMove, baseBGObject[i].transform.position.y, baseBGObject[i].transform.position.z);
                        //baseObject[i].transform.Translate(Vector2.right * 50f);
                        //baseBGObject[i].transform.Translate(Vector2.right * 50f);

                    }
                    else
                    {
                        if (currentObj != baseObject[i])
                        {
                            if (i == 2)
                            {//不许要移动情况下  地图 单独处理
                                if (dex > i)
                                {
                                    baseObject[i].transform.position = pointLs[i].transform.position;//只剩地图单独处理'

                                    if (ismovebg)
                                    {
                                        baseBGObject[i].transform.position = pointLs[i].transform.position;//7
                                    }
                                }
                                else
                                {
                                    baseObject[i].transform.position = pointRs[i].transform.position;//只剩地图单独处理

                                    if (ismovebg)
                                    {
                                        baseBGObject[i].transform.position = pointRs[i].transform.position;//8
                                    }
                                }

                            }
                            else
                            {
                                baseObject[i].transform.position = points[i].transform.position;
                                if (ismovebg)
                                {
                                    baseBGObject[i].transform.position = points[i].transform.position;//9
                                }

                            }

                        }
                    }
                }
                //}
            }

            for (int i = 0; i < baseObject.Count; i++)
            {
                if (baseObject[i] == EventSystem.current.currentSelectedGameObject)
                {
                    EventSystem.current.currentSelectedGameObject.transform.SetLocalScaleX(1.2f);
                    EventSystem.current.currentSelectedGameObject.transform.SetLocalScaleY(1.2f);
                }
                else
                {
                    baseObject[i].transform.SetLocalScaleX(1);
                    baseObject[i].transform.SetLocalScaleY(1);
                }


            }

            //Debug.Log(EventSystem.current.currentSelectedGameObject + "顺序" + dex);
            // 结束 记录 上次点击的导航栏
            lastCloickIndex = dex;
        }


        private void baseManage()
        {
            #region
            baseObject = new List<GameObject>
            {
                box_image,
                equip_image,
                map_image,
                dower_image,
                set_image
            };
            baseBGObject = new List<GameObject>
            {
                boxbg_image,
                equipbg_image,
                mapbg_image,
                dowerbg_image,
                setbg_image
            };
            points = new List<GameObject>
            {
                point1,
                point2,
                point3,
                point4,
                point5
            };
            pointLs = new List<GameObject>
            {
                pointL1,
                pointL2,
                pointL3,
                pointL4,
                pointL5
            };
            pointRs = new List<GameObject>
            {
                pointR1,
                pointR2,
                pointR3,
                pointR4,
                pointR5
            };
            pointSs = new List<GameObject>
            {
                pointS1,
                pointS2,
                pointS3,
                pointS4,
                pointS5
            };
            #endregion
            baseObject[2].transform.position = new Vector3(pointSs[2].transform.position.x, pointSs[2].transform.position.y + 30f, pointSs[2].transform.position.z);
            baseObject[2].transform.Find("name").GetComponent<Image>().enabled = true;
            map_image.transform.SetLocalScaleX(1.2f);
            map_image.transform.SetLocalScaleY(1.2f);
        }

















        private void clickbox()
        {

        }
        private void clickequip()
        {

        }
        private void clickemap()
        {

        }
        private void clickdower()
        {

        }
        private void clickset()
        {

        }





    }
}
