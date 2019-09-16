using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ArrowPlay
{
    public class ChoicesMenuEvent : MonoBehaviour
    {
        [SerializeField]
        private GameObject goBreak;
        [SerializeField]
        private Text EnegyBonusNum_text;
        [SerializeField]
        private Text CoinBonusNum_text;
        [SerializeField]
        private Text GoldBonusNum_text;
        [SerializeField]
        private GameObject ChoiceShowing;
        [SerializeField]
        private GameObject ChoiceLeft;
        [SerializeField]
        private GameObject ChoiceRight;
        [SerializeField]
        private GameObject awardShow01;
        [SerializeField]
        private GameObject awardShow02;
        [SerializeField]
        private GameObject awardShow03;

        [SerializeField]
        private GameObject LockShowing;
        [SerializeField]
        private GameObject LockLeft;
        [SerializeField]
        private GameObject LockRight;

        [SerializeField]
        private Image passLevel;
        [SerializeField]
        private Image allLevels;
        //--------------------test
        [SerializeField]
        private Text L_text;
        [SerializeField]
        private Text R_text;
        [SerializeField]
        private Text S_text;
        [SerializeField]
        private Text passed_text;
        [SerializeField]
        private Text Level_Text;
        [SerializeField]
        private GameObject test_image;
        //-----------------data
        private DRChapter ChapterData;
        private DRBattle LevelData;
        private int ChapterOrder;
        private int ChapterNum;
        private int currentLevelallNum;
        private void Awake()
        {
            ChapterData = TableDataExtension.GetTableData<DRChapter>(Data.GetInstance().getcurrentChapterID());
            LevelData = TableDataExtension.GetTableData<DRBattle>(Data.GetInstance().getcurrentLevelID());
            ChapterNum = TableDataExtension.GetTableData<DRScene>(Data.GetInstance().getcurrentSceneID()).ChapterNum;
            currentLevelallNum = ChapterData.BattleNum;
        }
        void Start()
        {
            goBreak = GameObject.Find("BackButton");
            CreateChoicesMenuEvent();
            Debug.Log("历史最高关卡：" + Data.GetInstance().getmaxPassLevelID());
        }
        void Update()
        {
            //***模拟解锁章节
            //****模拟关卡

            //if (Input.GetMouseButtonDown(0))
            //{
            //    
            //}

            ////模拟进入下一关
            if (Input.GetMouseButtonDown(1))
            {
                UIInfoShowByCurrentLevelID();
            }

            //模拟失败
            if (Input.GetMouseButtonDown(2))
            {
                testLoser();
            }
        }
        private void OnEnable()
        {
            UIInfoShowByChapterID();
        }
        public void CreateChoicesMenuEvent()
        {
            //prefab = Resources.Load<GameObject>("UI/UIForms/ChoiceMenu");
            //GameObject clo = Instantiate(prefab);


            var unityEvent = new UnityEvent();
            unityEvent.AddListener(goback);
            CommonButton.Get(goBreak).m_OnClick = unityEvent;


            var ChoiceLeftEventid = new UnityEvent();
            ChoiceLeftEventid.AddListener(minusChapterID);
            CommonButton.Get(ChoiceLeft).m_OnClick = ChoiceLeftEventid;

            var ChoiceRightEventid = new UnityEvent();
            ChoiceRightEventid.AddListener(plusChapterID);
            CommonButton.Get(ChoiceRight).m_OnClick = ChoiceRightEventid;
            //-----------test
            var testunityEvent = new UnityEvent();
            testunityEvent.AddListener(testPass);
            CommonButton.Get(test_image).m_OnClick = testunityEvent;
        }
        public void goback()
        {
            Debug.Log("返回，DOG");
            Data.GetInstance().setCoin(0);
            GameEntry.UI.GetUIForm(UIFormId.ChoiceMenu).Close(true);
            GameEntry.UI.OpenUIForm(UIFormId.HomeMenu);

        }
        //章节ID 展示：通关奖励&章节选择
        private void UIInfoShowByChapterID()
        {
            ChapterData = TableDataExtension.GetTableData<DRChapter>(Data.GetInstance().getcurrentChapterID());
            currentLevelallNum = ChapterData.BattleNum;
            Data.GetInstance().datachangeByChapter();
            LevelData = TableDataExtension.GetTableData<DRBattle>(Data.GetInstance().getcurrentLevelID());
            isshowLRLevle();
            Level_Text.text = Data.GetInstance().getcurrentLevelID() + "";
            passLevelUIshow();
            Debug.Log(LevelData.BattleOrder);
            if (ChapterData == null)
            {
                Debug.Log("小老弟你怎么了");
                return;
            }
            EnegyBonusNum_text.text = ChapterData.EnegyBonusNum + "";
            CoinBonusNum_text.text = ChapterData.CoinBonusNum + "";
            GoldBonusNum_text.text = ChapterData.GoldBonusNum + "";

            S_text.text = ChapterData.ChapterOrder + "";
            ChoiceShowing.GetComponent<Image>().sprite = Resources.Load("UI/UIphoto/choiceMenuUI/chaptericon_" + (ChapterData.ChapterOrder), typeof(Sprite)) as Sprite;
            if (ChapterData.ChapterOrder == 1)
            {
                L_text.text = "";
            }
            else
            {
                L_text.text = ChapterData.ChapterOrder - 1 + "";
                ChoiceLeft.GetComponent<Image>().sprite = Resources.Load("UI/UIphoto/choiceMenuUI/chaptericon_" + (ChapterData.ChapterOrder - 1), typeof(Sprite)) as Sprite;
            }
            if (ChapterData.ChapterOrder == ChapterNum)
            {
                R_text.text = "";
            }
            else
            {
                R_text.text = ChapterData.ChapterOrder + 1 + "";
                ChoiceRight.GetComponent<Image>().sprite = Resources.Load("UI/UIphoto/choiceMenuUI/chaptericon_" + (ChapterData.ChapterOrder + 1), typeof(Sprite)) as Sprite;
            }
        }
        //章节++事件
        private void plusChapterID()
        {
           

            // 当前章节序列对比场景章节数量
            //-------解锁下章等游戏场景返回创关成功添加
            if (ChapterData.ChapterOrder == ChapterNum || Data.GetInstance().getcurrentChapterID() + 1 > Data.GetInstance().getmaxPassChapterID())
            {
                Debug.Log("可用章节结束");
                return;
            }
            Data.GetInstance().pluscurrentChapterID(1);
            UIInfoShowByChapterID();

        }
        //章节--事件
        private void minusChapterID()
        {
            if (ChapterData.ChapterOrder == 1)
            {
                Debug.Log("章节最初");
                return;
            }
            //Debug.Log(ChapterData.ChapterOrder + "章节序号");     
            Data.GetInstance().pluscurrentChapterID(-1);
            UIInfoShowByChapterID();
        }
        private void isshowLRLevle()
        {
            if (ChapterData.ChapterOrder == 1)
            {
                ChoiceLeft.SetActive(false);
            }
            else
            {
                ChoiceLeft.SetActive(true);
            }

            if (ChapterData.ChapterOrder == ChapterNum)
            {
                ChoiceRight.SetActive(false);    
            }
            else
            {
                ChoiceRight.SetActive(true);
            }

            //------------LOCK
            if (ChapterData.ChapterOrder != ChapterNum)
            {
                if (Data.GetInstance().getcurrentChapterID() >= Data.GetInstance().getmaxPassChapterID())
                {
                    ChoiceRight.GetComponent<Image>().color = Color.gray;
                    LockRight.SetActive(true);
                    ChoiceRight.GetComponent<Button>().enabled = false;
                }
                else
                {
                    ChoiceRight.GetComponent<Image>().color = Color.white;
                    LockRight.SetActive(false);
                    ChoiceRight.GetComponent<Button>().enabled = true;
                }
            }

        }
        /// <summary>
        /// 展示 关卡 相关信息 
        /// </summary>
        private void UIInfoShowByCurrentLevelID()
        {
            if (LevelData.BattleOrder == currentLevelallNum)
            {
                Debug.Log("当前章节已完成---结算界面，玩家选择下个章节");
                Level_Text.text = "模拟通关";
                test_image.SetActive(true);
                return;
            }
            Data.GetInstance().pluscurrentLevelID(1);
            refreshMaxLevel();
            LevelData = TableDataExtension.GetTableData<DRBattle>(Data.GetInstance().getcurrentLevelID());
            Level_Text.text = Data.GetInstance().getcurrentLevelID() + "";
        }
        //我失败了
        private void testLoser()
        {
            passLevelUIshow();
            int Chapter = Data.GetInstance().getcurrentChapterID();
            Data.GetInstance().setcurrentLevelID(int.Parse(Chapter + "01"));
            LevelData = TableDataExtension.GetTableData<DRBattle>(Data.GetInstance().getcurrentLevelID());
            Level_Text.text = Data.GetInstance().getcurrentLevelID() + "";
            Debug.Log("失败");

        }
        // 通关点击事件--->开启新章程/开启新场景
        private void testPass()
        {
            if (ChapterData.ChapterOrder == ChapterNum)
            {
                //本场景所有章节全部完成 开启下个场景***预留
                Data.GetInstance().pluscurrentSceneID(1);
                Data.GetInstance().datachangeByScene();
                refreshMaxLevel();

                Debug.Log("章节结束");
                test_image.SetActive(false);
                goback();
                return;
            }
            Data.GetInstance().pluscurrentChapterID(1);
            UIInfoShowByChapterID();
            LevelData = TableDataExtension.GetTableData<DRBattle>(Data.GetInstance().getcurrentLevelID());
            refreshMaxLevel();
            passLevelUIshow();
            test_image.SetActive(false);
        }

        /// <summary>
        /// 新纪录关卡升级/解锁新章节/解锁新场景
        /// </summary> 
        private void refreshMaxLevel()
        {
            if (Data.GetInstance().getcurrentLevelID() >= Data.GetInstance().getmaxPassLevelID())
            {
                Data.GetInstance().setmaxPassLevelID(Data.GetInstance().getcurrentLevelID());
                Debug.Log("刷新历史最高关卡：" + Data.GetInstance().getmaxPassLevelID());
            }
        }

        private void passLevelUIshow()
        {
            //passed_text.text = LevelData.BattleOrder + "/" + ChapterData.BattleNum;
            passLevel.sprite = Resources.Load("UI/UIphoto/choiceMenuUI/num_" + (LevelData.BattleOrder), typeof(Sprite)) as Sprite;
            allLevels.sprite = Resources.Load("UI/UIphoto/choiceMenuUI/num_" + (ChapterData.BattleNum), typeof(Sprite)) as Sprite;
        }


    }
}
