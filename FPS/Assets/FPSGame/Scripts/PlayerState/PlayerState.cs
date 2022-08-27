using System;
using UnityEngine;

// 플레이어 상태의 기본 클래스.
public class PlayerState : MonoBehaviour{
    protected PlayerData data;

    public void SetData(PlayerData data){
        this.data = data;
    }
    protected virtual void OnEnable()
    {
    }

    // 업데이트. (Update).
    protected virtual void Update()
    {
        // 회전 방향.
        Vector3 rotation = new Vector3(
            0f,
            // 방향 x 회전 빠르기 x 프레임 시간.
            PlayerInputManager.Turn * data.rotationSpeed * Time.deltaTime,
            0f
        );

        // 물체 회전.
        transform.Rotate(rotation);
    }

    // 종료(End).
    // OnDisable - 유니티 엔진에서 자동 실행해주는 함수.
    // 이 컴포넌트가 비활성화 되면 1번 실행.
    // 활성화 됐다가 다시 비활성화 되면 다시 1번 실행.
    protected virtual void OnDisable()
    {
        
    }
}