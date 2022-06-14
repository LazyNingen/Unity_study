using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositonAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private Vector3 destroyPosition;

    private void LateUpdate()
    {
        // ������Ʈ�� ���� ���� �̻� �Ѿ�� ����
        if ((destroyPosition - transform.position).sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
