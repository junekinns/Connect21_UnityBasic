using UnityEngine;

// PlayerState 클래스를 상속함.
public class PlayerMoveState : PlayerState
{
    public float speed = 5f;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Update()
    {
        base.Update();

        // 받은 입력을 바탕으로 이동 방향 만들기.
        Vector3 direction = new Vector3(PlayerInputManager.Horizontal, 0f, PlayerInputManager.Vertical);

        // 이동 처리.
        transform.position += direction.normalized * (speed * Time.deltaTime);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
}