using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Text playerHealth;
    Player playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Text>();
        playerData = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = playerData.GetPlayerHealth().ToString();
    }
}
