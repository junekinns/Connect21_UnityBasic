using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 변수 선언.
    // 한정자 변수타입 변수이름.
    public Transform myTransform;

    // 코멘트(주석). 우리가 알아볼 목적으로 작성하는 메모.
    // 동작에는 영향을 주지 않고, 유니티는 이 메모를 무시한다.
    // Start is called before the first frame update
    void Start()
    {
        // 유니티 콘솔(Console) 창에 일반 메시지 출력해보기.
        // 텍스트를 값으로 만들 때는 따옴표 "" 안에 원하는 텍스트를 입력.
        Debug.Log("Start 함수 실행.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 함수 실행.");

        // 회전.
        // y축으로 30도 만큼 회전을 더한다.
        // * Time.deltaTime을 하면 기준이 초(Second)로 바뀐다.
        Vector3 rotation = new Vector3(30f, 45f, 60f) * Time.deltaTime;
        myTransform.Rotate(rotation);
    }
}