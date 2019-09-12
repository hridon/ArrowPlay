using GameFramework;
using UnityGameFramework.Runtime;

namespace ArrowPlay
{
    public class AssetUtility
    {
        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        }

        public static string GetDataTableAsset(string assetName, LoadType loadType)
        {
            return Utility.Text.Format("Assets/GameMain/DataTables/{0}.{1}", assetName, loadType == LoadType.Text ? "txt" : "bytes");
        }

        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Resources/UI/UIForms/{0}.prefab", assetName);
        }

        public static string GetEntityAsst(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Resources/Entities/{0}.prefab", assetName);
        }

        public static string GetXmlAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Resources/Xml/{0}.xml", assetName);
        }
    }
}


