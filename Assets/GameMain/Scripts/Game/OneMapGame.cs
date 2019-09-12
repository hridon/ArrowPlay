using BehaviorDesigner.Runtime;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    public class OneMapGame : GameBase
    {
        public override GameMode GameMode
        {
            get
            {
                return GameMode.OneMap;
            }
        }

        private ArrowPlayer m_ArrowPlayer=null;
        /// <summary>
        /// 实例化
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            ////加载玩家
            //GameEntry.CurEntity.ShowArrowPlay(new ArrowPlayerData(GameEntry.CurEntity.GenerateSerialId(),1,10000,1f,1f,1f,2001,null));
            ////加载怪物
            //GameEntry.CurEntity.ShowMonster(new MonsterData(GameEntry.CurEntity.GenerateSerialId(),1001,null));
            //GameEntry.CurEntity.ShowMonster(new MonsterData(GameEntry.CurEntity.GenerateSerialId(), 1002, null));

            //加载玩家
            var m_ArrowPlayer = UIMapManager.Instance.PlayerManager.CreatePlayer(new Vector3(0, 0, -10), 0, 2001);
            //设置全局行为树变量
            var sharedGameObj=new SharedGameObject();
            sharedGameObj.Value = m_ArrowPlayer.gameObject;
            GlobalVariables.Instance.SetVariable("Player",  sharedGameObj);
            //加载关卡xml数据
            LevelData levelData = GameData.Instance().GetCurLevelId().GetLevelMapData();
            //根据关卡xml数据加载怪物
            if (levelData.m_LevelMonsterDatas != null && levelData.m_LevelMonsterDatas.Count > 0)
            {
                foreach (var monsterData in levelData.m_LevelMonsterDatas)
                {
                    UIMapManager.Instance.MonsterManager.CreateMonster(monsterData.GetPosition(), monsterData.m_Scale, GameEntry.Entity.GenerateSerialId(), monsterData.m_MonsterId);
                }
            }
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);

            if (m_ArrowPlayer != null && m_ArrowPlayer.IsDead)
            {
                IsGameOver = true;
                return;
            }
            else if (m_ArrowPlayer != null && m_ArrowPlayer.isGameSuccess)
            {
                IsGameOver = true;
                return;
            }
        }

        public override void OnLeave()
        {
            m_ArrowPlayer = null;
            base.OnLeave();
        }
    }
}
