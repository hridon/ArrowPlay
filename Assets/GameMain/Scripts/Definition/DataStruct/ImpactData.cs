namespace ArrowPlay
{
    public struct ImpactData
    {
        private readonly CampType m_Camp;
        private readonly int m_HP;
        private readonly int m_Attack;
        private readonly float m_DamageReduction;

        public ImpactData(CampType camp, int hp, int attack, float damageReduction)
        {
            m_Camp = camp;
            m_HP = hp;
            m_Attack = attack;
            m_DamageReduction = damageReduction;
        }

        public CampType Camp
        {
            get
            {
                return m_Camp;
            }
        }

        public int HP
        {
            get
            {
                return m_HP;
            }
        }

        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }

        public float DamageReduction
        {
            get
            {
                return m_DamageReduction;
            }
        }
    }
}
