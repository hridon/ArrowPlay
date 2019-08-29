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

            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);

            //加载玩家
            GameEntry.Entity.ShowArrowPlay(new ArrowPlayerData(GameEntry.Entity.GenerateSerialId(),1,10000,1f,1f,1f,2001,null));

            //加载怪物
            GameEntry.Entity.ShowMonster(new MonsterData(GameEntry.Entity.GenerateSerialId(),1001,null));

            GameEntry.Entity.ShowMonster(new MonsterData(GameEntry.Entity.GenerateSerialId(), 1002, null));
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

            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
        }


        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;

            if (ne.EntityLogicType == typeof(ArrowPlayer))
            {
                m_ArrowPlayer = (ArrowPlayer)ne.Entity.Logic;
            }
        }

        protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
            Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
        }
    }
}
