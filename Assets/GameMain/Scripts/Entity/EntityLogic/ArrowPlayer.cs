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

        [SerializeField] private GameObject[] m_Monsters;

        [SerializeField]
        private SpineItem m_SpineItem;

        //public float MaxHp = 2000;

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);

            m_EtcJoystick = FindObjectOfType<ETCJoystick>();

            if (!m_CharacterController)
                m_CharacterController = GetComponentInChildren<CharacterController>();

            m_JoyNameType = JoyNameType.IdleJoy;

            m_EtcJoystick.onMoveStart.AddListener(MoveStartEvent);
            m_EtcJoystick.onMove.AddListener(MoveEvent);
            m_EtcJoystick.onMoveEnd.AddListener(MoveEndEvent);

            m_SpineItem = GetComponentInChildren<SpineItem>();
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnShow(object userData)
#else
        protected internal override void OnShow(object userData)
#endif
        {
            base.OnShow(userData);

            m_ArrowPlayerData = userData as ArrowPlayerData;
            if (m_ArrowPlayerData == null)
            {
                Log.Error("Bullet data is invalid.");
                return;
            }

            //生成Hp
           // UIHpBarManager.m_UIHpBarManager.ShowHPBar(this, m_ArrowPlayerData.HP, m_ArrowPlayerData.HPRatio);

           CameraFollowCtrl.Instance.Self = this.transform;
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#else
        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (IsDead)
            {
                GameEntry.Entity.HideEntity(this);
            }

            if (m_JoyNameType == JoyNameType.AttackJoy)
            {
                //GetNerMonstar();
                //if (nearMonstar == null || !nearMonstar.activeInHierarchy) return;
                ////转向就近敌方单位
                //m_CharacterController.transform.LookAt(nearMonstar.transform.position);

                //m_SpineItem.SetSpinePlayAnim(true, transform.eulerAngles.y);
                ////等待一秒发射子弹
                //if (waitTime > 0f)
                //{
                //    waitTime -= Time.deltaTime;
                //}
                //else
                //{
                //    //BulletManager.CreateBullet(m_CharacterController.transform.position, nearMonstar.transform.position,
                //    //    m_CharacterController.center.y,CampType.Player);
                    
                //    waitTime = 0.5f;
                //}
            }
            else
            {
                waitTime = 0.5f;
                m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y);
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
            m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y);
        }

        void MoveEndEvent()
        {
            m_JoyNameType = JoyNameType.AttackJoy;
            m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y);
        }

        void MoveEvent(Vector2 vector2)
        {
            m_CharacterController.Move((new Vector3(vector2.x, 0, vector2.y).normalized) * m_ArrowPlayerData .MoveSpeed* Time.deltaTime * 4f);
            m_CharacterController.transform.rotation = Quaternion.LookRotation(new Vector3(vector2.x, 0, vector2.y));

            m_SpineItem.SetSpinePlayAnim(m_JoyNameType, transform.eulerAngles.y);
        }

        private float waitTime = 0.5f;
        private GameObject nearMonstar;
        void GetNerMonstar()
        {
            float distance = 1000;//Vector3.Distance(m_Monsters[1].transform.position, this.m_CharacterController.transform.position);
            nearMonstar = null;//m_Monsters[1];
            foreach (var monstar in m_Monsters)
            {
                float dis = Vector3.Distance(monstar.transform.position, this.m_CharacterController.transform.position);
                if (distance > dis&&monstar.activeInHierarchy)
                {
                    distance = dis;
                    nearMonstar = monstar;
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

        //子弹碰撞到碰撞体消失
        private void OnTriggerEnter(Collider other)
        {
            //if (other)
            //    Debug.Log(other.name + other.gameObject.layer);

            var bullet = other.GetComponent<Bullet>();
            if (bullet&&bullet.BulletData.CameType!=CampType.Player)
            {
                BulletManager.RecycleBullet(bullet);

                //扣血
                UIHpBarManager.m_UIHpBarManager.ShowHPBar(this, 1000f, (m_ArrowPlayerData.HP - 20));
                m_ArrowPlayerData.HP -= 20;
                if (m_ArrowPlayerData.HP <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        public override ImpactData GetImpactData()
        {
            return new ImpactData();
        }
    }
}
