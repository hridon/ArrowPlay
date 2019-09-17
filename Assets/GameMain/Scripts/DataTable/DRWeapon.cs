//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-17 15:26:53.939
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
    /// 武器配置表。
    /// </summary>
    public class DRWeapon : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取武器ID。
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
        /// 获取武器类型。
        /// </summary>
        public int WeaponType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取切片资源。
        /// </summary>
        public string BulletPrefabName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取飞行速度。
        /// </summary>
        public int Speed
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取存活时间。
        /// </summary>
        public int ArriveTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击到目标特效。
        /// </summary>
        public string HitEffect
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击音效。
        /// </summary>
        public string HitSound
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
            WeaponType = int.Parse(columnTexts[index++]);
            BulletPrefabName = columnTexts[index++];
            Speed = int.Parse(columnTexts[index++]);
            ArriveTime = int.Parse(columnTexts[index++]);
            HitEffect = columnTexts[index++];
            HitSound = columnTexts[index++];
            DefaultBuff = int.Parse(columnTexts[index++]);

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
                    WeaponType = binaryReader.ReadInt32();
                    BulletPrefabName = binaryReader.ReadString();
                    Speed = binaryReader.ReadInt32();
                    ArriveTime = binaryReader.ReadInt32();
                    HitEffect = binaryReader.ReadString();
                    HitSound = binaryReader.ReadString();
                    DefaultBuff = binaryReader.ReadInt32();
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
