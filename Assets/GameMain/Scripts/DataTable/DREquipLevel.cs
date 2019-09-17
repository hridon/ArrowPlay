//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-17 15:26:53.809
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
    /// 装备等级表。
    /// </summary>
    public class DREquipLevel : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取装备ID。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取主属性。
        /// </summary>
        public int MainPropertyType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取主属性数值。
        /// </summary>
        public int MainPropertyNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取副属性。
        /// </summary>
        public int SubPropertyType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取副属性数值。
        /// </summary>
        public int SubPropertyNum
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
            MainPropertyType = int.Parse(columnTexts[index++]);
            MainPropertyNum = int.Parse(columnTexts[index++]);
            SubPropertyType = int.Parse(columnTexts[index++]);
            SubPropertyNum = int.Parse(columnTexts[index++]);

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
                    MainPropertyType = binaryReader.ReadInt32();
                    MainPropertyNum = binaryReader.ReadInt32();
                    SubPropertyType = binaryReader.ReadInt32();
                    SubPropertyNum = binaryReader.ReadInt32();
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
