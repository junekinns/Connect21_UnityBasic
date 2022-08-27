using UnityEngine;

// 적 AI 캐릭터의 정찰 상태 스크립트.
public class EnemyPatrolState : EnemyState
{
    protected override void OnEnable()
    {
        base.OnEnable();

        // 다음 정찰 지점으로 이동.
        MoveToWaypoint();
    }

    protected override void Update()
    {
        base.Update();

        // 회전 업데이트.
        UpdateRotation(data.moveRotateDamping);

        // 정찰 지점에 거의 도착 했는지 확인.
        if (manager.agent.velocity.sqrMagnitude >= 0.2f * 0.2f && manager.agent.remainingDistance <= 0.5f)
        {
            // 거의 도착했으면 대기(Idle) 상태로 변경.
            manager.SetState(EnemyStateManager.State.Idle);
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    private void MoveToWaypoint()
    {
        // 이동 경로에 문제가 없는지 확인.
        if (manager.agent.isPathStale == false)
        {
            // 정찰 지점으로 사용할 인덱스를 랜덤으로 선택.
            int index = Random.Range(0, data.waypoints.Count);
            // NavMeshAgent의 목표 위치 설정.
            manager.SetAgentDestination(data.waypoints[index].position, data.patrolSpeed);
        }
    }
}