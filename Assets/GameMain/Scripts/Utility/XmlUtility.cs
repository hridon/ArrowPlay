using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace ArrowPlay
{
    public static class XmlUtility
    {
        public static LevelData GetLevelMapData(this int levelId)
        {
            if (LevelXmlManager.Instance.MapXmlDataDic.ContainsKey(levelId))
            {
                return LevelXmlManager.Instance.MapXmlDataDic[levelId];
            }
            else
            {
                return null;
            }
        }
    }

}


