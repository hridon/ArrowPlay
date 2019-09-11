//------------------------------------------------------------
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 实体类
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        private EntityData m_EntityData = null;

        /// <summary>
        /// 获取实体。
        /// </summary>
        public Entity CurEntity
        {
            get
            {
                return GetComponent<Entity>();
            }
        }

        public int Id
        {
            get
            {
                return CurEntity.Id;
            }
        }

        void Update()
        {
            OnUpdate(Time.deltaTime,Time.realtimeSinceStartup);
        }

        void LateUpdate()
        {
            OnLateUpdate(Time.deltaTime, Time.realtimeSinceStartup);
        }

        void OnDisabled()
        {
            OnHide(m_EntityData);
        }

        protected virtual void OnHide(object userData)
        {

        }

        protected virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {

        }

        protected virtual void OnLateUpdate(float elapseSeconds, float realElapseSeconds)
        {

        }
    }
}
