using UnityEngine;

// 플레이어가 장착하는 무기 클래스의 기본 클래스.
public class PlayerWeapon : MonoBehaviour
{
    // 부모 트랜스폼(WeaponHolder)로 부터 설정할 오프셋 변수.
    public Vector3 positionOffset;          // 위치 오프셋.
    public Vector3 rotationOffset;          // 회전 오프셋.

    protected Transform myTransform;        // 내 트랜스폼 컴포넌트 변수.

    private void Awake()
    {
        // myTransform 컴포넌트가 설정되지 않았으면,
        // 검색해서 설정.
        if (myTransform == null)
        {
            myTransform = GetComponent<Transform>();
        }
    }

    // WeaponHolder에 무기를 장착하는 함수.
    public void LaunchWeapon(Transform weaponHolder)
    {
        // WeaponHolder 트랜스폼을 부모 트랜스폼으로 설정해,
        // 계층 구조를 적용함.
        myTransform.SetParent(weaponHolder);

        // 위치/회전/스케일 조정.
        myTransform.localPosition = Vector3.zero + positionOffset;
        myTransform.localRotation = Quaternion.identity * Quaternion.Euler(rotationOffset);
        myTransform.localScale = Vector3.one;
    }
}