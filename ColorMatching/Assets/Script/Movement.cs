using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f; // 속도를 입력 받음
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;  // 이동 방향을 입력 받음

    private void Update()
    {
        // 이동 방향과 속도를 입력 받으면 자동으로 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
