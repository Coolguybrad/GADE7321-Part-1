using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private bool holdingFlag = false;
    [SerializeField] private int score = 0;
    public bool HoldingFlag 
    {
        get { return holdingFlag; }
        set { holdingFlag = value; }
    }
    public bool IsPlayer
    {
        get { return isPlayer; }
        set { isPlayer = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
