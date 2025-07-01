using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    float delayInSeconds = 1f;

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGamePlay()
    {
        SceneManager.LoadScene("Game Play");
        FindObjectOfType<GameScession>().ResetGame();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
