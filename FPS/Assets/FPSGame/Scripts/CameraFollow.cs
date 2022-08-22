using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��ü(�÷��̾�)�� ���� �Ÿ��� �����ϸ鼭 ����ٴϴ� ī�޶� ��ũ��Ʈ.
public class CameraFollow : MonoBehaviour
{
    // ���� ����.
    public Transform followTarget;          // ī�޶� ����ٴ� ���(Ÿ��).
    public Transform myTransform;           // ��(ī�޶�) Ʈ������.
    public float damping = 5f;              // �̵��� �� ������(����) ��.

    // ī�޶�� ����ٴ� ������ �Ÿ�.
    // ó�� �ѹ��� ����ϰ� ��� �����(ó�� �ѹ��� ���).
    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� ������Ʈ���� Ʈ�������� �˻��ؼ� �����ϱ�.
        // GetComponent: ���� ���� ������Ʈ���� ������Ʈ�� �˻��ϴ� ���.
        // GetComponent �ڿ� <> ��ȣ �ȿ� �˻��ϰ��� �ϴ� Ÿ���� ����.
        // �˻��� �����ϸ� �ش� ������Ʈ�� ���� �� �ְ�, �����ϸ� �� ��(null)�� ��.
        myTransform = GetComponent<Transform>();

        // ����ٴ� ������ �Ÿ� ���.
        // �� ��ġ���� ����ٴ� ����� ��ġ�� ���� �ȴ�.
        distance = myTransform.position - followTarget.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // ����ٴϴ� ���.
        // �÷��̾��� ��ġ���� �ռ� ���� �Ÿ���ŭ ���������� ���.
        myTransform.position = followTarget.position + distance;

    }
}
