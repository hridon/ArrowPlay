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
            OnInit(bulletData);
        }

        protected void OnInit(object userData)
        {
            m_BulletData = userData as BulletData;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (!IsCanTrigger) return;
            if (m_BulletData == null) return;

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

        public float aliveTime = 10f;

        void OnEnable()
        {
            aliveTime = 10f;
        }

        public bool IsCanTrigger=false;


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

            if (LayerMask.LayerToName(other.gameObject.layer) == "Box" || LayerMask.LayerToName(other.gameObject.layer) == "NoView")
            {
                BulletManager.RecycleBullet(this);
            }
        }
    }
}
