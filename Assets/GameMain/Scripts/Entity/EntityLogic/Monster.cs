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
            UIHpBarManager.m_UIHpBarManager.ShowHPBar(this, m_MonsterData.MaxHP, m_MonsterData.MaxHP);
            //
            m_Weapon = gameObject.AddComponent<Weapon>();
        }

        public override ImpactData GetImpactData()
        {
            return new ImpactData(m_MonsterData.Camp, m_MonsterData.HP, 50, m_MonsterData.DamageReduction);
        }

        private ArrowPlayer m_ArrowPlayer;

    }
}
