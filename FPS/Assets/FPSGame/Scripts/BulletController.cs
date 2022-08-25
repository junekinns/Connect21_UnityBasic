using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 충돌한 지점에 보여줄 데칼(Decal) 효과.
    public GameObject collisionDecal;

    // 충돌했을 때 유니티 엔진이 실행해주는 함수.
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 지점에 대한 정보 가져오기.
        ContactPoint contact = collision.contacts[0];

        // 데칼의 회전 설정.
        // 데칼의 회전 방향을 충돌 지점의 노멀(법선) 방향으로 구한다.
        Quaternion rotation = Quaternion.LookRotation(contact.normal);

        // 프리팹 생성.
        Instantiate(collisionDecal, contact.point, rotation);

        // 총알 물체 삭제.
        Destroy(gameObject);
    }
}