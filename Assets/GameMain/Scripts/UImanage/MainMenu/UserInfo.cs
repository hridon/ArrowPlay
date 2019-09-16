using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArrowPlay
{
    public class UserInfo : MonoBehaviour
    {
        public static int Level;
        public static float Energy;
        public static float Money;
        public static float Coin;
        public Slider ExpSlider;
        public Text leveltext;
        public Text energyText;
        public Text moneyext;
        public Text coinText;

        private void Awake()
        {

        }
        // Use this for initialization
        void Start()
        {
            
        }
        private void OnEnable()
        {
            initUserInfoUI();
        }

        // Update is called once per frame
        void Update()
        {
            if (ExpSlider.value < 1)
            {
                if (Input.GetMouseButton(1))
                {
                    ExpSlider.value += 0.001f;
                }
            }
            else
            {
                Level++;
                leveltext.text = "" + Level;
                ExpSlider.value = 0;
            }

            if (Input.GetMouseButton(1))
            {
                //Coin += 0.1f;
                Data.GetInstance().plusCoin(0.5f);
                coinText.text = Data.GetInstance().getCoin() + "";
            }
        }

        public void initUserInfoUI()
        {
            Level = 100;
            Energy = 100;
            Money = 100;
            Coin = 100;
            leveltext.text = Level + "";
            energyText.text = Energy + "";
            moneyext.text = Money + "";
            coinText.text = Data.GetInstance().getCoin()+"";

        }
    }
}