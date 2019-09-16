using ArrowPlay;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Self/BHTree")]
    [TaskDescription("Plays animation without any blending. Returns Success.")]
    public class BHPlayAttack : Action
    {
        private Weapon weapon;

        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;

        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject ownerGameObject;

        private Entity ownerEntity;
        private Entity targetEntity;

        public override void OnStart()
        {
            if (weapon == null)
            {
                weapon = GetComponent<Weapon>();
            }

            if (ownerGameObject.Value == null)
            {
                ownerGameObject.Value = this.gameObject;
            }

            if (targetGameObject.Value == null)
            {
                targetGameObject.Value =GlobalVariables.Instance.GetVariable("Player").GetValue()as GameObject;
            }

            if (ownerEntity == null)
            {
                ownerEntity = ownerGameObject.Value.GetComponent<Entity>();
            }

            if (targetEntity == null)
            {
                targetEntity = targetGameObject.Value.GetComponent<Entity>();
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (weapon == null)
            {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            if (ownerEntity == null)
            {
                Debug.LogWarning("ownerEntity is null");
                return TaskStatus.Failure;
            }

            if (targetEntity == null)
            {
                Debug.LogWarning("targetEntity is null");
                return TaskStatus.Failure;
            }

            weapon.Attack(targetEntity, ownerEntity);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            ownerGameObject = null;
            weapon = null;
            targetEntity = null;
        }
    }
}