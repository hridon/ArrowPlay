//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowPlay
{
    [Serializable]
    public class ArrowPlayerData : TargetableObjectData
    {

        [SerializeField]
        private List<WeaponData> m_WeaponDatas = new List<WeaponData>();

        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Defense = 0;

        [SerializeField] private float m_AttackSpeed;

        [SerializeField] private float m_AngularSpeed;

        [SerializeField] private float m_MoveSpeed;


        public ArrowPlayerData(int entityId, int typeId, CampType camp,int maxHp,int defense,float attackSpeed,float angularSpeed,float moveSpeed)
            : base(entityId, typeId, camp)
        {
            HP = m_MaxHP = maxHp;
            m_Defense = defense;
            m_AttackSpeed = attackSpeed;
            m_AngularSpeed = angularSpeed;
            m_MoveSpeed = moveSpeed;
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
        /// 防御。
        /// </summary>
        public int Defense
        {
            get
            {
                return m_Defense;
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
    }
}
