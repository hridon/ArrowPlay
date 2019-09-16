//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-16 10:28:19.802
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
    /// 技能配置表。
    /// </summary>
    public class DRSkill : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取技能ID。
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
        /// 获取技能类型。
        /// </summary>
        public int SkillType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能叠加类型。
        /// </summary>
        public int SkillStackType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能相关参数。
        /// </summary>
        public float Num1
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能相关参数。
        /// </summary>
        public float Num2
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
            SkillType = int.Parse(columnTexts[index++]);
            SkillStackType = int.Parse(columnTexts[index++]);
            Num1 = float.Parse(columnTexts[index++]);
            Num2 = float.Parse(columnTexts[index++]);
            index++;

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
                    SkillType = binaryReader.ReadInt32();
                    SkillStackType = binaryReader.ReadInt32();
                    Num1 = binaryReader.ReadSingle();
                    Num2 = binaryReader.ReadSingle();
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

        private KeyValuePair<int, float>[] m_Num = null;

        public int NumCount
        {
            get
            {
                return m_Num.Length;
            }
        }

        public float GetNum(int id)
        {
            foreach (KeyValuePair<int, float> i in m_Num)
            {
                if (i.Key == id)
                {
                    return i.Value;
                }
            }

            throw new GameFrameworkException(Utility.Text.Format("GetNum with invalid id '{0}'.", id.ToString()));
        }

        public float GetNumAt(int index)
        {
            if (index < 0 || index >= m_Num.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetNumAt with invalid index '{0}'.", index.ToString()));
            }

            return m_Num[index].Value;
        }

        private void GeneratePropertyArray()
        {
            m_Num = new KeyValuePair<int, float>[]
            {
                new KeyValuePair<int, float>(1, Num1),
                new KeyValuePair<int, float>(2, Num2),
            };
        }
    }
}
