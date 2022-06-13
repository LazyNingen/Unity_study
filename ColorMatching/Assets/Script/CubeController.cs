using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private CubeSpawner cubeSpawner;
    private CubeChecker cubeChecker;
    private MeshRenderer meshRenderer;
    private int colorIndex;

    public void SetUp(CubeSpawner cubeSpawner, CubeChecker cubeChecker)
    {
        this.cubeSpawner = cubeSpawner;
        this.cubeChecker = cubeChecker;

        meshRenderer = GetComponent<MeshRenderer>();

        // 모든 TouchCube의 색상을 첫번째 색으로 설정
        meshRenderer.material.color = this.cubeSpawner.CubeColors[0];
        colorIndex = 0;
    }

    public void ChangeColor()
    {
        // 다음 큐브 색상으로 인덱스를 변경
        if(colorIndex < cubeSpawner.CubeColors.Length - 1)
        {
            colorIndex++;
        }
        else
        {
            colorIndex = 0;
        }
        // 큐브의 색상 변경
        meshRenderer.material.color = cubeSpawner.CubeColors[colorIndex];
    }

    public void OnTriggerEnter(Collider other)
    {
        MeshRenderer renderer = other.GetComponent<MeshRenderer>();

        // TouchCube와 부딪힌 큐브의 색상이 같을 때
        if(meshRenderer.material.color == renderer.material.color)
        {
            cubeChecker.CorrectCount++;
        }
        else
        {
            cubeChecker.IncorrectCount++;
        }
    }
}
