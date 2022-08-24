using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // Animator 컴포넌트 변수.
    public Animator animator;

    // Animator Controller에서 State 파라미터를 설정하는 함수.
    public void SetStateParameter(int state)
    {
        animator.SetInteger("State", state);
    }

    private void Update()
    {
        // 방향키 입력을 읽어서 파라미터에 설정.
        animator.SetFloat("Horizontal", PlayerInputManager.Horizontal);
        animator.SetFloat("Vertical", PlayerInputManager.Vertical);
    }
}