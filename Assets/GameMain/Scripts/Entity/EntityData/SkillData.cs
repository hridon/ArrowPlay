using GameFramework.DataTable;
using System;
using GameFramework;
using UnityEngine;

namespace ArrowPlay
{
    [Serializable]
    public class SkillData
    {
        [SerializeField] private string m_SkillName;

        [SerializeField] private SkillType m_SkillType = SkillType.Unknown;

        [SerializeField] private SkillStackType m_SkillStackType = SkillStackType.Unknown;

        [SerializeField] private float m_SkillNum1 = 0;

        [SerializeField] private float m_SkillNum2 = 0;

        public SkillData(int typeId)
        {
            DRSkill drSkill = typeId.GetTableData<DRSkill>();

            if (drSkill == null)
            {
                return;
            }

            m_SkillName = drSkill.Name;
            m_SkillType = (SkillType)drSkill.SkillType;
            m_SkillStackType = (SkillStackType) drSkill.SkillStackType;
            m_SkillNum1 = drSkill.Num1;
            m_SkillNum2 = drSkill.Num2;
        }

        /// <summary>
        /// 装备名称
        /// </summary>
        public string SkillName
        {
            get
            {
                return m_SkillName;
            }
        }

        /// <summary>
        /// 技能类型
        /// </summary>
        public SkillType SkillType
        {
            get
            {
                return m_SkillType;
            }
        }

        /// <summary>
        /// 技能叠加类型
        /// </summary>
        public SkillStackType SkillStackType
        {
            get
            {
                return m_SkillStackType;
            }
        }

        /// <summary>
        /// 技能参数1
        /// </summary>
        public float SkillNum1
        {
            get
            {
                return m_SkillNum1;
            }
        }

        /// <summary>
        /// 技能参数2
        /// </summary>
        public float SkillNum2
        {
            get
            {
                return m_SkillNum2;
            }
        }
    }
}
