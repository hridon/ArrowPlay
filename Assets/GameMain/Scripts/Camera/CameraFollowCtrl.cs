using Dxx.Util;
using UnityEngine;

namespace ArrowPlay
{
    public class CameraFollowCtrl : PauseObject
    {
        public static CameraFollowCtrl Instance;

        public static bool IsCameraFollow = true;

        public bool IsRunning
        {
            get { return true; }
        }

        [SerializeField]
        private Camera m_Camera;

        [SerializeField]
        private Transform self;

        private void Start()
        {
            var designWidth = 640;
            var designHeight = 1136;
            Instance = this;
            m_Camera.orthographicSize = m_Camera.orthographicSize * ((float)designWidth / (float)designHeight) / ((float)Screen.width / (float)Screen.height);
            float x = Screen.width;
            float y = Screen.height;
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
            if (IsCameraFollow)
            {
                base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, self.position.z);
                return;
            }
        }

    }
}


