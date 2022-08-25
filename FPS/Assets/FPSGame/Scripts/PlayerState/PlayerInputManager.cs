using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // 입력 변수.
    // 캐릭터 이동에 사용.
    public static float Horizontal;
    public static float Vertical;

    // 캐릭터 회전에 사용.
    public static float Turn;       // 마우스 좌우 드래그 입력.
    public static float Look;       // 마우스 상하 드래그 입력.

    // 총알 발사에 사용.
    // 부울(Boolean) 참 또는 거짓.
    public static bool IsFire;      // 마우스 왼쪽 클릭/왼쪽 Ctrl.

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Turn = Input.GetAxis("Mouse X");
        Look = Input.GetAxis("Mouse Y");

        IsFire = Input.GetButtonDown("Fire1");
    }
}