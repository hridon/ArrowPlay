//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-10 03:47:36.398
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
    /// AI配置表。
    /// </summary>
    public class DRAI : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取AI编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取步骤编号。
        /// </summary>
        public int OrderID
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
        /// 获取持续时间。
        /// </summary>
        public float LastTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取触发条件。
        /// </summary>
        public int Trriger
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取移动速度。
        /// </summary>
        public float MoveSpeed
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取移动方式。
        /// </summary>
        public int MoveType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取子弹ID。
        /// </summary>
        public int BulletID
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取发射类型。
        /// </summary>
        public int ShootType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取子弹数量。
        /// </summary>
        public int BulletNum
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
            OrderID = int.Parse(columnTexts[index++]);
            Type = int.Parse(columnTexts[index++]);
            LastTime = float.Parse(columnTexts[index++]);
            Trriger = int.Parse(columnTexts[index++]);
            MoveSpeed = float.Parse(columnTexts[index++]);
            MoveType = int.Parse(columnTexts[index++]);
            BulletID = int.Parse(columnTexts[index++]);
            ShootType = int.Parse(columnTexts[index++]);
            BulletNum = int.Parse(columnTexts[index++]);

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
                    OrderID = binaryReader.ReadInt32();
                    Type = binaryReader.ReadInt32();
                    LastTime = binaryReader.ReadSingle();
                    Trriger = binaryReader.ReadInt32();
                    MoveSpeed = binaryReader.ReadSingle();
                    MoveType = binaryReader.ReadInt32();
                    BulletID = binaryReader.ReadInt32();
                    ShootType = binaryReader.ReadInt32();
                    BulletNum = binaryReader.ReadInt32();
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
