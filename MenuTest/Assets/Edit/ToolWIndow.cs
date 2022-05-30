using UnityEngine;
using UnityEditor;
using System.Collections;

class ToolWindow : EditorWindow
{
    [MenuItem("課題/ツールウィンドウの表示")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ToolWindow));
    }
    void OnGUI()
    {
        EditorGUILayout.LabelField("ツール表示テスト");
    }
}
