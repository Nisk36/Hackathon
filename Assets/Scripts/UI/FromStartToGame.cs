using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromStartToGame : MonoBehaviour
{
    bool clicked = false;
    public void Click()
    {
        if (clicked) return;  // �{�^���̘A�ő΍�
        clicked = true;
        Debug.Log("DemoScene");
        SceneManager.LoadScene("DemoScene");
    }
}

