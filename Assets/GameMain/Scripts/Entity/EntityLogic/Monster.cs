using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 怪物类
    /// </summary>
    public class Monster : TargetableObject
    {
        [SerializeField]
        private MonsterData m_MonsterData = null;

        [SerializeField]
        private Weapon m_Weapon = null;

        public void SetData(MonsterData monsterData)
        {
            base.SetData(monsterData);
            OnInit(monsterData);
        }

        public void SetWeapon(WeaponData weaponData, SkillData skillData)
        {
            m_Weapon.SetData(weaponData, skillData);
        }

        protected void OnInit(object userData)
        {
            m_MonsterData = userData as MonsterData;
            //血量设置
            UIHpBarManager.m_UIHpBarManager.ShowHPBar(this, 1000, 1000);
            //
            m_Weapon = gameObject.AddComponent<Weapon>();
        }

        public override ImpactData GetImpactData()
        {
            return new ImpactData();
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


        //private BulletManager m_BulletManager;

        //BulletManager BulletManager
        //{
        //    get
        //    {
        //        if (m_BulletManager == null)
        //            m_BulletManager = FindObjectOfType<BulletManager>();
        //        return m_BulletManager;
        //    }
        //}

        //public bool isCanCreateBullet = false;
        //private float waitTime = 1.5f;

        //private float bulletWaitTime = 0.8f;

        //void Update()
        //{
        //    if (!isCanCreateBullet)return;
        //    if (waitTime > 0)
        //    {
        //        waitTime -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        transform.LookAt(ArrowPlayer.transform);

        //        if (bulletWaitTime > 0)
        //        {
        //            bulletWaitTime -= Time.deltaTime;
        //        }
        //        else
        //        {
        //            waitTime = 1.5f;
        //            bulletWaitTime = 0.8f;
        //            //发射弓箭
        //            //BulletManager.CreateBullet(this.transform.position, ArrowPlayerAsset.transform.position, 0, CampType.Enemy);
        //        }
        //    }
        //}

        ////子弹碰撞到碰撞体消失
        //private void OnTriggerEnter(Collider other)
        //{
        //    //if (other)
        //    //    Debug.Log(other.name + other.gameObject.layer);

        //    var bullet = other.GetComponent<Bullet>();
        //    if (bullet && bullet.BulletData.CameType != CampType.Enemy)
        //    {
        //        BulletManager.RecycleBullet(bullet);
        //        //扣血
        //        m_HpBarItem.Init(this,1000f,(MaxHp-20));
        //        MaxHp -= 20;
        //        if (MaxHp <= 0)
        //        {
        //            gameObject.SetActive(false);
        //        }
        //    }
        //}

    }
}
