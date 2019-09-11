using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 武器类。
    /// </summary>
    public class Weapon :  MonoBehaviour
    {
        [SerializeField]
        private WeaponData m_WeaponData = null;

        [SerializeField]
        private SkillData m_SkillData = null;

        public void SetData(WeaponData weaponData,SkillData skillData)
        {
            m_WeaponData = weaponData;
            m_SkillData = skillData;
        }

        /// <summary>
        /// 攻击
        /// </summary>
        public void Attack(Entity targetEntity,Entity ownerEntity)
        {
            //根据当前武器类型获取攻击方式
            if (m_WeaponData.WeaponType == WeaponType.Infighting)
            {

            }
            else
            {
                UIMapManager.Instance.BulletManager.CreateBullet(ownerEntity, ownerEntity.transform.localPosition,
                    targetEntity.transform.localPosition, 0.5f, CampType.Enemy);
            }
        }
    }
}
