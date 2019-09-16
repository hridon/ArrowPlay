using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    public class ChoieceMenu : UGuiForm
    {

        [SerializeField]
        private GameObject m_StartGameButton;

        //private ProcedureMenu m_ProcedureMenu = null;
#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);

            //m_ProcedureMenu = (ProcedureMenu)userData;
            //if (m_ProcedureMenu == null)
            //{
            //    Log.Warning("ProcedureMenu is invalid when open MenuForm.");
            //    return;
            //}

            if (m_StartGameButton)
            {
                var unityEvent = new UnityEvent();
                unityEvent.AddListener(StartGameEvent);
                CommonButton.Get(m_StartGameButton).m_OnClick = unityEvent;
            }
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#else
        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
        




#if UNITY_2017_3_OR_NEWER
        protected override void OnClose(object userData)
#else
        protected internal override void OnClose(object userData)
#endif
        {
            //m_ProcedureMenu = null;

            base.OnClose(userData);
        }


        void StartGameEvent()
        {
            //Close(true);
            //string[] loadedSceneAssetNames = GameEntry.Scene.GetLoadedSceneAssetNames();
            //for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            //{
            //    GameEntry.Scene.UnloadScene(loadedSceneAssetNames[i]);
            //}
            //GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset("Map"));

            Debug.Log("当前关卡" + Data.GetInstance().getcurrentLevelID());
            GameData.Instance().SetMapLevel(Data.GetInstance().getcurrentLevelID());
            GameData.Instance().GameState = true;
        }
    }
}
