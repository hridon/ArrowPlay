using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 可作为目标的实体类。
    /// </summary>
    public abstract class TargetableObject : Entity
    {
        [SerializeField]
        private TargetableObjectData m_TargetableObjectData = null;

        public bool IsDead
        {
            get
            {
                return m_TargetableObjectData.HP <= 0;
            }
        }

        public virtual void SetData(object userData)
        {
            m_TargetableObjectData = userData as TargetableObjectData;
        }

        public abstract ImpactData GetImpactData();

        public void ApplyDamage(Entity attacker, float damageHP)
        {
            float fromHPRatio = m_TargetableObjectData.HPRatio;
            m_TargetableObjectData.HP -= (int)damageHP;
            float toHPRatio = m_TargetableObjectData.HPRatio;
            if (fromHPRatio > toHPRatio)
            {
                UIHpBarManager.m_UIHpBarManager.ShowHPBar(this, fromHPRatio,toHPRatio);
            }

            if (m_TargetableObjectData.HP <= 0)
            {
                OnDead(attacker);
            }
        }

        protected virtual void OnDead(Entity attacker)
        {
            this.gameObject.SetActive(false);
            UIHpBarManager.m_UIHpBarManager.OnClearnHPBar(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            Entity entity = other.gameObject.GetComponent<Entity>();
            if (entity == null)
            {
                return;
            }
            //伤害计算
            AIUtility.PerformCollision(this, entity as Bullet);
        }
    }
}
