using UnityEngine;

// 플레이어 입력 관리자.
// 사용자의 입력을 받아 처리하고, 관련된 변수를 저장 및 관리.
public class PlayerInputManager : MonoBehaviour
{
    // 입력 변수.
    public static float Horizontal;
    public static float Vertical;

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
}