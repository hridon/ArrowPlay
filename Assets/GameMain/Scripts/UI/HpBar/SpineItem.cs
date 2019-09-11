using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation;
using UnityEngine;
using Spine.Unity;


namespace ArrowPlay
{
    public enum SpineAnimType
    {
        //进攻
        back_attack,
        front_attack,
        side_attack,
        left_attack,

        //待机
        back_idle,
        front_idle,
        side_idle,
        left_idle,

        //移动
        back_move,
        front_move,
        side_move,
        left_move,

    }
    public class SpineItem : MonoBehaviour
    {
        public SkeletonAnimation m_SkeletonAnimation;

        private bool m_IsRotation = false;

        void Start()
        {
            //m_SkeletonAnimation.AnimationName = SpineAnimType.back_move.ToString();
            //m_SkeletonAnimation.loop = true;
        }

        void LateUpdate()
        {
            transform.localEulerAngles = -transform.parent.localEulerAngles;
        }


        /// <summary>
        /// 玩家
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="angular"></param>
        public void SetSpinePlayAnim(JoyNameType joyType, float angular,float speed=1f)
        {
            m_IsRotation = false;
            if (angular > -45f && angular <= 45f)
            {
                SetSpinePlayAnim(joyType == JoyNameType.IdleJoy ? SpineAnimType.back_idle : (joyType == JoyNameType.AttackJoy ? SpineAnimType.back_attack : SpineAnimType.back_move));
            }
            else if (angular>45f&&angular<=135f)
            {
                SetSpinePlayAnim(joyType == JoyNameType.IdleJoy ? SpineAnimType.side_idle : (joyType == JoyNameType.AttackJoy ? SpineAnimType.side_attack : SpineAnimType.side_move));
            }
            else if (angular>135f&&angular<=225f)
            {
                SetSpinePlayAnim(joyType == JoyNameType.IdleJoy ? SpineAnimType.front_idle : (joyType == JoyNameType.AttackJoy ? SpineAnimType.front_attack : SpineAnimType.front_move));
            }
            else if (angular>225f&&angular<=315f)
            {
                m_IsRotation = true;
                SetSpinePlayAnim(joyType == JoyNameType.IdleJoy ? SpineAnimType.side_idle : (joyType == JoyNameType.AttackJoy ? SpineAnimType.side_attack : SpineAnimType.side_move));
            }
            m_SkeletonAnimation.transform.localEulerAngles=m_IsRotation?new Vector3(-50,180,0): new Vector3(50,0,0);

            m_SkeletonAnimation.timeScale = speed;
        }

        public void SetMonsterAnim(string animName,float angular,bool isLoop=false,float speed=1f)
        {
            m_IsRotation = false;
            if (angular > 180f && angular <=360f)
            {
                m_IsRotation = true;
            }
            m_SkeletonAnimation.timeScale = speed;
            SetSpinePlayAnim(animName, isLoop,speed);
            m_SkeletonAnimation.transform.localEulerAngles = m_IsRotation ? new Vector3(-50, 180, 0) : new Vector3(50, 0, 0);
        }

        public void SetSpinePlayAnim(string animName, bool isLoop = true, float speed = 1f)
        {
            Spine.Animation animationToUse = m_SkeletonAnimation.skeleton.Data.FindAnimation(animName);
            if (animationToUse != null)
                m_SkeletonAnimation.state.SetAnimation(0, animationToUse, isLoop);
            else
                m_SkeletonAnimation.state.ClearTrack(0);

            m_SkeletonAnimation.timeScale = speed;
        }


        public void SetSpinePlayAnim(SpineAnimType animType, bool isLoop = true, float speed = 1f)
        {
            m_SkeletonAnimation.AnimationName = animType.ToString();
        }

        public float GetAnimTime(string animName,float speed)
        {
            Spine.Animation animationToUse = m_SkeletonAnimation.skeleton.Data.FindAnimation(animName);

            if (animationToUse != null)
            {
                return animationToUse.duration/speed;
            }

            return 0f;
        }

    }
}

