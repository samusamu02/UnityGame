using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Menu
{
    [MenuItem("Menu/TestMenu")]
    static public void Dialog()
    {
        EditorUtility.DisplayDialog("�_�C�A���O", "�_�C�A���O�ł��B", "�͂�");
    }
}
