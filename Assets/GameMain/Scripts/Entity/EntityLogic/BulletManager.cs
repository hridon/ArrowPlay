using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ArrowPlay
{
    
    public class BulletManager : MonoBehaviour 
    {
        List<Bullet> list1=new List<Bullet>();
        List<Bullet> list2 = new List<Bullet>();

        //public Bullet CreateBullet(Vector3 originalVector3,Vector3 targetVector3,float height,CampType campType)
        //{
        //    if (list2 == null || list2.Count <= 0)
        //    {
        //        var obj = (Resources.Load<Bullet>("Entities/Bullet"));
        //        var gameObject = Instantiate(obj);
        //        gameObject.SetBulletData(new BulletData(1, 1, 1, campType, 1, 10));
        //        gameObject.transform.parent = this.transform;
        //        gameObject.transform.position = originalVector3;
        //        gameObject.transform.LookAt(targetVector3);
        //        gameObject.transform.position += new Vector3(0, height, 0);

        //        list1.Add(gameObject);
        //        gameObject.gameObject.SetActive(true);
        //        gameObject.IsCanTrigger = true;
        //        return gameObject;
        //    }
        //    else
        //    {
        //        list2[0].SetBulletData(new BulletData(1, 1, 1, campType, 1, 10));
        //        list2[0].transform.position = originalVector3;
        //        list2[0].transform.LookAt(targetVector3);
        //        list2[0].transform.position += new Vector3(0, height, 0);
        //        list2[0].gameObject.SetActive(true);
        //        list2[0].IsCanTrigger = true;
        //        var obj = list2[0];
        //        list1.Add(obj);
        //        list2.Remove(obj);
        //        return obj;
        //    }
        //}

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

