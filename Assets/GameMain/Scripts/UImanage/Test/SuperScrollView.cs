using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArrowPlay
{
    public class SuperScrollView : MonoBehaviour
    {

        private ScrollRect mScrollRect;
        private RectTransform mContentRect;

        public GameObject itemPrefab;
        public float itemHeight;//item的高度（全都一样）
        public int maxItemCount; //最大item生成数量，真实item生成数量的阀值
        public int datasNum;//数据数量
        private int currentItemCount;//已生成的item的数量

        //记录最上和最下的item索引
        private int firstIndex;
        private int lastIndex;
        private List<GameObject> itemList;
        //--------------------ui

        [SerializeField]
        private Text name;
        [SerializeField]
        private Text describe;

        //-----------------data
        private int skillID = 4001;
        private int luckNum = 4001;
        private bool isClick = false;
        private List<int> itemID;
        // Use this for initialization

        private void Awake()
        {

        }

        void Start()
        {
            itemList = new List<GameObject>();
            mScrollRect = transform.GetComponent<ScrollRect>();
            mContentRect = mScrollRect.content.transform.GetComponent<RectTransform>();
            mScrollRect.onValueChanged.AddListener((Vector2 vec) => OnScrollMove(vec));
            luckNum = Random.Range(4001, 4063);
            Debug.Log(luckNum + "随机ID");
            GetDrawList();
            SetScroller();
        }
        private void Update()
        {
            luckyDraw();
        }

        public void SetScroller()
        {
            SetContentHeight();
            InitCountent();
        }

        //设置滚动条的Content高度
        public void SetContentHeight()
        {
            mContentRect.sizeDelta = new Vector2(mContentRect.sizeDelta.x, itemHeight * datasNum);
        }

        //初始化生成固定数量的Item
        public void InitCountent()
        {
            int needItem = Mathf.Clamp(datasNum, 0, maxItemCount + 1);
            for (int i = 0; i < needItem; i++)
            {
                GameObject _obj = Instantiate(itemPrefab);
                _obj.transform.SetParent(mContentRect.transform);
                _obj.name = (i + 1).ToString();
                //_obj.transform.Find("Text").GetComponent<Text>().text = (i + 1).ToString();
                RectTransform _rectTrans = _obj.GetComponent<RectTransform>();
                _rectTrans.pivot = new Vector2(0.5f, 1);
                _rectTrans.anchorMax = new Vector2(0.5f, 1);
                _rectTrans.anchorMin = new Vector2(0.5f, 1);
                _rectTrans.anchoredPosition = new Vector2(0, -itemHeight * currentItemCount);
                currentItemCount += 1;
                skillID++;
                lastIndex = i;
                itemList.Add(_obj);
                //Debug.Log("下标"+lastIndex);
            }
        }

        private void OnScrollMove(Vector2 pVec)
        {
            //向下滚动
            while (mContentRect.anchoredPosition.y > (firstIndex + 1) * itemHeight && lastIndex != datasNum - 1)
            {
                //思路是List中的保存的GameObject顺序与真实显示的物体保持一致
                GameObject _first = itemList[0];
                RectTransform _rectTrans = _first.GetComponent<RectTransform>();
                //将首个物体移出List，再添加到List最后端
                itemList.RemoveAt(0);
                itemList.Add(_first);
                //将这个物体移到最下方
                _rectTrans.anchoredPosition = new Vector2(0, -(lastIndex + 1) * itemHeight);
                firstIndex += 1;
                lastIndex += 1;
                //修改显示
                //_first.name = (lastIndex + 1).ToString();
                //_first.transform.Find("Text").GetComponent<Text>().text = _first.name;
                Debug.Log("idex"+lastIndex);
                if (lastIndex == datasNum - 1)
                {
                    skillID = luckNum;//偷天换柱
                    isClick = true;//结束可点击
                }else
                {
                    skillID = itemID[lastIndex];
                }
                DRSkillDrop SkillData = TableDataExtension.GetTableData<DRSkillDrop>(skillID);
                _first.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/UIphoto/SkillChoiceMenuUI/skill_icon/" + SkillData.Preferb);
                //luckNum
                _first.name = SkillData.Skill;
                skillID++;

                //Debug.Log("下标" + lastIndex);
            }
            //向上滚动
            while (mContentRect.anchoredPosition.y < firstIndex * itemHeight && firstIndex != 0)
            {
                GameObject _last = itemList[itemList.Count - 1];
                RectTransform _rectTrans = _last.GetComponent<RectTransform>();
                itemList.RemoveAt(itemList.Count - 1);
                itemList.Insert(0, _last);
                _rectTrans.anchoredPosition = new Vector2(0, -(firstIndex - 1) * itemHeight);
                firstIndex -= 1;
                lastIndex -= 1;
                _last.name = firstIndex.ToString();
                //_last.transform.Find("Text").GetComponent<Text>().text = _last.name;
            }
        }
        /// <summary>
        /// 星轮抽奖
        /// </summary>
        private void luckyDraw()
        {
            if (transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value > 0)
            {
                if (transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value < 0.15f)
                {
                    transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value -= 0.0001f;
                }
                else
                {
                    transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value -= 0.0005f;
                }
                if (datasNum % 2 == 0)
                {
                    name.text = "" + transform.Find("Viewport").GetChild(0).GetChild(1).name;//总道具双数读子物体第二个 ps：其实中间一直读第一个只是最后一个落到了第二个
                }
                else
                {
                    name.text = "" + transform.Find("Viewport").GetChild(0).GetChild(0).name;//总道具单数读子物体第一个
                }

            }
        }

        /// <summary>
        /// 随机中奖
        /// </summary>
        private void GetDrawList()
        {
            itemID = new List<int>();
            for (int i = 0; i < datasNum; i++)
            {
                itemID.Add(4001 + i);
            }
            if (itemID.Count == datasNum)
            {
                for (int i = 0; i < itemID.Count; i++)
                {
                    int randomNum = Random.Range(0, itemID.Count);
                    int wait = itemID[randomNum];
                    itemID[randomNum] = itemID[i];
                    itemID[i] = wait;
                }
            }
        }
        private void randomSort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int randomNum = Random.Range(0, list.Count);
                int wait = list[randomNum];
                list[randomNum] = list[i];
                list[i] = wait;
            }
        }
        public void ClickEvent()
        {
            DRSkillDrop SkillData = TableDataExtension.GetTableData<DRSkillDrop>(luckNum);
            if (isClick)
            {
                describe.text = SkillData.Description;
            }
            else
            {
                describe.text = "";
            }

        }
        public void ResetDraw()
        {
            skillID = 4001;
            isClick = false;
            luckNum = Random.Range(4001, 4063);
            transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value = 1;
        }
    }
}