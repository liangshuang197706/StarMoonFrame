using UnityEditor;
using UnityEngine;
using System.IO;

namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/
    public class CreateAssetbundles : MonoBehaviour
    {

        [MenuItem("AssetsBundle/Build AssetBundles")]
        static void BuildAllAssetBundles()//���д��
        {
            string dir = Application.streamingAssetsPath + "/AssetBundles";
            // �жϸ�Ŀ¼�Ƿ����
            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);//�ڹ����´���AssetBundlesĿ¼
            }
            // ����һΪ������ĸ�·����������ѹ��ѡ��  ������ ƽ̨��Ŀ��
            BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        }
    }
}