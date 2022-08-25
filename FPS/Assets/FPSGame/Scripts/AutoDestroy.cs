using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // 삭제하기 까지 대기 시간(초단위).
    public float destroyTime = 3f;

    void Start()
    {
        // 물체 삭제 명령.
        Destroy(gameObject, destroyTime);
    }
}