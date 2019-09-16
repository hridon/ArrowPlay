using System;
using GameFramework.DataTable;
using UnityEngine;
//TableDataExtension.GetTableData<DRScene>( ).SceneOrder;
namespace ArrowPlay
{//脚本 已废弃
    public class SceneData : EntityData
    {
        [SerializeField]
        private int sceneOrder = 0;

        [SerializeField]
        private int chapterNum = 0;

        public SceneData(int entityId, int typeId, int sceneOrder, int chapterNum)
         : base(entityId, typeId)
        {
            IDataTable<DRScene> dtScene = GameEntry.DataTable.GetDataTable<DRScene>();
            DRScene drScene = dtScene.GetDataRow(TypeId);
            //TableDataExtension.GetTableData<DRScene>(104);
            if (drScene == null)
            {
                return;
            }

            sceneOrder = drScene.SceneOrder;
            chapterNum = drScene.ChapterNum;

        }
        /// <summary>
        /// 场景顺序
        /// </summary>
        public int SceneOrder
        {
            get
            {
                return sceneOrder;
            }
        }

        /// <summary>
        /// 章节数量
        /// </summary>
        public int ChapterNum
        {
            get
            {
                return chapterNum;
            }
        }
    }

    public static class ScenesData
    {
        public static void getSceneDataInfo()
        {

        }
    }
}
