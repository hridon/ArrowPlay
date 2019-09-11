using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowPlay
{
    public class MonsterManager : MonoBehaviour
    {
        public Monster CreateMonster(Vector3 vector3, int entityId,int typeId)
        {
            Monster monster = null;
            var obj = (Resources.Load<GameObject>("Entities/Monster_"+typeId));
            var gameObject = Instantiate(obj);
            monster = gameObject.gameObject.AddComponent<Monster>();
            monster.transform.parent = this.transform;
            monster.gameObject.layer = this.gameObject.layer;
            monster.transform.localPosition = vector3;

            monster.SetData(new MonsterData(entityId, typeId));

            monster.SetWeapon(new WeaponData(2003),new SkillData(1) );

            return monster;
        }
    }
}

