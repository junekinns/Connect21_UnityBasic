using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 변수 선언.
    public float moveSpeed = 5f;        // 이동속력(빠르기).
    public Transform myTransform;       // 이동 처리를 위한 트랜스폼 컴포넌트.

    // Update is called once per frame
    void Update()
    {
        // 기능: 키보드 방향키 입력을 받아서 물체를 이동시킨다.

        // 입력 받기.
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        // 받은 입력을 바탕으로 이동 방향 만들기.
        Vector3 direction = new Vector3(xValue, 0f, zValue);

        // 이동 처리.
        myTransform.position =
            myTransform.position 
            + direction.normalized 
            * moveSpeed 
            * Time.deltaTime;
    }
}
