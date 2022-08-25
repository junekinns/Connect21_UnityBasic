using UnityEngine;

// 플레이어 상태의 기본 클래스.
public class PlayerState : MonoBehaviour
{
    // 진입점(Entry).
    // OnEnable() - 유니티 엔진에서 실행해주는 함수.
    // 이 컴포넌트가 활성화되면 1번 실행.
    // 비활성화 됐다가 다시 활성화 되면 다시 1번 실행.

    // 회전 속도 변수.
    public float rotationSpeed = 540f;

    // 트랜스폼 컴포넌트 변수.
    protected Transform myTransform;

    // 한정자: public/protected/private.
    // virtual -> 자식 클래스에서 이 함수를 변경할 수 있도록 선언.
    protected virtual void OnEnable()
    {
        if (myTransform == null)
        {
            myTransform = GetComponent<Transform>();
        }
    }

    // 업데이트. (Update).
    protected virtual void Update()
    {
        // 회전 방향.
        Vector3 rotation = new Vector3(
            0f,
            // 방향 x 회전 빠르기 x 프레임 시간.
            PlayerInputManager.Turn * rotationSpeed * Time.deltaTime,
            0f
        );

        // 물체 회전.
        myTransform.Rotate(rotation);
    }

    // 종료(End).
    // OnDisable - 유니티 엔진에서 자동 실행해주는 함수.
    // 이 컴포넌트가 비활성화 되면 1번 실행.
    // 활성화 됐다가 다시 비활성화 되면 다시 1번 실행.
    protected virtual void OnDisable()
    {
        
    }
}