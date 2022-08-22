using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 변수 선언.
    // 한정자 타입 변수이름 = 기본값;
    // float 타입 -> 숫자 저장. 소수점 숫자를 저장한다.
    // int(integer) 타입 -> 숫자 저장. 정수(소수점 없는 숫자)를 저장한다.
    public float moveSpeed = 10f;       // 이동 속력.
    public Transform myTransform;       // 트랜스폼 컴포넌트 변수.

    // 게임 관리자 클래스 변수.
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 이동 기능: 방향키 입력을 받아서 플레이어를 이동 시킨다.
        // 1.입력 처리.
        // 좌우 입력 ->
        // 왼쪽 방향키가 눌리면 -1,
        // 아무키도 눌리지 않으면 0,
        // 오른쪽 방향키가 눌리면 1.
        float horizontal = Input.GetAxis("Horizontal");

        // 상하 입력.
        // 위쪽 키가 눌리면 1,
        // 아무 키도 눌리지 않으면 0,
        // 아래쪽 키가 눌리면 -1.
        float vertical = Input.GetAxis("Vertical");

        // 2.입력 받은 데이터를 사용해서 이동 방향 만들기.
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        // 3.이동 방향에 빠르기를 적용해서 플레이어 이동시키기.
        // 그런 다음, 이동 속도 단위로 초(second) 단위로 변경.
        // normalized를 사용하면 길이가 1로 변한다(->정규화, 단위 벡터).
        moveDirection = 
            moveDirection.normalized 
            * moveSpeed 
            * Time.deltaTime;

        // 이동 처리.
        myTransform.position = myTransform.position + moveDirection;
    }


    // Trigger(트리거) 타입의 충돌 처리 함수.
    // 유니티 엔진에서 제공하는 함수(자동 실행됨).
    // 트리거 타입으로 충돌이 시작됐을 때 실행됨.
    // other 파라미터는 이 물체와 충돌한 다른 물체.
    // 트리거 방식: 뚫고 지나가는 걸 허용. 대신 충돌했을 때 엔진이 신호를 줌.
    // 콜리전 방식: 못뚫고 지나감. 충돌 했을때 엔진이 신호도 줌.
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체의 이름 출력.
        Debug.Log("플레이어가 충돌함: " + other.name);

        // 삭제
        // other.gameObject => other 컴포넌트가 붙어있는 게임 오브젝트.
        Destroy(other.gameObject);

        // 점수 획득.
        gameManager.AddScore();

    }


}