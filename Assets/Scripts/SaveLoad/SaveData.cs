using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// How to Build A Save System in Unity https://youtu.be/5roZtuqZyuw
// SAVE & LOAD SYSTEM in Unity https://youtu.be/XOjd_qU2Ido
[System.Serializable]
public class SaveData
{
    // �ۑ����ׂ����e��
    // - player.transform.position
    // - GameManager.instance.playerLevel
    // - GameManager.instance.gemsNum
    public float[] playerPosition;
    public int playerLevel;
    public int gemsNum;
    public SaveData()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("(SaveData) Player �^�O�̕t���� GameObject ��������܂���ł���");
        }
        else
        {
            playerPosition = new float[3];
            playerPosition[0] = player.transform.position.x;
            playerPosition[1] = player.transform.position.y;
            playerPosition[2] = player.transform.position.z;
        }
        playerLevel = GameManager.instance.playerLevel;
        gemsNum = GameManager.instance.gemsNum;
    }
}
