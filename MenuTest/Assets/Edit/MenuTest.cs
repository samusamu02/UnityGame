using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuTest
{
    [MenuItem("�ۑ�/�_�C�A���O�e�X�g")]
    static public void Log()
    {
        EditorUtility.DisplayDialog("�_�C�A���O�e�X�g", "������_�C�A���O�e�X�g�ł�", "OK");
    }

    [MenuItem("�ۑ�/�z�u�f�[�^�o��")]
    static public void ExportSettingData()
    {
        var strPath = EditorUtility.SaveFilePanel("�z�u�f�[�^�ۑ�", ".", "PositonData", "dat");
        if (strPath == "")
        {
            EditorUtility.DisplayDialog("���s", "�z�u�f�[�^�̏o�͂Ɏ��s���܂���", "������܂����B");
            return;
        }
        var fs = File.OpenWrite(strPath);
        BinaryWriter bw = new BinaryWriter(fs);

        // ���ݑI�𒆂̃Q�[���I�u�W�F�N�g
        var gameObject = Selection.activeGameObject;
        TraverseData(bw, gameObject);

        bw.Close();
        fs.Close();

        // �ċA���g���āA�ŉ��w�܂ł̔z�u�f�[�^���o��
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
            // ���W�̏o��
            bw.Write(gameObject.transform.position.x);
            bw.Write(gameObject.transform.position.y);
            bw.Write(gameObject.transform.position.z);
        }

        EditorUtility.DisplayDialog("����", "�z�u�f�[�^�̏o�͂ɐ������܂���", "������܂����B");
    }
}
