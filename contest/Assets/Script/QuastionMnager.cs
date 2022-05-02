using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuastionMnager : MonoBehaviour
{
    //�A�^�b�`�����I�u�W�F�N�g���Ă΂ꂽ���Ɏ��s�����B
    void Start()
    {
        QuestionLabelSet();
        AnswerLabelSet();
    }

    private void QuestionLabelSet()
    {
        //����̖��O�̃I�u�W�F�N�g���������ăA�N�Z�X
        Text qLabel = GameObject.Find("Canvas/Panel/Question").GetComponentInChildren<Text>();
        //�f�[�^���Z�b�g���邱�ƂŁA���������㏑���ł���
        qLabel.text = "�����T�[�Y�N�͉���?";
    }

    private void AnswerLabelSet()
    {
        //�񓚕��ʂ̍쐬
        string[] array = new string[] { "10��", "6��", "���", "7��" };
        //�{�^����4����̂ł��ꂼ����
        for (int i = 1; i <= 3; i++)
        {
            Text ansLabel = GameObject.Find("Canvas/Panel/Answer" + i).GetComponentInChildren<Text>();
            ansLabel.text = array[i - 1];
        }
    }