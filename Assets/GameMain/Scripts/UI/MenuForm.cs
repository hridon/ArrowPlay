using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    public class MenuForm : UGuiForm
    {
        [SerializeField]
        private GameObject m_StartGameButton;

        private ProcedureMenu m_ProcedureMenu = null;

#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);

            m_ProcedureMenu = (ProcedureMenu)userData;
            if (m_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }

            if (m_StartGameButton)
            {
                var unityEvent = new UnityEvent();
                unityEvent.AddListener(StartGameEvent);
                CommonButton.Get(m_StartGameButton).m_OnClick = unityEvent;
            }
        }


#if UNITY_2017_3_OR_NEWER
        protected override void OnClose(object userData)
#else
        protected internal override void OnClose(object userData)
#endif
        {
            m_ProcedureMenu = null;

            base.OnClose(userData);
        }


        void StartGameEvent()
        {
            m_ProcedureMenu.StartGame();
        }
    }
}
