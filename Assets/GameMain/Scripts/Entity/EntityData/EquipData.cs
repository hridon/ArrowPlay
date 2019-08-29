using GameFramework.DataTable;
using System;
using UnityEngine;

namespace ArrowPlay
{
    [Serializable]
    public class EquipData :EntityData
    {
        [SerializeField] 
        private int m_Class = 0;

        [SerializeField] private string m_EquipName;

        [SerializeField]
        private EquipType m_EquipType = EquipType.Unknown;

        [SerializeField] private int m_WeaponId=0;

        public EquipData(int entityId, int typeId)
            :base(entityId,typeId)
        {
            IDataTable<DREquip> dtEquip = GameEntry.DataTable.GetDataTable<DREquip>();
            DREquip drEquip = dtEquip.GetDataRow(TypeId);

            if (drEquip == null)
            {
                return;
            }

            m_EquipName = drEquip.Name;
            m_Class = drEquip.Class;
            m_EquipType = (EquipType) drEquip.EquipType;
            m_WeaponId = drEquip.WeaponId;
        }

        /// <summary>
        /// 装备名称
        /// </summary>
        public string EquipName
        {
            get
            {
                return m_EquipName;
            }
        }

        /// <summary>
        /// 装备品质
        /// </summary>
        public int EquipClass
        {
            get
            {
                return m_Class;
            }
        }

        /// <summary>
        /// 装备类型
        /// </summary>
        public EquipType EquipType
        {
            get
            {
                return m_EquipType;
            }
        }

        /// <summary>
        /// 武器Id
        /// </summary>
        public int WeaponId
        {
            get
            {
                return m_WeaponId;
            }
        }
    }
}
