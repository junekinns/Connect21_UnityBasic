using UnityEngine;

// 플레이어 데이터를 나타내는 ScriptableObject 스크립트
// Scriptable Object 생성을 쉽게 해주는 메뉴 설정 구문.
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/Create PlayerData")]
public class PlayerData : ScriptableObject
{
    // 플레이어 데이터.
    public float moveSpeed = 5f;            // 이동 속도.
    public float rotationSpeed = 540f;      // 회전 속도.
    public float maxHP = 100f;              // 체력(HP).
    public int maxAmmo = 20;                // 탄창에 채울 수 있는 탄약수.
}