using Dxx.Util;
using UnityEngine;

namespace ArrowPlay
{
    public class CameraFollowCtrl : MonoBehaviour
    {
        //public static CameraFollowCtrl Instance;

        public static bool IsCameraFollow = true;

        public bool IsRunning
        {
            get { return true; }
        }

        [SerializeField]
        private Camera m_MainCamera;

        [SerializeField]
        private Transform m_Player;

        public Transform Self
        {
            set
            {
                m_Player = value;
            }
        }

        private void Start()
        {
            //var designWidth = 640;
            //var designHeight = 1136;
            //Instance = this;
            //m_MainCamera.orthographicSize = m_MainCamera.orthographicSize * ((float)designWidth / (float)designHeight) / ((float)Screen.width / (float)Screen.height);
            //float x = Screen.width;
            //float y = Screen.height;
        }

        private void LateUpdate()
        {
            if (true)
            {
                if (IsRunning)
                {
                    Update_Running();
                }
            }
        }

        private void Update_Running()
        {
            if (true)
            {
                Update_Runnings();
            }
        }

        private void Update_Runnings()
        {
            if (IsCameraFollow && m_Player!=null)
            {
                m_MainCamera.transform.position = new Vector3(m_MainCamera.transform.position.x, m_MainCamera.transform.position.y, m_Player.position.z);
                return;
            }
        }

    }
}


