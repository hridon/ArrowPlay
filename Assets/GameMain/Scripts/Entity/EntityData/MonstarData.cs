//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using UnityEngine;

namespace ArrowPlay
{
    /// <summary>
    /// 怪物类
    /// </summary>
    [Serializable]
    public class MonstarData : TargetableObjectData
    {
        [SerializeField] private int m_MaxHP = 0;

        [SerializeField] private int m_Attack = 0;

        [SerializeField] private float m_Speed = 0f;

        [SerializeField] private float m_AngularSpeed = 0f;

        [SerializeField] private int m_DeadEffectId = 0;

        public MonstarData(int entityId, int typeId, int maxHp, int attack, float speed, int angularSpeed,
            int deadEffectId)
            : base(entityId, typeId, CampType.Enemy)
        {
            HP = m_MaxHP = maxHp;
            m_Attack = attack;
            m_Speed = speed;
            m_AngularSpeed = angularSpeed;
            m_DeadEffectId = deadEffectId;
        }

        public override int MaxHP
        {
            get { return m_MaxHP; }
        }

        public int Attack
        {
            get { return m_Attack; }
        }

        public float Speed
        {
            get { return m_Speed; }
        }

        public float AngularSpeed
        {
            get { return m_AngularSpeed; }
        }

        public int DeadEffectId
        {
            get { return m_DeadEffectId; }
        }

    }
}