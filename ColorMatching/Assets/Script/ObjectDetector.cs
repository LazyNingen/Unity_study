using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RaycastEvent : UnityEvent<Transform> { }

public class ObjectDetector : MonoBehaviour
{
    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    [SerializeField]
    private LayerMask layerMask;
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        // MainCamera �±׸� ������ �ִ� ������Ʈ�� ã�� Camera ������Ʈ ������ ����
        // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); �� ����
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            // ī�޶� ��ġ���� ȭ���� ���콺 ��ġ�� �����ϴ� ���� ����
            // ray.origin : ������ ������ġ(ī�޶� ��ġ)
            // ray.direction : ������ �������
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // 2D ����͸� ���� 3D ������ ������Ʈ�� ���콺�� �����ϴ� ���
            // ������ �ε����� ������Ʈ�� �����ڼ� hit�� ����
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // �ε��� ������Ʈ�� Transform ������ �Ű������� �̺�Ʈ ȣ��
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}
