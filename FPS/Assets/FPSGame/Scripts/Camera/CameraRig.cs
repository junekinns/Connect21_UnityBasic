using UnityEngine;

public class CameraRig : MonoBehaviour
{
    // 변수 선언.
    public Transform followTarget;      // 따라다닐 대상.
    public Transform myTransform;       // 내 트랜스폼.
    public float damping = 5f;          // 딜레이 속도.
    public float rotationDamping = 5f;  // 회전 딜레이 변수.
   
    // 상하 회전에 사용하는 변수.
    public Transform cameraTransform;       // 메인 카메라.
    public float minAngle = -30f;           // 상하 회전 최소 각도.
    public float maxAngle = 40f;            // 상하 회전 최대 각도.
    private float xRotation = 0f;           // 카메라의 X축 누적 회전을 계산하기 위한 변수.

    // Start is called before the first frame update
    void Start()
    {
        // 같은 게임 오브젝트에서 Transform 컴포넌트 검색해서 설정.
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 애니메이션 적용한 이동 구현.
        myTransform.position = Vector3.Lerp(
            myTransform.position,
            followTarget.position,
            damping * Time.deltaTime
        );

        // 애니메이션을 적용한 회전.
        transform.rotation = Quaternion.Lerp(
            myTransform.rotation,
            followTarget.rotation,
            rotationDamping * Time.deltaTime
        );

        OnLook();
    }

    // 상하 회전을 처리하는 함수.
    void OnLook()
    {
        // 마우스 상하 드래그 값을 -1 ~ 1로 고정.
        float mouseY = Mathf.Clamp(PlayerInputManager.Look, -1f, 1f);

        // 마우스 드래그 값을 사용해 X축 누적 회전 계산.
        xRotation -= mouseY;

        // 계산한 회전 값을 최소 각도와 최대 각도 사이의 값으로 고정.
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        // 회전 설정을 위한 각도 만들기.
        // 카메라의 현재 로컬 회전 각도를 오일러 각으로 가져오기.
        Vector3 targetRotation = cameraTransform.localRotation.eulerAngles;
        
        // X축 회전을 앞서 구한 회전 값으로 설정.
        targetRotation.x = xRotation;

        // 카메라의 로컬 회전 값을 쿼터니언으로 변환해 설정.
        cameraTransform.localRotation = Quaternion.Euler(targetRotation);
    }

    // 카메라의 X축 회전 값을 반환하는 함수.
    // 애니메이션 Aiming 레이어에서 사용.
    public float GetXRotation()
    {
        return xRotation;
    }
}