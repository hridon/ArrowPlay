using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 玩家类
    /// </summary>
    public class ArrowPlayer : TargetableObject
    {
        [SerializeField]
        private ArrowPlayerData m_ArrowPlayerData = null;

        [SerializeField] private ETCJoystick m_EtcJoystick;

        private CharacterController m_CharacterController;

        [SerializeField] private JoyNameType m_JoyNameType;

        [SerializeField]
        private SpineItem m_SpineItem;
        [SerializeField]
        private Weapon m_Weapon = null;

        public JoyNameType JoyNameType
        {
            get { return m_JoyNameType; }
        }

        public void SetData(ArrowPlayerData arrowPlayerData)
        {
            base.SetData(arrowPlayerData);
            OnInit(arrowPlayerData);
        }

        public void SetWeapon(WeaponData weaponData,SkillData skillData)
        {
            m_Weapon.SetData(weaponData, skillData);
        }

        protected void OnInit(object userData)
        {
            isGameSuccess = false;
            m_ArrowPlayerData = userData as ArrowPlayerData;

            m_EtcJoystick = FindObjectOfType<ETCJoystick>();

            if (!m_CharacterController)
                m_CharacterController = GetComponentInChildren<CharacterController>();

            m_JoyNameType = JoyNameType.MoveJoy;

            m_EtcJoystick.onMoveStart.AddListener(MoveStartEvent);
            m_EtcJoystick.onMove.AddListener(MoveEvent);
            m_EtcJoystick.onMoveEnd.AddListener(MoveEndEvent);

            m_SpineItem=GetComponentInChildren<SpineItem>();
            m_Weapon = gameObject.AddComponent<Weapon>();
            //生成Hp
            UIHpBarManager.m_UIHpBarManager.ShowHPBar(this, m_ArrowPlayerData.HP, m_ArrowPlayerData.HPRatio);
        }

        public bool isGameSuccess=false;
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (m_JoyNameType == JoyNameType.AttackJoy||m_JoyNameType==JoyNameType.IdleJoy)
            {
                GetNerMonstar();
                if (nearMonstar == null)
                {
                    m_JoyNameType = JoyNameType.IdleJoy;
                    m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y, 0.5f);
                    isGameSuccess = true;
                    return;
                }

                //转向就近敌方单位
                m_CharacterController.transform.LookAt(nearMonstar.transform.position);

                m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y,0.5f);
                //等待一秒发射子弹
                if (waitTime > 0f)
                {
                    waitTime -= Time.deltaTime;
                }
                else
                {
                    UIMapManager.Instance.BulletManager.CreateBullet(this, m_CharacterController.transform.position,
                        nearMonstar.transform.position, 0.5f, CampType.Player, m_ArrowPlayerData.Attack);

                    waitTime = 1f;
                }
            }
            else
            {
                waitTime = 1f;
                m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y,0.5f);
            }
        }

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);

            m_EtcJoystick.onMoveStart.RemoveListener(MoveStartEvent);
            m_EtcJoystick.onMove.RemoveListener(MoveEvent);

            m_JoyNameType = JoyNameType.AttackJoy;
        }

        void MoveStartEvent()
        {
            m_JoyNameType = JoyNameType.MoveJoy;
            m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y, 0.5f);
        }

        void MoveEndEvent()
        {
            m_JoyNameType = JoyNameType.AttackJoy;
            m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y, 0.5f);
        }

        void MoveEvent(Vector2 vector2)
        {
            m_CharacterController.Move((new Vector3(vector2.x, 0, vector2.y).normalized) * m_ArrowPlayerData .MoveSpeed* Time.deltaTime * 4f);
            m_CharacterController.transform.rotation = Quaternion.LookRotation(new Vector3(vector2.x, 0, vector2.y));

            m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y, 0.5f);
        }

        private float waitTime = 0.5f;
        private GameObject nearMonstar;
        void GetNerMonstar()
        {
            float distance = 1000;//Vector3.Distance(m_Monsters[1].transform.position, this.m_CharacterController.transform.position);
            nearMonstar = null;//m_Monsters[1];
            var allMonster = FindObjectsOfType<Monster>();
            foreach (var monstar in allMonster)
            {
                float dis = Vector3.Distance(monstar.transform.position, this.m_CharacterController.transform.position);
                if (distance > dis && monstar.gameObject.activeInHierarchy && !monstar.IsDead)
                {
                    distance = dis;
                    nearMonstar = monstar.gameObject;
                }
            }
        }

        private BulletManager m_BulletManager;

        BulletManager BulletManager
        {
            get
            {
                if (m_BulletManager == null)
                    m_BulletManager = FindObjectOfType<BulletManager>();
                return m_BulletManager;
            }
        }

        public override ImpactData GetImpactData()
        {
            return new ImpactData(m_ArrowPlayerData.Camp, m_ArrowPlayerData.HP, m_ArrowPlayerData.Attack, 0);
        }
    }
}
