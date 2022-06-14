using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositonAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private Vector3 destroyPosition;

    private void LateUpdate()
    {
        // 오브젝트가 일정 범위 이상 넘어가면 삭제
        if ((destroyPosition - transform.position).sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
