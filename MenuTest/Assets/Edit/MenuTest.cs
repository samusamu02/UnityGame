using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuTest
{
    [MenuItem("�G�N�X�|�[�g/�z�u�f�[�^")]
    static public void ExportSettingData()
    {
        const int version = 2;
        var strPath = EditorUtility.SaveFilePanel("�z�u�f�[�^�̕ۑ�", ".", "TestData", "dat");
        if (strPath == "")
        {
            EditorUtility.DisplayDialog("���s", "�z�u�f�[�^�̏o�͂Ɏ��s���܂���", "�������܂���");
            return;
        }
        EditorUtility.DisplayDialog("����", "�z�u�f�[�^�̏o�͂ɐ������܂���", "�������܂���");
        var fs = File.OpenWrite(strPath);
        BinaryWriter bw = new BinaryWriter(fs);
        // �o�[�W������������
        bw.Write(version);

        // ���ݑI�𒆂̃Q�[���I�u�W�F�N�g
        var gameObject = Selection.activeGameObject;
        TravasData(bw, gameObject);
        bw.Close();
        fs.Close();

        // �ċA���g���āA�ŉ��w�܂ł̃f�[�^�̔z�u�f�[�^���o�͂���
        static void TravasData(BinaryWriter bw, GameObject gameObject)
        {
            var methFilter = gameObject.GetComponent<MeshFilter>();
            // bw.Write(methFilter);
            if (methFilter != null)
            {
                bw.Write(methFilter.sharedMesh.name.ToString());
                ExportTransform(bw, (GameObject)gameObject);
            }
            // �ċA
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
            // ���W�̏o��
            bw.Write(gameObject.transform.position.x);
            bw.Write(gameObject.transform.position.y);
            bw.Write(gameObject.transform.position.z);

            // ��]�o��
            bw.Write(gameObject.transform.rotation.x);
            bw.Write(gameObject.transform.rotation.y);
            bw.Write(gameObject.transform.rotation.z);
            // �g��o��
            bw.Write(gameObject.transform.localScale.x);
            bw.Write(gameObject.transform.localScale.y);
            bw.Write(gameObject.transform.localScale.z);
        }
    }
}
