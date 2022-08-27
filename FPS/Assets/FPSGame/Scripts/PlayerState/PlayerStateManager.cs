using System;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // 플레이어의 상태를 정의하는 열거형(Enum).
    public enum EPlayerState
    {
        Idle=0, Move
    }

    // 플레이어의 현재 상태를 추적하기 위한 변수.
    public EPlayerState currentState = EPlayerState.Idle;

    // 플레이어가 가질 수 있는 모든 상태(스크립트).
    public PlayerState[] states;

    // 플레이어의 애니메이션 설정 관련 컨트롤러 스크립트.
    public PlayerAnimationController animationController;
    
    public PlayerData data;

    private void SetState(EPlayerState newState)
    {
        if (currentState == newState)
        {
            return;
        }

        // 1. 현재 상태의 스크립트를 비활성화.
        states[(int)currentState].enabled = false;

        // 2. 변경할 상태의 컴포넌트를 활성화.
        states[(int)newState].enabled = true;

        // 3. 현재 상태를 새로운 상태 값으로 설정.
        currentState = newState;

        // 4. 애니메이션 State 파라미터 설정.
        animationController.SetStateParameter((int)newState);
    }

    private void OnEnable(){
        SetState(EPlayerState.Idle);

        foreach (PlayerState playerState in states){
            playerState.SetData(data);
        }
    }

    private void Update()
    {
        // 상태 전환.
        // 입력이 없는 지 확인.
        if (PlayerInputManager.Horizontal == 0f && PlayerInputManager.Vertical == 0f)
        {
            // 입력이 없으면 기본 상태로 전환.
            SetState(EPlayerState.Idle);
        }
        else
        {
            // 이동 상태로 전환.
            SetState(EPlayerState.Move);
        }
    }
}