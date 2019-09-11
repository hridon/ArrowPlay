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


            var m_ArrowPlayer = UIMapManager.Instance.PlayerManager.CreatePlayer(new Vector3(0, 0, -10), 0, 2001);

            var sharedGameObj=new SharedGameObject();
            sharedGameObj.Value = m_ArrowPlayer.gameObject;
            GlobalVariables.Instance.SetVariable("Player",  sharedGameObj);

            UIMapManager.Instance.MonsterManager.CreateMonster(new Vector3(-1,0,-1),1,1001 );

            UIMapManager.Instance.MonsterManager.CreateMonster(new Vector3(0, 0, 0), 1, 1002);
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);

            if (m_ArrowPlayer != null && m_ArrowPlayer.IsDead)
            {
                IsGameOver = true;
                return;
            }
        }

        public override void OnLeave()
        {
            base.OnLeave();

        }
    }
}
