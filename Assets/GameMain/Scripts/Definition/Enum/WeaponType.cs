
namespace ArrowPlay
{
    /// <summary>
    /// 武器类型
    /// </summary>
    public enum WeaponType
    {
        Unknown = 0,

        /// <summary>
        /// 近战类型
        /// </summary>
        Infighting=1,

        /// <summary>
        /// 发射直线子弹类型
        /// </summary>
        Line=2,

        /// <summary>
        /// 发射射线类型
        /// </summary>
        RayLine,

        /// <summary>
        /// 发射抛物线子弹类型
        /// </summary>
        Parabola=3,

        /// <summary>
        /// S型子弹类型
        /// </summary>
        SLine
    }
}
