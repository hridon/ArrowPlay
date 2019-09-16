using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowPlay
{
    public class GameData
    {
        private static GameData m_GameData = null;

        public static GameData Instance()
        {
            if (m_GameData == null)
            {
                m_GameData = new GameData();
            }
            return m_GameData;
        }

        private bool m_GameState = false;

        public bool GameState
        {
            get
            {
                var state = m_GameState;
                m_GameState = false;
                return state;
            }
            set { m_GameState = value; }
        }

        List<int> m_MapLevelIds = new List<int>();

        public List<int> mapLevelIds
        {
            get { return m_MapLevelIds; }
        }

        public void SetMapLevel(int levelId)
        {
            m_MapLevelIds = new List<int> {levelId};
        }

        public void SetMapLevel(List<int> levelIds)
        {
            m_MapLevelIds = levelIds;
        }

        public string GetMapName()
        {
            return "Map";
        }

        public int GetCurLevelId()
        {
            return 1;
        }
    }
}

