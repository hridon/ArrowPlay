using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    public class HPBarItem : MonoBehaviour
    {
        [SerializeField]
        private Slider m_HPBar = null;

        [SerializeField]
        private Entity m_Owner = null;

        private Camera m_Camera;

        public Entity Owner
        {
            get
            {
                return m_Owner;
            }
        }

        void Start()
        {
            m_HPBar.value = 1f;
            m_Camera = UIHpBarManager.m_UIHpBarManager.Camera;
        }

        public void Init(Entity entity,float maxHp, float curHp)
        {
            m_Owner = entity;
            m_HPBar.value = curHp / maxHp;
            if (curHp <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        void LateUpdate()
        {
            if (m_Owner != null && m_Owner.gameObject.activeInHierarchy && m_Camera)
                transform.position = m_Camera.WorldToScreenPoint(m_Owner.transform.position + new Vector3(0, 2f, 0));
        }
    }
}
