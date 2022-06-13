using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField]
    private Color[] cubeColors; // 현재 스테이지에서 사용가능한 큐브의 색상 수
    public Color[] CubeColors => cubeColors;

    // 큐브셋 생성을 위한 변수
    [SerializeField]
    private GameObject cubesetPrefab;   // 큐브셋 프리팹
    [SerializeField]
    private Transform spawnPoint;   // 큐브 생성위치
    [SerializeField]
    private float spawnTime = 1.0f;    // 큐브셋 생성 주기

    private void Awake()
    {
        StartCoroutine("SpawnCubeSet");
    }

    private IEnumerator SpawnCubeSet()
    {
        while (true)
        {
            GameObject clone = Instantiate(cubesetPrefab, spawnPoint.position, Quaternion.identity);
            
            // 큐브셋 오브젝트의 자식으로 있는 9개 큐브의 MeshRenderer 컴포넌트 정보
            MeshRenderer[] renderers = clone.GetComponentsInChildren<MeshRenderer>();
            
            // 9개 큐브의 색상을 임의로 설정 (현재 스테이지에서 사용 가능한 큐브 색상 = CubeColor)
            for(int i = 0; i < renderers.Length; ++i)
            {
                int index = Random.Range(0, CubeColors.Length);
                renderers[i].material.color = CubeColors[index];
            }
            // 스폰 타임 마다 반복
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
