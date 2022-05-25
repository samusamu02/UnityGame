using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuTest
{
    [MenuItem("エクスポート/配置データ")]
    static public void ExportSettingData()
    {
        const int version = 2;
        var strPath = EditorUtility.SaveFilePanel("配置データの保存", ".", "TestData", "dat");
        if (strPath == "")
        {
            EditorUtility.DisplayDialog("失敗", "配置データの出力に失敗しました", "了解しました");
            return;
        }
        EditorUtility.DisplayDialog("成功", "配置データの出力に成功しました", "了解しました");
        var fs = File.OpenWrite(strPath);
        BinaryWriter bw = new BinaryWriter(fs);
        // バージョン書き込み
        bw.Write(version);

        // 現在選択中のゲームオブジェクト
        var gameObject = Selection.activeGameObject;
        TravasData(bw, gameObject);
        bw.Close();
        fs.Close();

        // 再帰を使って、最下層までのデータの配置データを出力する
        static void TravasData(BinaryWriter bw, GameObject gameObject)
        {
            var methFilter = gameObject.GetComponent<MeshFilter>();
            // bw.Write(methFilter);
            if (methFilter != null)
            {
                bw.Write(methFilter.sharedMesh.name.ToString());
                ExportTransform(bw, (GameObject)gameObject);
            }
            // 再帰
            var tarns = gameObject.transform;
            var childCount = gameObject.transform.childCount;
            Debug.Log(childCount);
            for(int i = 0; i < childCount; ++i)
            {
                TravasData(bw, tarns.GetChild(i).gameObject);
            }
        }

        static void ExportTransform(BinaryWriter bw, GameObject gameObject)
        {
            // 座標の出力
            bw.Write(gameObject.transform.position.x);
            bw.Write(gameObject.transform.position.y);
            bw.Write(gameObject.transform.position.z);

            // 回転出力
            bw.Write(gameObject.transform.rotation.x);
            bw.Write(gameObject.transform.rotation.y);
            bw.Write(gameObject.transform.rotation.z);
            // 拡大出力
            bw.Write(gameObject.transform.localScale.x);
            bw.Write(gameObject.transform.localScale.y);
            bw.Write(gameObject.transform.localScale.z);
        }
    }
}
