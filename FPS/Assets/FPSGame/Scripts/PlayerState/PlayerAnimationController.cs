using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // Animator 컴포넌트 변수.
    public Animator myAnimator;
    public CameraRig cameraRig;
    public float rotationOffset = 0.5f;

    // Animator Controller에서 State 파라미터를 설정하는 함수.
    public void SetStateParameter(int state)
    {
        myAnimator.SetInteger("State", state);
    }

    private void Update()
    {
        // 방향키 입력을 읽어서 파라미터에 설정.
        myAnimator.SetFloat("Horizontal", PlayerInputManager.Horizontal);
        myAnimator.SetFloat("Vertical", PlayerInputManager.Vertical);
        
        myAnimator.SetFloat("AimAngle", cameraRig.GetXRotation() * rotationOffset);
    }
    
    
    // 재장전 애니메이션을 재생시키는 함수.
    public void OnReload()
    {
        // Reload 트리거를 설정해 재장전 애니메이션이 재생되도록 함.
        myAnimator.SetTrigger("Reload");
    }

    // 재장전 애니메이션이 완료될 때까지 걸리는 시간을 계산하는 함수.
    public float WaitTimeToReload()
    {
        // 두 번째 레이어(=Reload 레이어)에서 재생되고 있는 
        // 애니메이션의 길이 / 재생 속도(배수).
        return myAnimator.GetCurrentAnimatorStateInfo(1).length / myAnimator.GetFloat("ReloadSpeed");
    }
}