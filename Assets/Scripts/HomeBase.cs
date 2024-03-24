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
        if (other.tag == "Player" || other.tag == "AI")
        {
            if (playerCapable && other.gameObject.GetComponent<CharacterStats>().IsPlayer && other.gameObject.GetComponent<CharacterStats>().HoldingFlag)
            {
                other.gameObject.GetComponent<CharacterStats>().Score += 1;
                other.gameObject.GetComponent<CharacterStats>().HoldingFlag = false;
                blueFlag.gameObject.transform.position = blueFlag.gameObject.GetComponent<Flag>().FlagRespawnLocation.position;
            }

            else if (!playerCapable && !other.gameObject.GetComponent<CharacterStats>().IsPlayer && other.gameObject.GetComponent<CharacterStats>().HoldingFlag)
            {
                other.gameObject.GetComponent<CharacterStats>().Score += 1;
                other.gameObject.GetComponent<CharacterStats>().HoldingFlag = false;
                redFlag.gameObject.transform.position = redFlag.gameObject.GetComponent<Flag>().FlagRespawnLocation.position;

            }
            Debug.Log("Collision");
        }




    }
}
