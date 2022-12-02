using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;
    public TextMeshProUGUI txtScore;
    public GameObject gameStartUI;

    //Khởi tạo instance game trong bộ nhớ trước khi dùng
    private void Awake()
    {
        instance = this;
    }

    //Start game
    public void GameStart()
    {
        gameStartUI.SetActive(false);
        txtScore.gameObject.SetActive(true);
    }
    //Restart game
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }
    //Ghi điểm mỗi lần ball chạm paddle
    public void ScoreUp()
    {
        score++;
        txtScore.text = score.ToString();
    }
}
