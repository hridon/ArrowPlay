using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public static class XmlUtility 
{
    public static void LoadXml()
    {
        //创建xml文档
        XmlDocument xml = new XmlDocument();
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取
        xml.Load(XmlReader.Create((Application.dataPath + "/data.xml"), set));
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("objects").ChildNodes;
        //遍历所有子节点 
        foreach (XmlElement xl1 in xmlNodeList)
        {

            if (xl1.GetAttribute("id") == "1")
            {
            }
        }
    }
}
