using UnityEngine;

// 플레이어에게 무기를 장착하는 기능을 담당하는 스크립트.
public class PlayerWeaponController : MonoBehaviour
{
    // 무기를 장착할 뼈대 위치(트랜스폼).
    public Transform weaponHolder;

    // 장착할 무기.
    public PlayerWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        // 무기 장착.
        weapon.LaunchWeapon(weaponHolder);
    }
}