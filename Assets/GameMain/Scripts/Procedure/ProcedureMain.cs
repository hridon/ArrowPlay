using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ArrowPlay
{
    public class ProcedureMain : ProcedureBase
    {
        private GameBase m_CurrentGame=null;

        private const float GameOverDelayedSeconds = 2f;
        private float m_GotoMenuDelaySeconds = 0f;

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);

            m_CurrentGame=new OneMapGame();
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_CurrentGame.Initialize();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner,elapseSeconds ,realElapseSeconds);

            if (m_CurrentGame!=null&&!m_CurrentGame.IsGameOver)
            { 
                m_CurrentGame.Update(elapseSeconds, realElapseSeconds);
                return;
            }

            m_GotoMenuDelaySeconds += elapseSeconds;
            if (m_GotoMenuDelaySeconds >= GameOverDelayedSeconds)
            {
                procedureOwner.SetData<VarString>(Constant.ProcedureData.NextSceneId, "Menu");
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }


        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            m_GotoMenuDelaySeconds = 0f;
            if (m_CurrentGame != null)
            {
                m_CurrentGame.OnLeave();
                m_CurrentGame = null;
            }
        }
    }
}


