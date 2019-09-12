using GameFramework.DataTable;
using System;
using UnityEngine;

namespace ArrowPlay
{
    [Serializable]
    public class WeaponData
    {
        [SerializeField]
        private WeaponType m_WeaponType = WeaponType.Unknown;

        [SerializeField] private int m_Speed = 0;

        [SerializeField] private float m_ArriveTime = 0f;

        [SerializeField] private string m_HitEffect="";

        [SerializeField] private string m_HitSound = "";

        [SerializeField] private int m_DefaultBuff=0;

        [SerializeField] private CampType m_CampType;

        [SerializeField] private int m_BaseAttack;

        public WeaponData( int typeId,CampType campType,int baseAttack)
        {
            m_CampType = campType;
            m_BaseAttack = baseAttack;
            IDataTable<DRWeapon> dtWeapon = GameEntry.DataTable.GetDataTable<DRWeapon>();
            DRWeapon drWeapon = dtWeapon.GetDataRow(typeId);

            if (drWeapon == null)
            {
                return;
            }

            m_WeaponType = (WeaponType)drWeapon.WeaponType;
            m_Speed = drWeapon.Speed;
            m_ArriveTime = drWeapon.ArriveTime;
            m_HitEffect = drWeapon.HitEffect;
            m_HitSound = drWeapon.HitSound;
            m_DefaultBuff = drWeapon.DefaultBuff;
        }


        public CampType CampType
        {
            get { return m_CampType; }
        }

        public int BaseAttack
        {
            get { return m_BaseAttack; }
        }

        /// <summary>
        /// 武器类型
        /// </summary>
        public WeaponType WeaponType
        {
            get
            {
                return m_WeaponType;
            }
        }

        /// <summary>
        /// 攻击速度
        /// </summary>
        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        /// <summary>
        /// 子弹存活时间
        /// </summary>
        public float ArriveTime
        {
            get
            {
                return m_ArriveTime;
            }
        }

        /// <summary>
        /// 碰撞特效
        /// </summary>
        public string HitEffect
        {
            get
            {
                return m_HitEffect;
            }
        }

        /// <summary>
        /// 碰撞音效
        /// </summary>
        public string HitSound
        {
            get
            {
                return m_HitSound;
            }
        }
        
        /// <summary>
        /// 默认Buff
        /// </summary>
        public int DefaultBuff
        {
            get
            {
                return m_DefaultBuff;
            }
        }
    }
}
