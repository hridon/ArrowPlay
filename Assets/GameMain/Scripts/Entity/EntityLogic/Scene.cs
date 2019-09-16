using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 场景类
    /// </summary>
    public class Scene : Entity
    {

        [SerializeField]
        private SceneData _SceneData = null;
        public SceneData SceneData
        {
            get { return _SceneData; }
        }
        public void SetBulletData(SceneData sceneData)
        {
            _SceneData = sceneData;
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnShow(object userData)
#else
        protected internal override void OnShow(object userData)
#endif
        {
            base.OnShow(userData);

            _SceneData = userData as SceneData;
            if (_SceneData == null)
            {
                Log.Error("Bullet data is invalid.");
                return;
            }
        }




    }
}
