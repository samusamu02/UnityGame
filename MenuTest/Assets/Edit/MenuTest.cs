using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuTest
{
    [MenuItem("課題/ダイアログテスト")]
    static public void Log()
    {
        EditorUtility.DisplayDialog("ダイアログテスト", "こちらダイアログテストです", "OK");
    }

    [MenuItem("課題/配置データ出力")]
    static public void ExportSettingData()
    {
        var strPath = EditorUtility.SaveFilePanel("配置データ保存", ".", "PositonData", "dat");
        if (strPath == "")
        {
            EditorUtility.DisplayDialog("失敗", "配置データの出力に失敗しました", "分かりました。");
            return;
        }
        var fs = File.OpenWrite(strPath);
        BinaryWriter bw = new BinaryWriter(fs);

        // 現在選択中のゲームオブジェクト
        var gameObject = Selection.activeGameObject;
        TraverseData(bw, gameObject);

        bw.Close();
        fs.Close();

        // 再帰を使って、最下層までの配置データを出力
        static void TraverseData(BinaryWriter bw, GameObject gameObject)
        {
            Debug.Log(gameObject);
            var meshFilete = gameObject.GetComponent<MeshFilter>();
            if (meshFilete != null)
            {
                bw.Write(meshFilete.sharedMesh.name.ToString());
                ExportPositon(bw, (GameObject)gameObject);
            }
            var trans = gameObject.transform;
            var childCount = trans.childCount;
            Debug.Log(childCount);
            for (int i = 0; i < childCount; i++)
            {
                TraverseData(bw, trans.GetChild(i).gameObject);
            }
        }

        static void ExportPositon(BinaryWriter bw, GameObject gameObject)
        {
            // 座標の出力
            bw.Write(gameObject.transform.position.x);
            bw.Write(gameObject.transform.position.y);
            bw.Write(gameObject.transform.position.z);
        }

        EditorUtility.DisplayDialog("成功", "配置データの出力に成功しました", "分かりました。");
    }
}
