using System;
using UnityEngine;
using System.Collections.Generic;

namespace ArrowPlay
{
    [Serializable]
    public abstract class TargetableObjectData : EntityData
    {
        [SerializeField]
        private CampType m_Camp = CampType.Unknown;

        [SerializeField]
        private int m_HP = 0;

        [SerializeField] private WeaponData m_WeaponData;

        [SerializeField] private List<SkillData> m_SkillDatas;

        public TargetableObjectData(int entityId, int typeId, CampType camp,int weaponId=0,List<int> skillDataIds=null)
            : base(entityId, typeId)
        {
            m_Camp = camp;
            m_HP = 0;

            m_WeaponData=new WeaponData(Id,TypeId);

            if (skillDataIds == null)
            {
                m_SkillDatas = null;
                return;
            }

            m_SkillDatas=new List<SkillData>();
            foreach (var skillId in skillDataIds)
            {
                m_SkillDatas.Add(new SkillData(Id, TypeId));
            }
        }

        /// <summary>
        /// 角色阵营。
        /// </summary>
        public CampType Camp
        {
            get
            {
                return m_Camp;
            }
        }

        /// <summary>
        /// 当前生命。
        /// </summary>
        public int HP
        {
            get
            {
                return m_HP;
            }
            set
            {
                m_HP = value;
            }
        }

        /// <summary>
        /// 最大生命。
        /// </summary>
        public abstract int MaxHP
        {
            get;
        }

        /// <summary>
        /// 生命百分比。
        /// </summary>
        public float HPRatio
        {
            get
            {
                return MaxHP > 0 ? (float)HP / MaxHP : 0f;
            }
        }

        /// <summary>
        /// 武器信息
        /// </summary>
        public WeaponData WeaponData
        {
            get
            {
                return m_WeaponData;
            }
            set
            {
                m_WeaponData = value;
            }
        }

        /// <summary>
        /// 技能信息
        /// </summary>
        public List<SkillData> SkillDatas
        {
            get
            {
                return m_SkillDatas;
            } 
            set
            {
                m_SkillDatas = value;
            }
        }
    }
}
