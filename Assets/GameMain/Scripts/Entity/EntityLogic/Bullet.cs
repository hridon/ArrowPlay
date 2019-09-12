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

        public bool m_IsCanRebound = false;

        public float aliveTime = 10f;


        public BulletData BulletData
        {
            get { return m_BulletData; }
        }

        public ImpactData GetImpactData()
        {
            return new ImpactData(m_BulletData.CameType, 0, m_BulletData.Attack, 0);
        }

        public void SetBulletData(BulletData bulletData)
        {
            OnInit(bulletData);
        }


        protected void OnInit(object userData)
        {
            m_BulletData = userData as BulletData;
            aliveTime = m_BulletData.FlyTime;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (m_BulletData == null) return;

            if (aliveTime > 0)
            {
                aliveTime -= Time.deltaTime;
                transform.Translate(Vector3.forward * m_BulletData.Speed * Time.deltaTime, Space.Self);
            }
            else
            {
                aliveTime = m_BulletData.FlyTime;
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

        //这里碰撞检测只判断是否撞到墙
        private void OnTriggerEnter(Collider other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Box" || LayerMask.LayerToName(other.gameObject.layer) == "NoView")
            {
                BulletManager.RecycleBullet(this);
            }
        }
    }
}
