using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace ArrowPlay
{
    public enum SpineAnimType
    {
        //LeftAttack,
        //RightAttack,
        //BackLeftAttack,
        //BackRightAttack,
        at_left,
        at_right,
        backat_left,
        backat_right,

        move_left,
        move_right,
        back_move_left,
        back_move_right,
        //LeftMove,
        //RightMove,
        //BackLeftMove,
        //BackRightMove,

        idle_left,
        idle_rigth,
        back_left,
        back_right,
        //LeftIdle,
        //RightIdle,
        //BackLeftIdle,
        //BackRightIdle,
    }
    public class SpineItem : MonoBehaviour
    {
        public SkeletonAnimation m_SkeletonAnimation;
        public GameObject m_FollowObj;

        void Start()
        {
            m_SkeletonAnimation.AnimationName = SpineAnimType.back_right.ToString();
            m_SkeletonAnimation.loop = true;
        }

        void LateUpdate()
        {
            transform.position = m_FollowObj.transform.position;//Camera.main.WorldToScreenPoint(m_FollowObj.transform.position + new Vector3(0, 0f, 0));
        }

        public void SetSpinePlayAnim(bool attack,float angular)
        {
            if (angular >= -0f && angular <= 90f)
            {
                SetSpinePlayAnim(attack ? SpineAnimType.backat_right : SpineAnimType.back_move_right);
            }
            else if (angular>-0f+90f&&angular<90f+90f)
            {
                SetSpinePlayAnim(attack ? SpineAnimType.at_right : SpineAnimType.move_right);
            }
            else if (angular>-0f+180f&&angular<90f+180f)
            {
                SetSpinePlayAnim(attack ? SpineAnimType.at_left : SpineAnimType.move_left);
            }
            else if (angular>-0f+270f&&angular<90f+270f)
            {
                SetSpinePlayAnim(attack ? SpineAnimType.backat_left : SpineAnimType.back_move_left);
            }
        }


        public void SetSpinePlayAnim(SpineAnimType animType,bool isLoop=true)
        {
            m_SkeletonAnimation.AnimationName = animType.ToString();
            m_SkeletonAnimation.loop = isLoop;
        }
    }
}

