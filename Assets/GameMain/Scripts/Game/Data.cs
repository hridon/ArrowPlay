using UnityEngine;

namespace ArrowPlay
{
    public class Data
    {
        private static Data _instance = null;
        public static Data GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Data();
            }
            return _instance;
        }
        /// <summary>
        /// 玩家金币
        /// </summary>
        private float coin = 404;

        /// <summary>
        /// 当前选择场景ID
        /// </summary>
        private int currentSceneID = 601;

        /// <summary>
        /// 当前选择章节ID
        /// </summary>
        private int currentChapterID = 60101;

        /// <summary>
        /// 当前选择关卡ID
        /// </summary>
        private int currentLevelID = 6010101;

        /// <summary>
        /// 玩家关卡最高纪录（在玩/可玩）
        /// </summary>
        private int maxPassLevelID= 6030301;


        public float getCoin()
        {
            return coin;
        }

        public void setCoin(float num)
        {
            coin = num;
        }

        public void plusCoin(float num)
        {
            coin += num;
            //SaveData_standAlone_Set(coin);
            PlayerPrefs.SetFloat("data_coin", coin);
        }

        public int getcurrentSceneID()
        {
            return currentSceneID;
        }

        public void setcurrentSceneID(int num)
        {
            currentSceneID = num;
            PlayerPrefs.SetFloat("data_currentSceneID", currentSceneID);
        }

        public void pluscurrentSceneID(int num)
        {
            currentSceneID += num;
            PlayerPrefs.SetFloat("data_currentSceneID", currentSceneID);
        }

        public int getcurrentChapterID()
        {
            return currentChapterID;
        }

        public void setcurrentChapterID(int num)
        {
            currentChapterID = num;
            PlayerPrefs.SetFloat("data_currentChapterID", currentChapterID);
        }

        public void pluscurrentChapterID(int num)
        {
            currentChapterID += num;
            PlayerPrefs.SetFloat("data_currentChapterID", currentChapterID);
        }


        public int getcurrentLevelID()
        {
            return currentLevelID;
        }

        public void setcurrentLevelID(int num)
        {
            currentLevelID = num;
            PlayerPrefs.SetFloat("data_currentLevelID", currentLevelID);
        }

        public void pluscurrentLevelID(int num)
        {
            currentLevelID += num;
            PlayerPrefs.SetFloat("data_currentLevelID", currentLevelID);
        }


        public int getmaxPassLevelID()
        {
            return maxPassLevelID;
        }

        //*******游戏场景内关卡通关 需调用此纪录
        public void setmaxPassLevelID(int num)
        {
            maxPassLevelID = num;
            PlayerPrefs.SetFloat("data_maxPassLevelID", maxPassLevelID);
        }




        public void SaveData_standAlone_Get()
        {
            Data.GetInstance().setCoin(PlayerPrefs.GetFloat("data_coin"));
            //Data.GetInstance().setCoin(PlayerPrefs.GetFloat("data_currentSceneID"));
            //Data.GetInstance().setCoin(PlayerPrefs.GetFloat("data_currentChapterID"));
            //Data.GetInstance().setCoin(PlayerPrefs.GetFloat("data_currentLevelID"));
            //Data.GetInstance().setCoin(PlayerPrefs.GetFloat("data_maxPassLevelID"));
        }

        // 暂未使用
        public void SaveData_standAlone_Set(float data)
        {
            PlayerPrefs.SetFloat("data_coin", data);
            PlayerPrefs.SetFloat("data_currentSceneID", data);
        }

        /// <summary>
        /// 场景切换对应改变章节及关卡信息
        /// </summary>
        /// <param name="scene"></param>
        public void datachangeByScene()
        {

            int scene = getcurrentSceneID();
            //Debug.Log("场景切换  章节ID  data   " + int.Parse(scene + "01"));
            //Debug.Log("场景切换  关卡ID  data   " + int.Parse(scene + "0101"));
            setcurrentChapterID(int.Parse(scene + "01"));
            setcurrentLevelID(int.Parse(scene + "0101"));
          
        }

        /// <summary>
        /// 章节切换对应改变关卡信息
        /// </summary>
        /// <param name="Chapter"></param>
        public void datachangeByChapter()
        {
            int Chapter = getcurrentChapterID();
            //Debug.Log("章节切换  关卡ID  data   " + int.Parse(Chapter + "01"));
            setcurrentLevelID(int.Parse(Chapter + "01"));
        }

        public int getmaxSceneID()
        {
            return TableDataExtension.GetTableData<DRChapter>(Data.GetInstance().getmaxPassChapterID()).SceneId;
        }

        public int getmaxPassChapterID()
        {
            return  TableDataExtension.GetTableData<DRBattle>(Data.GetInstance().getmaxPassLevelID()).ChapterId;
        }

       
    }

}
