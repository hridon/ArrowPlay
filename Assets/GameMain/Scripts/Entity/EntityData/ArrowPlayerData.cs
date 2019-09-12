//------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowPlay
{
    [Serializable]
    public class ArrowPlayerData : TargetableObjectData
    {
        [SerializeField] private int m_MaxHP = 0;

        [SerializeField] private float m_AttackSpeed;

        [SerializeField] private float m_AngularSpeed;

        [SerializeField] private float m_MoveSpeed;

        [SerializeField] private int m_Attack;


        public ArrowPlayerData(int entityId, int typeId, int maxHp, float attackSpeed, float angularSpeed, float moveSpeed,int attack)
            : base(entityId, typeId, CampType.Player)
        {
            HP = m_MaxHP = maxHp;
            m_AttackSpeed = attackSpeed;
            m_AngularSpeed = angularSpeed;
            m_MoveSpeed = moveSpeed;
            m_Attack = attack;
        }

        /// <summary>
        /// 最大生命。
        /// </summary>
        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        /// <summary>
        /// 攻击速度。
        /// </summary>
        public float AttackSpeed
        {
            get
            {
                return m_AttackSpeed;
            }
        }

        /// <summary>
        /// 旋转速度。
        /// </summary>
        public float mAngularSpeed
        {
            get
            {
                return m_AngularSpeed;
            }
        }

        /// <summary>
        /// 移动速度。
        /// </summary>
        public float MoveSpeed
        {
            get
            {
                return m_MoveSpeed;
            }
        }

        public int Attack
        {
            get { return m_Attack; }
        }
    }
}
