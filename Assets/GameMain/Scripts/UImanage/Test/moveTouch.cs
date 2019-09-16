using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class moveTouch : MonoBehaviour//jarodInputController
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
    //public GameObject obj;
    public GameObject LeftPoint;
    public GameObject RightPoint;
    public GameObject ShowingPoint;

    private ChoiceMenuEvent test;
    // Use this for initialization
    void Start()
    {
        test = new ChoiceMenuEvent();
        LeftPoint = GameObject.Find("Left");
        RightPoint = GameObject.Find("Right");
        ShowingPoint = GameObject.Find("Showing");

        isMove = false;

        fingerActionSensitivity = Screen.width * 0.05f;

        fingerBeginX = 0;
        fingerBeginY = 0;
        fingerCurrentX = 0;
        fingerCurrentY = 0;
        fingerSegmentX = 0;
        fingerSegmentY = 0;

        fingerTouchState = FINGER_STATE_NULL;
        Eventigger();
    }
    // Update is called once per frame
    void Update()
    {

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
                iTween.MoveTo(gameObject, RightPoint.transform.position, 1.5f);
                iTween.MoveTo(gameObject, RightPoint.transform.position, 1.5f);
                //Hashtable args = new Hashtable();
                //args.Add("x", 200);
                //iTween.MoveTo(obj, args);

            }
            else
            {
                Debug.Log("left");
                iTween.MoveTo(gameObject, LeftPoint.transform.position, 1.5f);
          
              
                //Hashtable args = new Hashtable();
                //args.Add("x", -200);
                //iTween.MoveTo(obj, args);

            }
        }

    }

    public void testStart()
    {

    }
    public void testEnd()
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
}
