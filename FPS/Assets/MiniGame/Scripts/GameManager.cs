using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 필요한 변수 선언.
    public int targetScore = 0;     // 획득 해야하는 아이템 개수.
    public int score = 0;           // 현재 획득한 점수.

    // 화면에 표시할 UI.
    public Text scoreUI;
    public GameObject gameClearUI;

    // 함수 선언.
    // 점수를 획득했을 때 실행할 함수.
    public void AddScore()
    {
        // 점수 획득.
        score = score + 1;

        // UI에 점수 표시.
        // score.ToString()을 실행하면 숫자인 score가 텍스트로 변경됨.
        scoreUI.text = "Score: " + score.ToString();

        // 현재 획득한 점수가 게임 클리어 조건에 부합하는지 확인.
        // score가 targetScore와 같은지 비교.
        // == 비교 연산자. 왼쪽의 값과 오른쪽의 값이 같은지 비교.
        // if 조건문. 괄호 안에 비교할 조건을 작성.
        if (score == targetScore)
        {
            // 게임 클리어.
            Debug.Log("게임 클리어!!!");

            // 게임 클리어 텍스트 켜기(활성화).
            // SetActive 함수를 사용하면 게임 오브젝트를 켜거나 끌 수 있다.
            gameClearUI.SetActive(true);

        }
    }
}