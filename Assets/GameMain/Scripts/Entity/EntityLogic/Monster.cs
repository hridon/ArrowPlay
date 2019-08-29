using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 怪物类
    /// </summary>
    public class Monster : Entity
    {
        [SerializeField]
        private MonsterData m_BulletData = null;

        [SerializeField] private HPBarItem m_HpBarItem;

        public float MaxHp = 1000;

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

            m_BulletData = userData as MonsterData;
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

        private ArrowPlayer m_ArrowPlayer;

        ArrowPlayer ArrowPlayer
        {
            get
            {
                if (m_ArrowPlayer == null)
                    m_ArrowPlayer = FindObjectOfType<ArrowPlayer>();
                return m_ArrowPlayer;
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

        public bool isCanCreateBullet = false;
        private float waitTime = 1.5f;

        private float bulletWaitTime = 0.8f;

        void Update()
        {
            if (!isCanCreateBullet)return;
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                transform.LookAt(ArrowPlayer.transform);

                if (bulletWaitTime > 0)
                {
                    bulletWaitTime -= Time.deltaTime;
                }
                else
                {
                    waitTime = 1.5f;
                    bulletWaitTime = 0.8f;
                    //发射弓箭
                    //BulletManager.CreateBullet(this.transform.position, ArrowPlayerAsset.transform.position, 0, CampType.Enemy);
                }
            }
        }

        //子弹碰撞到碰撞体消失
        private void OnTriggerEnter(Collider other)
        {
            if (other)
                Debug.Log(other.name + other.gameObject.layer);

            var bullet = other.GetComponent<Bullet>();
            if (bullet && bullet.BulletData.CameType != CampType.Enemy)
            {
                BulletManager.RecycleBullet(bullet);
                //扣血
                m_HpBarItem.Init(this,1000f,(MaxHp-20));
                MaxHp -= 20;
                if (MaxHp <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }

    }
}
