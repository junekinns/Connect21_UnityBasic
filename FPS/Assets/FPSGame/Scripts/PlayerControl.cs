using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // ���� ����.
    public float moveSpeed = 5f;        // �̵��ӷ�(������).
    public Transform myTransform;       // �̵� ó���� ���� Ʈ������ ������Ʈ.

    // Update is called once per frame
    void Update()
    {
        // ���: Ű���� ����Ű �Է��� �޾Ƽ� ��ü�� �̵���Ų��.

        // �Է� �ޱ�.
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        // ���� �Է��� �������� �̵� ���� �����.
        Vector3 direction = new Vector3(xValue, 0f, zValue);

        // �̵� ó��.
        myTransform.position =
            myTransform.position 
            + direction.normalized 
            * moveSpeed 
            * Time.deltaTime;
    }
}
