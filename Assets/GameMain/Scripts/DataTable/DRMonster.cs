//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-09-12 12:00:27.473
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
    /// 怪物配置表。
    /// </summary>
    public class DRMonster : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取怪物ID。
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
        /// 获取切片资源。
        /// </summary>
        public string PreferName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击动作。
        /// </summary>
        public string AttackAction
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取移动动作。
        /// </summary>
        public string MoveAction
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取待机动作。
        /// </summary>
        public string IdleAction
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取AI编号。
        /// </summary>
        public int AIID
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取武器ID。
        /// </summary>
        public int WeaponID
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取基础攻击。
        /// </summary>
        public int BaseAttack
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取基础生命。
        /// </summary>
        public int BaseHP
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取伤害减免。
        /// </summary>
        public int DamageReduction
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取显示比例。
        /// </summary>
        public float Scale
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
            PreferName = columnTexts[index++];
            AttackAction = columnTexts[index++];
            MoveAction = columnTexts[index++];
            IdleAction = columnTexts[index++];
            AIID = int.Parse(columnTexts[index++]);
            WeaponID = int.Parse(columnTexts[index++]);
            BaseAttack = int.Parse(columnTexts[index++]);
            BaseHP = int.Parse(columnTexts[index++]);
            DamageReduction = int.Parse(columnTexts[index++]);
            Scale = float.Parse(columnTexts[index++]);
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
                    PreferName = binaryReader.ReadString();
                    AttackAction = binaryReader.ReadString();
                    MoveAction = binaryReader.ReadString();
                    IdleAction = binaryReader.ReadString();
                    AIID = binaryReader.ReadInt32();
                    WeaponID = binaryReader.ReadInt32();
                    BaseAttack = binaryReader.ReadInt32();
                    BaseHP = binaryReader.ReadInt32();
                    DamageReduction = binaryReader.ReadInt32();
                    Scale = binaryReader.ReadSingle();
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
