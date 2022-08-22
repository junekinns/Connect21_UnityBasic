using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Transform followTarget;          // 카메라가 따라다닐 대상(타겟).
    public float damping = 5f;              // 이동할 때 딜레이(지연) 값.

    // Update is called once per frame
    void LateUpdate()
    {
        // Lerp(Linear Interpolation) 함수를 사용해 
        // 이동 애니메이션 처리.
        transform.position = Vector3.Lerp(transform.position, followTarget.position, damping * Time.deltaTime);
    }
}