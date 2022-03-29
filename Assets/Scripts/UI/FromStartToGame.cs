using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromStartToGame : MonoBehaviour
{
    bool clicked = false;
    public void Click()
    {
        GameManager.instance.playerLevel = 1;
        GameManager.instance.gemsNum = 0;
        for (var i = 0; i < 5; i++)
        {
            GameManager.instance.questIsDone[i] = false;
        }
        if (clicked) return;  // �{�^���̘A�ő΍�
        clicked = true;
        Debug.Log("DemoScene");
        SceneManager.LoadScene("DemoScene");

    }
}

