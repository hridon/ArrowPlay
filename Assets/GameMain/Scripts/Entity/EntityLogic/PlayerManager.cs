using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowPlay
{
    public class PlayerManager : MonoBehaviour
    {
        private ArrowPlayer arrowPlayer=null;

        public ArrowPlayer CreatePlayer(Vector3 vector3, int entityId, int typeId)
        {
            if (arrowPlayer == null)
            {
                var obj = (Resources.Load<GameObject>("Entities/ArrowPlayer"));
                var gameObject = Instantiate(obj);
                arrowPlayer=gameObject.gameObject.AddComponent<ArrowPlayer>();

                arrowPlayer.transform.parent = this.transform;
                arrowPlayer.gameObject.layer = this.gameObject.layer;
                arrowPlayer.SetData(new ArrowPlayerData(1, typeId, 10000, 1, 160, 1));
                arrowPlayer.SetWeapon(new WeaponData(2001),new SkillData(1));
            }
            arrowPlayer.transform.localPosition = vector3;
            UIMapManager.Instance.CameraFollowCtrl.Self =arrowPlayer.transform;
            return arrowPlayer;
        }

        public void SetPlayerActive(bool state)
        {
            if (arrowPlayer != null)
            {
                arrowPlayer.gameObject.SetActive(state);
            }
        }
    }

}

