using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ArrowPlay
{
    public class LevelXmlManager
    {
        private bool inited = false;

        private static LevelXmlManager instance;

        public static LevelXmlManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelXmlManager();
                    instance.Initialize(AssetUtility.GetXmlAsset("Level"));
                }
                return instance;
            }
        }

        public bool Initialize(string filename)
        {
            if (!inited)
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (Application.platform == RuntimePlatform.Android)
                {
                    WWW www = new WWW(filename);
                    while (!www.isDone)
                    {
                    }
                    System.IO.StringReader stringReader = new System.IO.StringReader(www.text);
                    stringReader.Read(); // 跳过 BOM 

                    xmlDoc.LoadXml(stringReader.ReadToEnd());
                }
                else
                {
                    xmlDoc.Load(filename);
                }
                LoadData(xmlDoc);

                inited = true;
            }

            return inited;
        }

        void LoadData(XmlDocument xmlDoc)
        {
            m_MapXmlDataDic.Clear();

            XmlNode root = xmlDoc.SelectSingleNode("map");
            XmlNodeList levelNodeList = root.SelectNodes("level");
            foreach (XmlNode node in levelNodeList)
            {
                XmlElement curElement = (XmlElement) node;
                int levelId = Int32.Parse(curElement.GetAttribute("id"));

                if (m_MapXmlDataDic.ContainsKey(levelId))
                {
                    Debug.LogError("levelId has same! " + levelId);
                    continue;
                }
                int width = Int32.Parse(curElement.GetAttribute("width"));
                int height = Int32.Parse(curElement.GetAttribute("height"));

                XmlNodeList monsterNodeList = node.SelectNodes("monster");

                List<LevelMonsterData> monsters=new List<LevelMonsterData>();

                if (monsterNodeList != null)
                {
                    foreach (XmlNode monsterNode in monsterNodeList)
                    {
                        XmlElement curMonsterNode = (XmlElement)monsterNode;
                        int monsterId = Int32.Parse(curMonsterNode.GetAttribute("id"));
                        float scale = float.Parse(curMonsterNode.GetAttribute("scale"));
                        float positonX = float.Parse(curMonsterNode.GetAttribute("positionX"));
                        float positonZ = float.Parse(curMonsterNode.GetAttribute("positionZ"));

                        var monsterData = new LevelMonsterData(monsterId);
                        monsterData.m_Scale = scale;
                        monsterData.m_PosX = positonX;
                        monsterData.m_PosZ = positonZ;

                        monsters.Add(monsterData);
                    }
                }

                var levelData = new LevelData(levelId);
                levelData.m_Widht = width;
                levelData.m_Height = height;
                levelData.m_LevelMonsterDatas = monsters;

                m_MapXmlDataDic.Add(levelId,levelData);
            }
        }

        private Dictionary<int, LevelData> m_MapXmlDataDic = new Dictionary<int, LevelData>();

        public Dictionary<int, LevelData> MapXmlDataDic { get { return m_MapXmlDataDic; } }
    }

    public class LevelMonsterData
    {
        public int m_MonsterId;
        public float m_Scale;
        public float m_PosX;
        public float m_PosZ;
        public LevelMonsterData(int monsterId)
        {
            m_MonsterId = monsterId;
        }

        public Vector3 GetPosition()
        {
            return new Vector3(m_PosX,0,m_PosZ);
        }
    }

    public class LevelData
    {
        public int m_LevelId;
        public int m_Widht;
        public int m_Height;
        public List<LevelMonsterData> m_LevelMonsterDatas;
        public LevelData(int levelId)
        {
            m_LevelId = levelId;

        }
    }
}
