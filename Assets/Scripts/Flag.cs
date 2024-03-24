using UnityEngine;

public class Flag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool playerCapable = false;
    [SerializeField] private Transform flagRespawnLocation;
    
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
            if (playerCapable)
            {
                if (other.tag == "Player")
                {
                    other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1000, this.gameObject.transform.position.z);
                }
                else if (other.tag == "AI")
                {
                    this.gameObject.transform.position = FlagRespawnLocation.position;
                }

            }

            else if (!playerCapable)
            {
                
                if (other.tag == "Player")
                {
                    this.gameObject.transform.position = FlagRespawnLocation.position;
                    
                }
                else if (other.tag == "AI")
                {
                    other.gameObject.GetComponent<CharacterStats>().HoldingFlag = true;
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1000, this.gameObject.transform.position.z);
                
                }

            }
        }




        Debug.Log("Collision");
    }

}
