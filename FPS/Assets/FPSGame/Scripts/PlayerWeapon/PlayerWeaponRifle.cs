using UnityEngine;
using UnityEngine.Events;

// 플레이어가 사용할 Rifle 기관총 무기.
// PlayerWeapon 클래스를 상속.
public class PlayerWeaponRifle : PlayerWeapon
{
    public GameObject bulletPrefab;
    public Transform muzzleTransform;

    public AudioSource audioPlayer;
    public AudioClip fireSound;

    public ParticleSystem cartridgeEjectEffect;
    public ParticleSystem muzzleFlashEffect;    // 화염 효과
    public CameraShake cameraShake;
    // 플레이어 데이터.
    public PlayerData data;

    // 현재 남은 탄약 수.
    public int currentAmmo = 0;

    // 탄약 발사 간격 조정을 위한 변수.
    public float fireRate = 0.5f;       // 발사 간격(초 단위).
    private float nextFireTime = 0f;    // 다음 발사 시간 계산을 위한 변수.

    // 재장전시 사용할 사운드관련 변수.
    public AudioClip reloadWeaponClip;

    // 애니메이션 컨트롤러.
    public PlayerAnimationController animationController;

    // 재장전을 알리기 위한 이벤트.
    public UnityEvent onReloadEvent;
    
    // 탄약 수가 변경되면 발생시킬 이벤트.
    // 앞의 int는 maxAmmo, 뒤에 int는 currentAmmo.
    public UnityEvent<int, int> OnAmmoCountChanged;

    private void Start()
    {
        // 시작할 때 플레이어 데이터에 지정한 탄약 수로 설정.
        currentAmmo = data.maxAmmo;
        OnAmmoCountChanged?.Invoke(data.maxAmmo, currentAmmo);
    }

    public override void Fire()
    {
        base.Fire();

        if (CanFire() == false){
            return;
        }

        nextFireTime = Time.time + fireRate;
        --currentAmmo;

        OnAmmoCountChanged?.Invoke(data.maxAmmo,currentAmmo);
        
        // 프리팹 게임 오브젝트 생성하기.
        // Instantiate->인스턴스화 (인스턴스-실체 생성).
        Instantiate(
            bulletPrefab,
            muzzleTransform.position,
            muzzleTransform.rotation
        );

        audioPlayer.PlayOneShot(fireSound);
        cartridgeEjectEffect.Play();
        muzzleFlashEffect.Play();
        cameraShake.Play();

        if (currentAmmo == 0){
            onReloadEvent?.Invoke();
            audioPlayer.PlayOneShot(reloadWeaponClip);
            Invoke(nameof(Reload), animationController.WaitTimeToReload());
        }
    }

    public void Reload(){
        currentAmmo = data.maxAmmo;
        OnAmmoCountChanged?.Invoke(data.maxAmmo,currentAmmo);
    }

    bool CanFire(){
        return currentAmmo > 0 && Time.time >= nextFireTime;
    }
}