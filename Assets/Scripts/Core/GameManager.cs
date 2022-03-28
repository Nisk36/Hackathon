using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �Q�[���}�l�[�W���[������Ă݂悤 https://youtu.be/JyrBl-06FAs?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy
    // GameManager �Ƃ́A�O���[�o���ϐ��u����ł��B
    public static GameManager instance { get; private set; }
    // public static GameManager instance = null;  // ����
    public int playerLevel = 1;
    public int gemsNum = 0;

    public bool[] questIsDone = new bool[5];

    // Usage:
    //   GameManager.instance.gemsNum++;
    //   �̂悤�ɁAGetComponent �Ȃǂ������Ƃ��ϐ����w��\�B
    private void Awake()
    {
        // GameManager: �V�[�����ς���Ă��ێ������ singleton
        if (!instance)
        {
            // ������
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // �����ς�
            Destroy(gameObject);
        }
    }

    public void Intailize()
    {
        GameManager.instance.playerLevel = 1;
        GameManager.instance.gemsNum = 0;
        for (var i = 0; i < 5; i++)
        {
            GameManager.instance.questIsDone[i] = false;
        }
    }
    /*private void Update()
    {
        // �f�o�b�O�p S �L�[�Z�[�u
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveManager.Save();
        }
    }*/

 
}
