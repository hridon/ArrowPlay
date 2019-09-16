using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ChoiceMenuEvent : MonoBehaviour
{
    private float fingerActionSensitivity = Screen.width * 0.05f; //手指动作的敏感度，这里设定为 二十分之一的屏幕宽度.

    private float fingerBeginX;
    private float fingerBeginY;
    private float fingerCurrentX;
    private float fingerCurrentY;
    private float fingerSegmentX;
    private float fingerSegmentY;
    //
    private int fingerTouchState;
    //
    private int FINGER_STATE_NULL = 0;
    private int FINGER_STATE_TOUCH = 1;
    private int FINGER_STATE_ADD = 2;

    private bool isMove;
    //物体
    public GameObject Cn;
    public GameObject showing;
    public GameObject showLeft;
    public GameObject showRight;


    public GameObject LeftPoint;
    public GameObject RightPoint;
    public GameObject ShowingPoint;
    // Use this for initialization
    void Start()
    {
        createPrafebShow();
        Eventigger();


        isMove = false;

        fingerActionSensitivity = Screen.width * 0.05f;

        fingerBeginX = 0;
        fingerBeginY = 0;
        fingerCurrentX = 0;
        fingerCurrentY = 0;
        fingerSegmentX = 0;
        fingerSegmentY = 0;

        fingerTouchState = FINGER_STATE_NULL;

    }

    // Update is called once per frame
    void Update()
    {
        transform.SetAsLastSibling();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (fingerTouchState == FINGER_STATE_NULL)
            {
                fingerTouchState = FINGER_STATE_TOUCH;
                fingerBeginX = Input.mousePosition.x;
                fingerBeginY = Input.mousePosition.y;
            }

        }

        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            fingerCurrentX = Input.mousePosition.x;
            fingerCurrentY = Input.mousePosition.y;
            fingerSegmentX = fingerCurrentX - fingerBeginX;
            fingerSegmentY = fingerCurrentY - fingerBeginY;

        }


        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            float fingerDistance = fingerSegmentX * fingerSegmentX + fingerSegmentY * fingerSegmentY;

            if (fingerDistance > (fingerActionSensitivity * fingerActionSensitivity))
            {
                if (isMove == true)
                {
                    toAddFingerAction();
                }

            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fingerTouchState = FINGER_STATE_NULL;

            isMove = false;
        }
    }
    private void toAddFingerAction()
    {

        fingerTouchState = FINGER_STATE_ADD;

        if (Mathf.Abs(fingerSegmentX) > Mathf.Abs(fingerSegmentY))
        {
            fingerSegmentY = 0;
        }
        else
        {
            fingerSegmentX = 0;
        }

        if (fingerSegmentX == 0)
        {
            if (fingerSegmentY > 0)
            {
                Debug.Log("up");
            }
            else
            {
                Debug.Log("down");
            }
        }
        else if (fingerSegmentY == 0)
        {
            if (fingerSegmentX > 0)
            {
                Debug.Log("right");
                iTween.MoveTo(showing, RightPoint.transform.position, 1.5f);
                iTween.MoveTo(showLeft, ShowingPoint.transform.position, 1.5f);
                //Hashtable args = new Hashtable();
                //args.Add("x", 200);
                //iTween.MoveTo(obj, args);

            }
            else
            {
                Debug.Log("left");
                iTween.MoveTo(showing, LeftPoint.transform.position, 1.5f);

                iTween.MoveTo(showRight, ShowingPoint.transform.position, 1.5f);
                //Hashtable args = new Hashtable();
                //args.Add("x", -200);
                //iTween.MoveTo(obj, args);

            }
        }

    }
    private void createPrafebShow()
    {
        showing = Instantiate(Resources.Load<GameObject>("SlideChoiceShow"));
        showing.transform.SetParent(Cn.gameObject.transform);
        showing.transform.position = ShowingPoint.transform.position;


        //showLeft = Resources.Load<GameObject>("SlideChoiceShow");
        //GameObject obj = Instantiate(showLeft);
        showLeft = Instantiate(Resources.Load<GameObject>("SlideChoiceShow"));
        showLeft.transform.SetParent(Cn.gameObject.transform);
        showLeft.transform.position = LeftPoint.transform.position;

        //showLeft.tag = "Left";
        showRight = Instantiate(Resources.Load<GameObject>("SlideChoiceShow"));
        //var objR = Resources.Load<GameObject>("SlideChoiceShow");
        //showRight = Instantiate(objR);
        showRight.transform.SetParent(Cn.gameObject.transform);
        showRight.transform.position = RightPoint.transform.position;
        //showRight.tag = "Right";

        //Destroy(gameObject);
    }
    private void recoverPosition()
    {

    }
    private void Eventigger()
    {
        UnityAction<BaseEventData> click = new UnityAction<BaseEventData>(MyClick);
        EventTrigger.Entry myclick = new EventTrigger.Entry();
        myclick.eventID = EventTriggerType.PointerDown;
        myclick.callback.AddListener(click);

        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        trigger.triggers.Add(myclick);
    }
    public void MyClick(BaseEventData data)
    {

        isMove = true;
        Debug.Log("点击");
    }
    private void Destroy()
    {
        
    }
}
