using System;
using UnityEngine;
using System.Collections.Generic;

namespace ArrowPlay
{
    /// <summary>
    /// 怪物类
    /// </summary>
    [Serializable]
    public class MonsterData : TargetableObjectData
    {
        [SerializeField] private string m_AttackAction="";

        [SerializeField] private string m_MoveAction="";

        [SerializeField] private string m_IdleAction="";

        [SerializeField] private int m_BaseAttack = 0;

        [SerializeField] private int m_MaxHP = 0;

        [SerializeField] private float m_Scale = 1;

        [SerializeField] private float m_Speed = 2f;

        [SerializeField] private int damageReduction;

        public MonsterData(int entityId, int typeId)
            : base(entityId, typeId, CampType.Enemy)
        {
            //表格中读取怪物信息数据  暂且所有的怪物属于敌方阵营
            DRMonster drMonsters = typeId.GetTableData<DRMonster>();
            if (drMonsters == null)
            {
                return;
            }

            m_AttackAction = drMonsters.AttackAction;
            m_MoveAction = drMonsters.MoveAction;
            m_IdleAction = drMonsters.IdleAction;
            m_BaseAttack = drMonsters.BaseAttack;
            m_MaxHP = HP = drMonsters.BaseHP;
            m_Scale = drMonsters.Scale;
            damageReduction = drMonsters.DamageReduction;
        }

        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        // PS：发射子弹情况 以及伤害计算 需要根据武器和技能决定

        /// <summary>
        /// 输出伤害
        /// </summary>
        public int Attack
        {
            get
            {
                return m_BaseAttack+0; 
            }
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

        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        public float Scale
        {
            get
            {
                return m_Scale; 
            }
        }

        public string AttackAction
        {
            get
            {
                return m_AttackAction;
            }
        }

        public string MoveAction
        {
            get
            {
                return m_MoveAction;
            }
        }

        public string IdleAction
        {
            get
            {
                return m_IdleAction;
            }
        }

        public float DamageReduction
        {
            get
            {
                return ((float)damageReduction) / 100f;
            }
        }
    }
}