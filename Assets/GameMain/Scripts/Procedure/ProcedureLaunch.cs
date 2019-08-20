using System.Diagnostics;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ArrowPlay
{
    /// <summary>
    /// 流程
    /// </summary>
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner,elapseSeconds ,realElapseSeconds);

            //设置切换场景
            procedureOwner.SetData<VarString>(Constant.ProcedureData.NextSceneId, "Main");
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }

    }
}


