using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ArrowPlay
{
    //此脚本已废弃

    public class ChoiceChapterEvent : UGuiForm
    {
      
        // Use this for initialization
        void Start()
        {
            Sceninfo();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void Sceninfo()
        {
          var  ChapterNum = TableDataExtension.GetTableData<DRScene>(601).ChapterNum;//场景601 测试

        }
      

    }
}
