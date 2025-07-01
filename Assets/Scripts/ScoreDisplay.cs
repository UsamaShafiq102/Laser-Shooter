using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameScession gameScession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameScession = FindObjectOfType<GameScession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameScession.GetScore().ToString();
    }
}
