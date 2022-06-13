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
        // ���� ���¸� ���ӿ����� ����
        IsGameOver = true;
        // ���������� ���� ��� ��Ȱ��ȭ
        textScore.enabled = false;
        // ��� ȭ�� Panel UI Ȱ��ȭ
        panelResult.SetActive(true);

        // ������ ��ϵ� ���� ���� ���� �ҷ�����
        int highScore = PlayerPrefs.GetInt("HighScore");

        // ���� ������ HighScore���� ���� ��
        if(score < highScore)
        {
            textHighScore.text = $"High Score {highScore}";
        }
        else
        {
            // ���� ������ HighScore�� ����
            PlayerPrefs.SetInt("HighScore", score);
            textHighScore.text = $"High Score {score}";
        }

        textResultScore.text = $"Score {score}";
    }
}
