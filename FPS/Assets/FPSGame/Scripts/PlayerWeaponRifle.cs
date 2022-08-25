using UnityEngine;

// 플레이어가 사용할 Rifle 기관총 무기.
// PlayerWeapon 클래스를 상속.
public class PlayerWeaponRifle : PlayerWeapon
{
    // 총알 발사를 위한 변수.
    public GameObject bulletPrefab;
    public Transform muzzleTransform;

    // 발사할 때 소리 재생을 위한 변수.
    public AudioSource audioPlayer;
    public AudioClip fireSound;

    public override void Fire()
    {
        base.Fire();

        // 프리팹 게임 오브젝트 생성하기.
        // Instantiate->인스턴스화 (인스턴스-실체 생성).
        Instantiate(
            bulletPrefab,
            muzzleTransform.position,
            muzzleTransform.rotation
        );

        // 발사 소리 재생.
        audioPlayer.PlayOneShot(fireSound);
    }
}