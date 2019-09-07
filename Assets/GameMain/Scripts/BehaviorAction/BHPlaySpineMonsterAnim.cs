using ArrowPlay;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Self/BHPlaySpineMonsterAnim")]
    [TaskDescription("Plays animation without any blending. Returns Success.")]
    public class BHPlaySpineMonsterAnim : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The name of the animation")]
        public SharedString animationName;
        [Tooltip("The animation is or not Loop")]
        public SharedBool animationLoop;
        [Tooltip("The animation Speed")]
        public SharedFloat animationSpeed;

        // cache the animation component
        private SpineItem animation;
        private GameObject prevGameObject;

        public override void OnStart()
        {
            if (targetGameObject.Value == null)
            {
                targetGameObject.Value = this.gameObject;
            }

            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject)
            {
                animation = currentGameObject.GetComponentInChildren<SpineItem>();
                prevGameObject = currentGameObject;
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (animation == null)
            {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }

            if (string.IsNullOrEmpty(animationName.Value))
            {
                animation.SetMonsterAnim(animationName.Value, prevGameObject.transform.localEulerAngles.y, animationLoop.Value, animationSpeed.Value);
            }
            else
            {
                animation.SetMonsterAnim(animationName.Value, prevGameObject.transform.localEulerAngles.y, animationLoop.Value, animationSpeed.Value);
            }

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            animationName.Value = "";
            animationSpeed = 1f;
        }
    }
}