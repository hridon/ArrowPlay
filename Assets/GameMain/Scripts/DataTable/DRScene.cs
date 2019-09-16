//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-16 10:28:19.794
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
    public class DRScene : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取场景ID。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取场景顺序。
        /// </summary>
        public int SceneOrder
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取章节数量。
        /// </summary>
        public int ChapterNum
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取名字图片。
        /// </summary>
        public string NameAsset
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取缩略图片。
        /// </summary>
        public string IconAsset
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
            SceneOrder = int.Parse(columnTexts[index++]);
            ChapterNum = int.Parse(columnTexts[index++]);
            NameAsset = columnTexts[index++];
            IconAsset = columnTexts[index++];

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
                    SceneOrder = binaryReader.ReadInt32();
                    ChapterNum = binaryReader.ReadInt32();
                    NameAsset = binaryReader.ReadString();
                    IconAsset = binaryReader.ReadString();
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
