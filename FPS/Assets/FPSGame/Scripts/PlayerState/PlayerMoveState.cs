using UnityEngine;

// PlayerState 클래스를 상속함.
public class PlayerMoveState : PlayerState
{
    public float speed = 5f;
    
    // 캐릭터 컨트롤러 컴포넌트.
    public CharacterController characterController;
    protected override void OnEnable()
    {
        base.OnEnable();

        // 캐릭터 컨트롤러 컴포넌트가 설정돼지 않았으면, 
        // GetComponent 함수를 사용해 설정.
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
    }


    protected override void Update()
    {
        base.Update();

        // 받은 입력을 바탕으로 이동 방향 만들기.
        Vector3 direction = myTransform.right * PlayerInputManager.Horizontal + myTransform.forward * PlayerInputManager.Vertical;

        // 이동 처리.
        characterController.Move(direction.normalized * speed * Time.deltaTime);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
}