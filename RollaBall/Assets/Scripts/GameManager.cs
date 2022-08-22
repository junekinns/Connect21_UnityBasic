using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int targetScore = 0;
    public int score = 0;

    public void AddScore()
    {
        score = score + 1;
        Debug.Log("Score : " + score);

        if (score == targetScore)
        {
            GameClear();
        }
    }

    private void GameClear()
    {
        Debug.Log("Game Clear!!");
    }
}