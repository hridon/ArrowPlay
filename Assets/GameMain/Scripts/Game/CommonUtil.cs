using System.Collections.Generic;
using UnityEngine;

namespace ArrowPlay
{
    public class CommonUtil 
    {
        private static CommonUtil _instance = null;
        public static CommonUtil GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CommonUtil();
            }
            return _instance;
        }
        /// <summary>
        /// 根据权重生成列表(实例化对象是ID)
        /// </summary>
        /// <returns></returns>
        public List<int> CreateListForrandmDraw()
        {
            List<int> AllDraw=new List<int>();


            


            return AllDraw;
        }

        /// <summary>
        /// 中奖
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int RandomDraw(List<int> list)
        {
            int luckindex = Random.Range(0, list.Count);
            return list[luckindex];
        }

    }
}
