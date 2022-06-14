using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textScore;
    private int score = 0;

    [SerializeField]
    private GameObject panelResult;
    [SerializeField]
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private TextMeshProUGUI textHighScore;

    public bool IsGameOver { private set; get; }

    private void Awake()
    {
        IsGameOver = false;
    }

    public void IncreaseScore()
    {
        score++;
        textScore.text = $"Score {score}";
    }

    public void GameOver()
    {
        // 현재 상태를 게임오버로 설정
        IsGameOver = true;
        // 스테이지의 점수 출력 비활성화
        textScore.enabled = false;
        // 결과 화면 Panel UI 활성화
        panelResult.SetActive(true);

        // 기존에 등록된 가장 높은 점수 불러오기
        int highScore = PlayerPrefs.GetInt("HighScore");

        // 기존 점수가 HighScore보다 낮을 때
        if(score < highScore)
        {
            textHighScore.text = $"High Score {highScore}";
        }
        else
        {
            // 현재 점수를 HighScore로 저장
            PlayerPrefs.SetInt("HighScore", score);
            textHighScore.text = $"High Score {score}";
        }

        textResultScore.text = $"Score {score}";
    }
}
