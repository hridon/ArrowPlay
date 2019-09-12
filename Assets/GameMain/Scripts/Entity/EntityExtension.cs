using GameFramework.DataTable;
using System;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    public static class TableDataExtension
    {
        public static T GetTableData<T>(this int typeId) where T : IDataRow
        {
            IDataTable<T> dtData = GameEntry.DataTable.GetDataTable<T>();
            return dtData.GetDataRow(typeId);
        }
    }

    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

        //public static CurEntity GetGameEntity(this EntityComponent entityComponent, int entityId)
        //{
        //    UnityGameFramework.Runtime.CurEntity entity = entityComponent.GetEntity(entityId);
        //    if (entity == null)
        //    {
        //        return null;
        //    }

        //    return (CurEntity)entity.Logic;
        //}

        //public static void HideEntity(this EntityComponent entityComponent, CurEntity entity)
        //{
        //    entityComponent.HideEntity(entity.CurEntity);
        //}

        //public static void AttachEntity(this EntityComponent entityComponent, CurEntity entity, int ownerId, string parentTransformPath = null, object userData = null)
        //{
        //    entityComponent.AttachEntity(entity.CurEntity, ownerId, parentTransformPath, userData);
        //}

        //public static void ShowArrowPlay(this EntityComponent entityComponent, ArrowPlayerData data)
        //{
        //    entityComponent.ShowEntity(data.Id, typeof(ArrowPlayer), AssetUtility.GetEntityAsst("ArrowPlayer"), "ArrowPlayer", 
        //         Constant.AssetPriority.ArrowPlayerAsset, data);
        //}

        //public static void ShowMonster(this EntityComponent entityComponent, MonsterData data)
        //{
        //    entityComponent.ShowEntity(data.Id, typeof(Monster), AssetUtility.GetEntityAsst("Monster1"),"Monster"
        //        , Constant.AssetPriority.MonsterAsset, data);
        //}

        //public static void ShowBullet(this EntityComponent entityComponent, BulletData data)
        //{
        //    entityComponent.ShowEntity(data.Id, typeof(Bullet), AssetUtility.GetEntityAsst("Bullet"), "Bullet"
        //        , Constant.AssetPriority.BulletAsset, data);
        //}
    }
}
