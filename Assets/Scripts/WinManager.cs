using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TMP_Text winText;
    [SerializeField] private GameObject ai;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "SCORE:\nPlayer " + player.GetComponent<CharacterStats>().Score + "\nAI " + ai.GetComponent<CharacterStats>().Score;

        if (ai.GetComponent<CharacterStats>().Score == 5)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            winText.color = Color.red;
            winText.text = "RED WINS";
            panel.SetActive(true);
            Time.timeScale = 0;
        }

        if (player.GetComponent<CharacterStats>().Score == 5)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            winText.color = Color.blue;
            winText.text = "BLUE WINS";
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
