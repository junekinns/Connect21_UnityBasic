using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ���� ����.
    // ������ Ÿ�� �����̸� = �⺻��;
    // float Ÿ�� -> ���� ����. �Ҽ��� ���ڸ� �����Ѵ�.
    // int(integer) Ÿ�� -> ���� ����. ����(�Ҽ��� ���� ����)�� �����Ѵ�.
    public float moveSpeed = 10f;       // �̵� �ӷ�.
    public Transform myTransform;       // Ʈ������ ������Ʈ ����.

    // ���� ������ Ŭ���� ����.
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �̵� ���: ����Ű �Է��� �޾Ƽ� �÷��̾ �̵� ��Ų��.
        // 1.�Է� ó��.
        // �¿� �Է� ->
        // ���� ����Ű�� ������ -1,
        // �ƹ�Ű�� ������ ������ 0,
        // ������ ����Ű�� ������ 1.
        float horizontal = Input.GetAxis("Horizontal");

        // ���� �Է�.
        // ���� Ű�� ������ 1,
        // �ƹ� Ű�� ������ ������ 0,
        // �Ʒ��� Ű�� ������ -1.
        float vertical = Input.GetAxis("Vertical");

        // 2.�Է� ���� �����͸� ����ؼ� �̵� ���� �����.
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        // 3.�̵� ���⿡ �����⸦ �����ؼ� �÷��̾� �̵���Ű��.
        // �׷� ����, �̵� �ӵ� ������ ��(second) ������ ����.
        // normalized�� ����ϸ� ���̰� 1�� ���Ѵ�(->����ȭ, ���� ����).
        moveDirection = 
            moveDirection.normalized 
            * moveSpeed 
            * Time.deltaTime;

        // �̵� ó��.
        myTransform.position = myTransform.position + moveDirection;
    }


    // Trigger(Ʈ����) Ÿ���� �浹 ó�� �Լ�.
    // ����Ƽ �������� �����ϴ� �Լ�(�ڵ� �����).
    // Ʈ���� Ÿ������ �浹�� ���۵��� �� �����.
    // other �Ķ���ʹ� �� ��ü�� �浹�� �ٸ� ��ü.
    // Ʈ���� ���: �հ� �������� �� ���. ��� �浹���� �� ������ ��ȣ�� ��.
    // �ݸ��� ���: ���հ� ������. �浹 ������ ������ ��ȣ�� ��.
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� �̸� ���.
        Debug.Log("�÷��̾ �浹��: " + other.name);

        // ����
        // other.gameObject => other ������Ʈ�� �پ��ִ� ���� ������Ʈ.
        Destroy(other.gameObject);

        // ���� ȹ��.
        gameManager.AddScore();

    }


}