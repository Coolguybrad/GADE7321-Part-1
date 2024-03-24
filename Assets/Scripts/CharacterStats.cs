using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private bool holdingFlag = false;
    [SerializeField] private int score = 0;
    [SerializeField] private Transform respawn;
    [SerializeField] private GameObject designatedFlag;

    [SerializeField] private ParticleSystem particles;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ai;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Respawn(player);
        }
    }

    public void Respawn(GameObject respawnee)
    {
        Debug.Log("respawn");

        if (respawnee.gameObject.GetComponent<CharacterStats>().holdingFlag)
        {

            //respawnee.gameObject.GetComponent<CharacterStats>().holdingFlag = false;
            respawnee.gameObject.GetComponent<CharacterStats>().designatedFlag.transform.position = new Vector3(respawnee.transform.position.x, respawnee.transform.position.y - 0.7f, respawnee.transform.position.z);

        }
        ParticleSystem particleSystem = Instantiate(particles, respawnee.transform.position, Quaternion.identity);
        particleSystem.Play();
        Destroy(particleSystem.gameObject, 2f);
        respawnee.gameObject.GetComponent<CharacterStats>().holdingFlag = false;
        respawnee.gameObject.transform.position = respawnee.gameObject.GetComponent<CharacterStats>().respawn.position;

    }

}
