using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField]
    private Color[] cubeColors; // ���� ������������ ��밡���� ť���� ���� ��
    public Color[] CubeColors => cubeColors;

    // ť��� ������ ���� ����
    [SerializeField]
    private GameObject cubesetPrefab;   // ť��� ������
    [SerializeField]
    private Transform spawnPoint;   // ť�� ������ġ
    [SerializeField]
    private float spawnTime = 1.0f;    // ť��� ���� �ֱ�

    private void Awake()
    {
        StartCoroutine("SpawnCubeSet");
    }

    private IEnumerator SpawnCubeSet()
    {
        while (true)
        {
            GameObject clone = Instantiate(cubesetPrefab, spawnPoint.position, Quaternion.identity);
            
            // ť��� ������Ʈ�� �ڽ����� �ִ� 9�� ť���� MeshRenderer ������Ʈ ����
            MeshRenderer[] renderers = clone.GetComponentsInChildren<MeshRenderer>();
            
            // 9�� ť���� ������ ���Ƿ� ���� (���� ������������ ��� ������ ť�� ���� = CubeColor)
            for(int i = 0; i < renderers.Length; ++i)
            {
                int index = Random.Range(0, CubeColors.Length);
                renderers[i].material.color = CubeColors[index];
            }
            // ���� Ÿ�� ���� �ݺ�
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
