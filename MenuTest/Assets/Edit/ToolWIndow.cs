using UnityEngine;
using UnityEditor;
using System.Collections;

class ToolWindow : EditorWindow
{
    [MenuItem("�ۑ�/�c�[���E�B���h�E�̕\��")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ToolWindow));
    }
    void OnGUI()
    {
        EditorGUILayout.LabelField("�c�[���\���e�X�g");
    }
}
