using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    // Animator 컴포넌트.
    public Animator animator;

    // 적 캐릭터가 상태를 변경할 때 사용.
    public void SetState(EnemyStateManager.State newState)
    {
        if (newState == EnemyStateManager.State.Dead)
        {
            animator.SetTrigger("Dead");
            return;
        }

        animator.SetInteger("State", (int)newState);
    }
}