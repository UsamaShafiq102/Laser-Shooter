using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScession : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    public void SetUpSingleton()
    {
        int numberGameScession = FindObjectsOfType<GameScession>().Length;
        if (numberGameScession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
