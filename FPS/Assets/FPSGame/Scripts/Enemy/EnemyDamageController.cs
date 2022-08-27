using UnityEngine;
using UnityEngine.Events;

// 적 캐릭터의 대미지 처리를 담당하는 스크립트.
public class EnemyDamageController : MonoBehaviour
{
    // 총을 맞았을 때 재생할 피격 효과.
    public GameObject bloodEffect;

    // 적 캐릭터 데이터.
    // 체력(HP) 관련 데이터를 사용하기 위해 참조함.
    public EnemyData data;

    // 적 캐릭터가 죽을 때 발생시킬 이벤트.
    public UnityEvent OnEnemyDeadEvent;

    // 충돌했을 때 캐릭터 총알인지 확인하기 위한 태그.
    private const string bulletTag = "Bullet";

    // 기본 체력(HP).
    private float hp = 0f;

    private void OnEnable()
    {
        // 시작할 때 데이터에 기록된 최대 체력으로 설정.
        hp = data.maxHP;
    }

    // 다른 물체와 충돌할 때 발생하는 이벤트.
    // 유니티 엔진이 실행해준다.
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 게임 오브젝트의 태그확인.
        // 플레이어가 발사한 총알과 충돌했는지 확인.
        // 캐릭터 총알에 맞은 경우 실행.
        if (collision.collider.CompareTag(bulletTag) == true)
        {
            // 피격 효과 재생.
            ShowBloodEffect(collision);

            // 플레이어 총알은 제거.
            Destroy(collision.gameObject);

            // 총알이 가진 공격력(대미지) 만큼 체력 낮추기.
            hp -= collision.gameObject.GetComponent<BulletDamage>().damage;

            // 체력을 모두 소진했으면 적 캐릭터가 죽었다는 이벤트 발생시킴.
            if (hp <= 0f)
            {
                OnEnemyDeadEvent?.Invoke();
            }
        }
    }

    // 총알에 맞았을 때 피격효과 재생하는 함수.
    private void ShowBloodEffect(Collision collision)
    {
        // 총알 맞은 지점 구하기.
        Vector3 position = collision.contacts[0].point;

        // 맞은 지점의 노멀(법선) 구하기.
        Vector3 normal = collision.contacts[0].normal;

        // 피격 효과를 총알 맞은 방향으로 설정하기 위한 회전 값 구하기.
        //Quaternion rotation = Quaternion.FromToRotation(-Vector3.forward, normal);
        Quaternion rotation = Quaternion.LookRotation(normal);

        // 피격 효과 프리팹 생성.
        GameObject blood = Instantiate(bloodEffect, position, rotation);

        // 1초 뒤에 생성한 효과 제거.
        Destroy(blood, 1f);
    }
}