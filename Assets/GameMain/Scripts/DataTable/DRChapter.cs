//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-16 10:28:19.768
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    /// <summary>
    /// 场景配置表。
    /// </summary>
    public class DRChapter : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取章节ID。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取所属场景。
        /// </summary>
        public int SceneId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int ChapterOrder
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取关卡数量。
        /// </summary>
        public int BattleNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取体力奖励数量。
        /// </summary>
        public int EnegyBonusNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取金币奖励数量。
        /// </summary>
        public int CoinBonusNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取宝石奖励数量。
        /// </summary>
        public int GoldBonusNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取高级宝箱钥匙数量。
        /// </summary>
        public int SpecialKeyBonusNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取普通宝箱钥匙数量。
        /// </summary>
        public int NormalKeyBonusNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取奖励装备id。
        /// </summary>
        public int EquipBonusId
        {
            get;
            private set;
        }

        public override bool ParseDataRow(GameFrameworkSegment<string> dataRowSegment)
        {
            // Arrow Play 示例代码，正式项目使用时请调整此处的生成代码，以处理 GCAlloc 问题！
            string[] columnTexts = dataRowSegment.Source.Substring(dataRowSegment.Offset, dataRowSegment.Length).Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnTexts.Length; i++)
            {
                columnTexts[i] = columnTexts[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnTexts[index++]);
            SceneId = int.Parse(columnTexts[index++]);
            ChapterOrder = int.Parse(columnTexts[index++]);
            BattleNum = int.Parse(columnTexts[index++]);
            EnegyBonusNum = int.Parse(columnTexts[index++]);
            CoinBonusNum = int.Parse(columnTexts[index++]);
            GoldBonusNum = int.Parse(columnTexts[index++]);
            SpecialKeyBonusNum = int.Parse(columnTexts[index++]);
            NormalKeyBonusNum = int.Parse(columnTexts[index++]);
            EquipBonusId = int.Parse(columnTexts[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(GameFrameworkSegment<byte[]> dataRowSegment)
        {
            // Arrow Play 示例代码，正式项目使用时请调整此处的生成代码，以处理 GCAlloc 问题！
            using (MemoryStream memoryStream = new MemoryStream(dataRowSegment.Source, dataRowSegment.Offset, dataRowSegment.Length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.ReadInt32();
                    SceneId = binaryReader.ReadInt32();
                    ChapterOrder = binaryReader.ReadInt32();
                    BattleNum = binaryReader.ReadInt32();
                    EnegyBonusNum = binaryReader.ReadInt32();
                    CoinBonusNum = binaryReader.ReadInt32();
                    GoldBonusNum = binaryReader.ReadInt32();
                    SpecialKeyBonusNum = binaryReader.ReadInt32();
                    NormalKeyBonusNum = binaryReader.ReadInt32();
                    EquipBonusId = binaryReader.ReadInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(GameFrameworkSegment<Stream> dataRowSegment)
        {
            Log.Warning("Not implemented ParseDataRow(GameFrameworkSegment<Stream>)");
            return false;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
