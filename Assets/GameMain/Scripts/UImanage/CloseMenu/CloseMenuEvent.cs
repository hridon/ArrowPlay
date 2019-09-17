using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenuEvent : MonoBehaviour
{
    [SerializeField]
    private Slider ExpSlider;
    [SerializeField]
    private Image imagetest;
    // Use this for initialization
    void Start()
    {
        //imagetest.sprite = Resources.Load<Sprite>("UI/UIphoto/homeMenuUI_1");
        //imagetest.sprite = Resources.Load("UI/UIphoto/homeMenuUI/homeMenuUI_1", typeof(Sprite)) as Sprite;
        //int i = 0;
        //System.Type type = i.GetType();
        //Debug.Log(type);
    }

    // Update is called once per frame
    void Update()
    {
        if (ExpSlider.value < 1)
        {
            if (Input.GetMouseButton(1))
            {
                ExpSlider.value += 0.005f;
            }
        }
        else
        {
            ExpSlider.value = 0;
        }



        if (ExpSlider.value < 1)
        {
            test(0.5f);
        }
        else
        {
            ExpSlider.value = 0;
        }
    }



    private void test(float exp)
    {
        if (ExpSlider.value < exp)
        {
            ExpSlider.value += 0.005f;
        }
        
    }
}
