//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-12 12:00:27.455
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
    /// 子弹配置表。
    /// </summary>
    public class DRBullet : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取子弹ID。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取名字。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取类型。
        /// </summary>
        public int Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取飞行速度。
        /// </summary>
        public float FlySpeed
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取飞行时间。
        /// </summary>
        public float FlyTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取飞行曲线。
        /// </summary>
        public int FlyCurve
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取图片资源。
        /// </summary>
        public string PreferID
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取特效资源。
        /// </summary>
        public string Effect
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取默认buff。
        /// </summary>
        public int DefaultBuff
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取命中buff。
        /// </summary>
        public int HitBuff
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
            Name = columnTexts[index++];
            Type = int.Parse(columnTexts[index++]);
            FlySpeed = float.Parse(columnTexts[index++]);
            FlyTime = float.Parse(columnTexts[index++]);
            FlyCurve = int.Parse(columnTexts[index++]);
            PreferID = columnTexts[index++];
            Effect = columnTexts[index++];
            DefaultBuff = int.Parse(columnTexts[index++]);
            HitBuff = int.Parse(columnTexts[index++]);

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
                    Name = binaryReader.ReadString();
                    Type = binaryReader.ReadInt32();
                    FlySpeed = binaryReader.ReadSingle();
                    FlyTime = binaryReader.ReadSingle();
                    FlyCurve = binaryReader.ReadInt32();
                    PreferID = binaryReader.ReadString();
                    Effect = binaryReader.ReadString();
                    DefaultBuff = binaryReader.ReadInt32();
                    HitBuff = binaryReader.ReadInt32();
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
