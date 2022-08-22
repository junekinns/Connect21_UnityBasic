using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // ���� ����.
    // ������ ����Ÿ�� �����̸�.
    public Transform myTransform;

    // �ڸ�Ʈ(�ּ�). �츮�� �˾ƺ� �������� �ۼ��ϴ� �޸�.
    // ���ۿ��� ������ ���� �ʰ�, ����Ƽ�� �� �޸� �����Ѵ�.
    // Start is called before the first frame update
    void Start()
    {
        // ����Ƽ �ܼ�(Console) â�� �Ϲ� �޽��� ����غ���.
        // �ؽ�Ʈ�� ������ ���� ���� ����ǥ "" �ȿ� ���ϴ� �ؽ�Ʈ�� �Է�.
        Debug.Log("Start �Լ� ����.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update �Լ� ����.");

        // ȸ��.
        // y������ 30�� ��ŭ ȸ���� ���Ѵ�.
        // * Time.deltaTime�� �ϸ� ������ ��(Second)�� �ٲ��.
        Vector3 rotation = new Vector3(30f, 45f, 60f) * Time.deltaTime;
        myTransform.Rotate(rotation);
    }
}