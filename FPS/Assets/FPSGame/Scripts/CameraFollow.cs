using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지정한 물체(플레이어)를 일정 거리를 유지하면서 따라다니는 카메라 스크립트.
public class CameraFollow : MonoBehaviour
{
    // 변수 선언.
    public Transform followTarget;          // 카메라가 따라다닐 대상(타겟).
    public Transform myTransform;           // 내(카메라) 트랜스폼.
    public float damping = 5f;              // 이동할 때 딜레이(지연) 값.

    // 카메라와 따라다닐 대상과의 거리.
    // 처음 한번만 계산하고 계속 사용함(처음 한번만 계산).
    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        // 같은 게임 오브젝트에서 트랜스폼을 검색해서 설정하기.
        // GetComponent: 같은 게임 오브젝트에서 컴포넌트를 검색하는 기능.
        // GetComponent 뒤에 <> 괄호 안에 검색하고자 하는 타입을 전달.
        // 검색에 성공하면 해당 컴포넌트를 받을 수 있고, 실패하면 빈 값(null)이 옴.
        myTransform = GetComponent<Transform>();

        // 따라다닐 대상과의 거리 계산.
        // 내 위치에서 따라다닐 대상의 위치를 빼면 된다.
        distance = myTransform.position - followTarget.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 따라다니는 기능.
        // 플레이어의 위치에서 앞서 구한 거리만큼 떨어지도록 계산.
        myTransform.position = followTarget.position + distance;

    }
}
