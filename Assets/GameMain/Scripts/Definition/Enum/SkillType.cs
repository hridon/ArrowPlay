
namespace ArrowPlay
{
    /// <summary>
    /// 技能类型
    /// </summary>
    public enum SkillType
    {
        Unknown=0,

        /// <summary>
        /// 子弹攻击数量
        /// </summary>
        AttackBulletNum=1,

        /// <summary>
        /// 提升攻击力
        /// </summary>
        Attack=2,

        /// <summary>
        /// 增加最大生命值
        /// </summary>
        AddMaxHp=3,

        /// <summary>
        /// 增加血量
        /// </summary>
        AddHp=4,

        /// <summary>
        /// 护盾
        /// </summary>
        Shield=5,

        /// <summary>
        /// 晕眩效果
        /// </summary>
        Stun=6,

        /// <summary>
        /// 灼烧效果
        /// </summary>
        Fire=7,

        /// <summary>
        /// 冰冻效果
        /// </summary>
        Freeze=8,

        /// <summary>
        /// 击退效果
        /// </summary>
        Repel=9,

        /// <summary>
        /// 子弹反弹效果
        /// </summary>
        Bounce=10,
    }

    /// <summary>
    /// 技能
    /// </summary>
    public enum SkillStackType
    {
        Unknown = 0,

        /// <summary>
        /// 替换类型 直接替换相同种类的
        /// </summary>
        Replace=1,

        /// <summary>
        /// 可叠加类型
        /// </summary>
        Stack=2,

        /// <summary>
        /// 有上限可叠加类型
        /// </summary>
        UpLimitStack=3,
    }
}
