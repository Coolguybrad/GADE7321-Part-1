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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ai.GetComponent<CharacterStats>().Score == 5)
        {
            winText.color = Color.red;
            winText.text = "RED WINS";
            panel.SetActive(true);
            Time.timeScale = 0;
        }

        if (player.GetComponent<CharacterStats>().Score == 5)
        {
            winText.color = Color.blue;
            winText.text = "BLUE WINS";
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
