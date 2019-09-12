using System;
using GameFramework.DataTable;
using UnityEngine;

namespace ArrowPlay
{
    [Serializable]
    public class BulletData : EntityData
    {
        [SerializeField]
        private Entity m_BulletOwner = null;

        [SerializeField]
        private CampType m_OwnerCamp = CampType.Unknown;

        [SerializeField]
        private int m_Attack = 0;

        [SerializeField]
        private string m_Name = "";

        [SerializeField]
        private int m_Type = 0;

        [SerializeField]
        private float m_Speed = 0f;

        [SerializeField]
        private float m_FlyTime = 0f;

        public BulletData(int entityId, int typeId, Entity ownerId, CampType campType, int attack)
            : base(entityId, typeId)
        {
            IDataTable<DRBullet> dtBullet = GameEntry.DataTable.GetDataTable<DRBullet>();
            DRBullet drBullet = dtBullet.GetDataRow(TypeId);

            if (drBullet == null)
            {
                return;
            }

            m_BulletOwner = ownerId;
            m_OwnerCamp = campType;
            m_Attack = attack;

            m_Name = drBullet.Name;
            m_Type = drBullet.Type;
            m_Speed = drBullet.FlySpeed;
            m_FlyTime = drBullet.FlyTime;
        }

        /// <summary>
        /// 子弹的发射实体
        /// </summary>
        public Entity OwnerId
        {
            get
            {
                return m_BulletOwner; 
            }
        }

        /// <summary>
        /// 子弹伤害
        /// </summary>
        public int Attack
        {
            get
            {
                return m_Attack; 
            }
        }

        /// <summary>
        /// 子弹飞行时间
        /// </summary>
        public float FlyTime
        {
            get
            {
                return m_FlyTime;
            }
        }

        /// <summary>
        /// 子弹飞行速度
        /// </summary>
        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        /// <summary>
        /// 子弹所属阵营
        /// </summary>
        public CampType CameType
        {
            get
            {
                return m_OwnerCamp;
            }
        }
    }
}
