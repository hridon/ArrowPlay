using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowPlay
{
    public class UIHpBarManager : MonoBehaviour
    {
        public static UIHpBarManager m_UIHpBarManager;
        [SerializeField]
        private HPBarItem m_HPBarItemTemplate=null;

        [SerializeField] 
        private Transform m_HPBarRoot = null;

        [SerializeField] 
        private Camera m_Camera=null;

        public Camera Camera
        {
            get { return m_Camera; }
        }

        private List<HPBarItem> m_ActiveHPBarItems = null;

        void Awake()
        {
             m_UIHpBarManager = this;
        }

        void Start()
        {
            m_ActiveHPBarItems=new List<HPBarItem>();
        }

        public void ShowHPBar(Entity entity, float fromHPRatio, float toHPRatio)
        {
            HPBarItem hpBarItem = GetActiveHPBarItem(entity);
            if (hpBarItem == null)
            {
                hpBarItem = CreateHPBarItem(entity);
                m_ActiveHPBarItems.Add(hpBarItem);
            }

            hpBarItem.Init(entity, fromHPRatio, toHPRatio);
        }

        private HPBarItem GetActiveHPBarItem(Entity entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (m_ActiveHPBarItems == null)
            {
                return null;
            }

            for (int i = 0; i < m_ActiveHPBarItems.Count; i++)
            {
                if (m_ActiveHPBarItems[i].Owner == entity)
                {
                    return m_ActiveHPBarItems[i];
                }
            }

            return null;
        }

        private HPBarItem CreateHPBarItem(Entity entity)
        {
            HPBarItem hpBarItem = null;
            if (m_HPBarItemTemplate != null)
            {
                hpBarItem = Instantiate(m_HPBarItemTemplate);
                Transform transform = hpBarItem.GetComponent<Transform>();
                transform.SetParent(m_HPBarRoot);
                transform.localScale =Vector3.one;
                hpBarItem.gameObject.layer = m_HPBarRoot.gameObject.layer;
            }
            return hpBarItem;
        }

        public void OnClearnHPBar(Entity entity)
        {
            if (entity == null)
            {
                return;
            }

            if (m_ActiveHPBarItems == null)
            {
                return;
            }

            for (int i = 0; i < m_ActiveHPBarItems.Count; i++)
            {
                if (m_ActiveHPBarItems[i].Owner == entity)
                {
                    Destroy(m_ActiveHPBarItems[i]);
                }
            }
        }

        public void SetHPBarActive(Entity entity,bool isActive)
        {
            if (entity == null)
            {
                return;
            }

            if (m_ActiveHPBarItems == null)
            {
                return;
            }

            for (int i = 0; i < m_ActiveHPBarItems.Count; i++)
            {
                if (m_ActiveHPBarItems[i].Owner == entity)
                {
                    m_ActiveHPBarItems[i].gameObject.SetActive(isActive);
                }
            }
        }

        public void OnClearnAllHPBars()
        {
            if (m_ActiveHPBarItems == null)
            {
                return;
            }

            for (int i = 0; i < m_ActiveHPBarItems.Count; i++)
            {
                Destroy(m_ActiveHPBarItems[i]);
            }
        }
    }
}


