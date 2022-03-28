using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameoverText;
    public PlayerScript player;
    public BossScript boss;

    public GameObject gameClearUI;

    public void GameOver()
    {
        gameoverText.SetActive(true);
        Invoke("GameRestart", 1f);

    }

    public void GameClear()
    {
        //SceneManager.LoadScene("ClearScene");
        gameClearUI.SetActive(true);
    }

    public void GameRestart()
    {
        // ���݂̃V�[�����擾���ă��[�h����
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
        //DemoScene�Ŏ��񂾂Ȃ�Level,GemNum,Quest�t���O�S�����Z�b�g
        if (SceneManager.GetActiveScene().name == "DemoScene")
        {
            GameManager.instance.playerLevel = 1;
            GameManager.instance.gemsNum = 0;
            for (var i = 0; i < 5; i++)
            {
                GameManager.instance.questIsDone[i] = false;
            }
        }
        //�{�X�Ŏ��񂾂Ȃ�{�X���ɏオ�������x�����܂߃��X�^�[�g�i�~�ς����˂�
    }

    private void Update()
    {
        if (player.getIsDead()) GameOver();
        if(SceneManager.GetActiveScene().name == "Boss_Battle")
        {
            if (boss.IsBossDead()) GameClear();
        }
    }
}
