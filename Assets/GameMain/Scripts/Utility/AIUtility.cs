using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// AI 工具类。
    /// </summary>
    public static class AIUtility
    {
        private static Dictionary<CampPair, RelationType> s_CampPairToRelation = new Dictionary<CampPair, RelationType>();

        static AIUtility()
        {
            s_CampPairToRelation.Add(new CampPair(CampType.Player, CampType.Player), RelationType.Friendly);
            s_CampPairToRelation.Add(new CampPair(CampType.Player, CampType.Enemy), RelationType.Hostile);
            s_CampPairToRelation.Add(new CampPair(CampType.Player, CampType.Neutral), RelationType.Neutral);

            s_CampPairToRelation.Add(new CampPair(CampType.Enemy, CampType.Enemy), RelationType.Friendly);
            s_CampPairToRelation.Add(new CampPair(CampType.Enemy, CampType.Neutral), RelationType.Neutral);

            s_CampPairToRelation.Add(new CampPair(CampType.Neutral, CampType.Neutral), RelationType.Neutral);
        }

        /// <summary>
        /// 获取两个阵营之间的关系。
        /// </summary>
        /// <param name="first">阵营一。</param>
        /// <param name="second">阵营二。</param>
        /// <returns>阵营间关系。</returns>
        public static RelationType GetRelation(CampType first, CampType second)
        {
            if (first > second)
            {
                CampType temp = first;
                first = second;
                second = temp;
            }

            RelationType relationType;
            if (s_CampPairToRelation.TryGetValue(new CampPair(first, second), out relationType))
            {
                return relationType;
            }

            Log.Warning("Unknown relation between '{0}' and '{1}'.", first.ToString(), second.ToString());
            return RelationType.Unknown;
        }

        public static void PerformCollision(TargetableObject entity, Entity other)
        {
            if (entity == null || other == null)
            {
                return;
            }

            Bullet bullet = other as Bullet;
            if (bullet != null)
            {
                ImpactData entityImpactData = entity.GetImpactData();
                ImpactData bulletImpactData = bullet.GetImpactData();
                if (GetRelation(entityImpactData.Camp, bulletImpactData.Camp) == RelationType.Friendly)
                {
                    return;
                }

                float entityDamageHP = CalcDamageHP(bulletImpactData.Attack, entityImpactData.DamageReduction);

                entity.ApplyDamage(bullet, entityDamageHP);

                UIMapManager.Instance.BulletManager.RecycleBullet(bullet);
                return;
            }
        }

        private static float CalcDamageHP(float attack, float damageReduction)
        {
            if (attack <= 0)
            {
                return 0;
            }

            if (damageReduction < 0)
            {
                damageReduction = 0;
            }

            return attack *(1f-damageReduction);
        }

        private struct CampPair
        {
            private readonly CampType m_First;
            private readonly CampType m_Second;

            public CampPair(CampType first, CampType second)
            {
                m_First = first;
                m_Second = second;
            }

            public CampType First
            {
                get
                {
                    return m_First;
                }
            }

            public CampType Second
            {
                get
                {
                    return m_Second;
                }
            }
        }
    }
}
