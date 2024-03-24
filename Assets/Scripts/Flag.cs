using UnityEngine;

public class Flag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool playerCapable = false;
    [SerializeField] Transform flagRespawnLocation;
    public Transform FlagRespawnLocation
    {
        get { return flagRespawnLocation; }
        set { flagRespawnLocation = value; }
    }
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
            if (playerCapable && other.gameObject.GetComponent<CharacterStats>().IsPlayer)
            {
                other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1000, this.gameObject.transform.position.z);
            }

            else if (!playerCapable && !other.gameObject.GetComponent<CharacterStats>().IsPlayer)
            {
                other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1000, this.gameObject.transform.position.z);
                Debug.Log("Bot Collision");
            }
        }




        Debug.Log("Collision");
    }

}
