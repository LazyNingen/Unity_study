using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner cubeSpawner;

    [SerializeField]
    private GameController gameController;

    private CubeController[] touchCubes;

    private int correctCount = 0;
    private int incorrectCount = 0;

    // 각 TouchCube에서 자신에게 부딪히는 큐브가 색상이 같으면 correctCount증가
    public int CorrectCount
    {
        set => correctCount = Mathf.Max(0, value);
        get => correctCount;
    }
    // 각 TouchCube에서 자신에게 부딪히는 큐브가 색상이 다르면 incorrectCount증가
    public int IncorrectCount
    {
        set => incorrectCount = Mathf.Max(0, value);
        get => incorrectCount;
    }

    private void Awake()
    {
        touchCubes = GetComponentsInChildren<CubeController>();

        for (int i = 0; i < touchCubes.Length; ++i)
        {
            touchCubes[i].SetUp(cubeSpawner, this);
        }
    }

    private void Update()
    {
        // 게임오버 상태이면 점수 검사를 하지 않음
        if (gameController.IsGameOver == true) return;

        // 만약 맞은 개수 + 틀린 개수가 터치 가능한 큐브의 개수와 같을 때
        if(CorrectCount + IncorrectCount == touchCubes.Length)
        {
            // 하나도 틀리지 않았을 경우 : 성공
            if (IncorrectCount == 0)
            {
                //Debug.Log("Success");
                gameController.IncreaseScore();
            }

            // 하나라도 틀릴 경우 : 실패
            else
            {
                // Debug.Log("Failed");
                gameController.GameOver();
            }

            CorrectCount = 0;
            IncorrectCount = 0;
        }
    }
}
