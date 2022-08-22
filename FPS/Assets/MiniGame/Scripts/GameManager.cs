using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �ʿ��� ���� ����.
    public int targetScore = 0;     // ȹ�� �ؾ��ϴ� ������ ����.
    public int score = 0;           // ���� ȹ���� ����.

    // ȭ�鿡 ǥ���� UI.
    public Text scoreUI;
    public GameObject gameClearUI;

    // �Լ� ����.
    // ������ ȹ������ �� ������ �Լ�.
    public void AddScore()
    {
        // ���� ȹ��.
        score = score + 1;

        // UI�� ���� ǥ��.
        // score.ToString()�� �����ϸ� ������ score�� �ؽ�Ʈ�� �����.
        scoreUI.text = "Score: " + score.ToString();

        // ���� ȹ���� ������ ���� Ŭ���� ���ǿ� �����ϴ��� Ȯ��.
        // score�� targetScore�� ������ ��.
        // == �� ������. ������ ���� �������� ���� ������ ��.
        // if ���ǹ�. ��ȣ �ȿ� ���� ������ �ۼ�.
        if (score == targetScore)
        {
            // ���� Ŭ����.
            Debug.Log("���� Ŭ����!!!");

            // ���� Ŭ���� �ؽ�Ʈ �ѱ�(Ȱ��ȭ).
            // SetActive �Լ��� ����ϸ� ���� ������Ʈ�� �Ѱų� �� �� �ִ�.
            gameClearUI.SetActive(true);

        }
    }
}