using UnityEngine;

public class CameraRig : MonoBehaviour
{
    // 변수 선언.
    public Transform followTarget;      // 따라다닐 대상.
    public Transform myTransform;       // 내 트랜스폼.
    public float damping = 5f;          // 딜레이 속도.
    public float rotationDamping = 5f;  // 회전 딜레이 변수.

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
    }
}