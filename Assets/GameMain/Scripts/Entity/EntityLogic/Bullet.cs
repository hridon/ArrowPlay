//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 子弹类。
    /// </summary>
    public class Bullet : Entity
    {
        [SerializeField]
        private BulletData m_BulletData = null;

        public BulletData BulletData
        {
            get { return m_BulletData; }
        }

        public void SetBulletData(BulletData bulletData)
        {
            m_BulletData = bulletData;
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

            m_BulletData = userData as BulletData;
            if (m_BulletData == null)
            {
                Log.Error("Bullet data is invalid.");
                return;
            }
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#else
        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector3.forward * m_BulletData.Speed * elapseSeconds, Space.World);
        }

        public float aliveTime = 10f;

        void OnEnable()
        {
            aliveTime = 10f;
        }

        public bool IsCanTrigger=false;
        void Update()
        {
            if (!IsCanTrigger) return;
            if (m_BulletData==null)return;

            if (aliveTime > 0)
            {
                aliveTime -= Time.deltaTime;
                transform.Translate(Vector3.forward * m_BulletData.Speed * Time.deltaTime, Space.Self);
            }
            else
            {
                aliveTime = 10f;
                BulletManager.RecycleBullet(this);
            }
        }

        private BulletManager m_BulletManager;

        BulletManager BulletManager
        {
            get
            {
                if (m_BulletManager == null)
                    m_BulletManager = FindObjectOfType<BulletManager>();
                return m_BulletManager;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsCanTrigger) return;
            if (other)
                Debug.Log(other.name + other.gameObject.layer);

            if (LayerMask.LayerToName( other.gameObject.layer)=="Box")
            {
                BulletManager.RecycleBullet(this);
            }
        }
    }
}
