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

        private Entity m_Owner = null;
        private int m_OwnerId = 0;
        [SerializeField] private GameObject Obj;

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
            transform.position = Camera.main.WorldToScreenPoint(Obj.transform.position + new Vector3(0, 3f, 0));
        }
    }
}
