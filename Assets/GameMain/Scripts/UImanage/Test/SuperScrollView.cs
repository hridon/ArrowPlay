using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Image test;
    [SerializeField]
    private Text name;

    // Use this for initialization
    void Start()
    {
        itemList = new List<GameObject>();
        mScrollRect = transform.GetComponent<ScrollRect>();
        mContentRect = mScrollRect.content.transform.GetComponent<RectTransform>();
        mScrollRect.onValueChanged.AddListener((Vector2 vec) => OnScrollMove(vec));

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
            _obj.name = i.ToString();
            _obj.transform.Find("Text").GetComponent<Text>().text = i.ToString();
            RectTransform _rectTrans = _obj.GetComponent<RectTransform>();
            _rectTrans.pivot = new Vector2(0.5f, 1);
            _rectTrans.anchorMax = new Vector2(0.5f, 1);
            _rectTrans.anchorMin = new Vector2(0.5f, 1);
            _rectTrans.anchoredPosition = new Vector2(0, -itemHeight * currentItemCount);
            currentItemCount += 1;
            lastIndex = i;
            itemList.Add(_obj);
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
            _first.name = lastIndex.ToString();
            _first.transform.Find("Text").GetComponent<Text>().text = _first.name;
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
            _last.transform.Find("Text").GetComponent<Text>().text = _last.name;
        }
    }
    /// <summary>
    /// 星轮抽奖
    /// </summary>
    private void luckyDraw()
    {
        if (transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value > 0)
        {
            if (transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value < 0.05f)
            {
                transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value -= 0.001f;
            }
            else
            {
                transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value -= 0.005f;
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
}