using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool playerCapable = false;
    [SerializeField] GameObject redFlag;
    [SerializeField] GameObject blueFlag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCapable && other.gameObject.GetComponent<CharacterStats>().IsPlayer && other.gameObject.GetComponent<CharacterStats>().HoldingFlag)
        {
            other.gameObject.GetComponent<CharacterStats>().Score += 1;
            other.gameObject.GetComponent<CharacterStats>().HoldingFlag = false;
            blueFlag.gameObject.transform.position = new Vector3(blueFlag.gameObject.transform.position.x, blueFlag.gameObject.transform.position.y + 1000, blueFlag.gameObject.transform.position.z);
        }

        else if (!playerCapable && !other.gameObject.GetComponent<CharacterStats>().IsPlayer && other.gameObject.GetComponent<CharacterStats>().HoldingFlag)
        {
            other.gameObject.GetComponent<CharacterStats>().Score += 1;
            other.gameObject.GetComponent<CharacterStats>().HoldingFlag = false;
            redFlag.gameObject.transform.position = new Vector3(redFlag.gameObject.transform.position.x, redFlag.gameObject.transform.position.y + 1000, redFlag.gameObject.transform.position.z);

        }

        Debug.Log("Collision");
    }
}
