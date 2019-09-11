using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ArrowPlay
{
    
    public class BulletManager : MonoBehaviour 
    {
        List<Bullet> list1=new List<Bullet>();
        List<Bullet> list2 = new List<Bullet>();

        public Bullet CreateBullet(Entity entity,Vector3 originalVector3, Vector3 targetVector3, float height, CampType campType)
        {
            if (list2 == null || list2.Count <= 0)
            {
                var obj = (Resources.Load<GameObject>("Entities/Bullet_1001"));
                var gameObject = Instantiate(obj);
                var bullet = gameObject.AddComponent<Bullet>();
                bullet.SetBulletData(new BulletData(1, 2001, entity, campType, 1));
                bullet.transform.parent = this.transform;
                bullet.transform.position = originalVector3;
                bullet.transform.LookAt(targetVector3);
                bullet.transform.position += new Vector3(0, height, 0);

                list1.Add(bullet);
                bullet.gameObject.SetActive(true);
                bullet.IsCanTrigger = true;
                return bullet;
            }
            else
            {
                list2[0].SetBulletData(new BulletData(1, 2001, entity, campType, 1));
                list2[0].transform.position = originalVector3;
                list2[0].transform.LookAt(targetVector3);
                list2[0].transform.position += new Vector3(0, height, 0);
                list2[0].gameObject.SetActive(true);
                list2[0].IsCanTrigger = true;
                var obj = list2[0];
                list1.Add(obj);
                list2.Remove(obj);
                return obj;
            }
        }

        public void RecycleBullet(Bullet obj)
        {
            if (obj)
            {
                if (list1.Contains(obj))
                    list1.Remove(obj);
                if (!list2.Contains(obj))
                    list2.Add(obj);
                obj.IsCanTrigger = false;
                obj.gameObject.SetActive(false);
            }
        }

    }
}

