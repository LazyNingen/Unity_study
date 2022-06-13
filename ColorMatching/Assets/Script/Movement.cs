using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f; // �ӵ��� �Է� ����
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;  // �̵� ������ �Է� ����

    private void Update()
    {
        // �̵� ����� �ӵ��� �Է� ������ �ڵ����� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
