using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour{
    public Text ammoText;

    // 무기 아이콘 이미지.
    public Image weaponIconImage;
    
    // 재장전 이미지 애니메이션 처리를 위한 변수.
    // 재장전 애니메이션 재생 시간 확인을 위해 추가.
    public PlayerAnimationController animationController;
    
    // 현재 재장전 중인지 확인하기 위한 변수.
    public bool isReloading = false;
    
    // 누적 시간 계산을 위한 변수.
    public float elapsedTime = 0f;

    public void OnAmmoCountChanged(int maxAmmo, int currentAmmo){
        ammoText.text = $"<color=red>{currentAmmo}</color>/{maxAmmo}";
    }
    
    // 재장전이 시작되면 호출되는 함수.
    // OnReloadEvent 이벤트가 발생되면 호출됨.
    public void OnReloadStarted()
    {
        // 재장전 애니메이션을 위해 경과 시간 추적 변수 초기화.
        elapsedTime = 0f;

        // 재장전 설정.
        isReloading = true;
    }
    private void Update()
    {
        // 재장전 중인 경우, 이미지 애니메이션 재생.
        if (isReloading == true)
        {
            // 재장전이 완료되기까지 얼마나 시간이 지났는지를 퍼센티지로 계산.
            weaponIconImage.fillAmount = 
                elapsedTime / animationController.WaitTimeToReload();

            // 경과 시간 업데이트.
            elapsedTime += Time.deltaTime;

            // 재장전 완료 시간까지 지났는지 확인.
            if (elapsedTime > animationController.WaitTimeToReload())
            {
                // 이미지를 최대로 채움.
                weaponIconImage.fillAmount = 1f;

                // 재장전 완료 설정.
                isReloading = false;
            }
        }
    }
}
