using UnityEngine;
using UnityEngine.AI;

public class capFlagAI : MonoBehaviour
{
    // Start is called before the first frame update

    private State currentState;
    [SerializeField] private Transform redFlag;

    [SerializeField] private Transform blueFlag;

    [SerializeField] private Transform blueFlagSpawn;

    [SerializeField] private Transform player;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform homebase;

    public NavMeshAgent Agent
    {
        get { return agent; }
        set { agent = value; }
    }

    




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeState(new SeekFlag(agent, redFlag));
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.Run();
        }


    }

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    public interface State
    {
        void Enter();
        void Run();
        void Exit();

    }

    public class SeekFlag : State
    {

        private NavMeshAgent agent;
        private Transform target;
        private GameObject ai;
        private Vector3 randOffset;



        public SeekFlag(NavMeshAgent agent, Transform target)
        {
            this.agent = agent;
            this.target = target;
            randOffset = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));

        }

        public void Enter()
        {

            agent.SetDestination(target.position + randOffset);
        }
        public void Run()
        {
            capFlagAI parentAI = agent.gameObject.GetComponent<capFlagAI>();
            ai = agent.gameObject;
            //agent.SetDestination(target.position + randOffset);
            if (parentAI.blueFlag.position == parentAI.blueFlagSpawn.position || parentAI.blueFlag.position == new Vector3(parentAI.blueFlag.position.x, parentAI.blueFlag.position.y - 1000, parentAI.blueFlag.position.z))
            {
                agent.SetDestination(target.position + randOffset);
            }
            else if (parentAI.blueFlag.position != parentAI.blueFlagSpawn.position || parentAI.blueFlag.position != new Vector3(parentAI.blueFlag.position.x, parentAI.blueFlag.position.y - 1000, parentAI.blueFlag.position.z))
            {
                agent.SetDestination(parentAI.blueFlag.position);
            }
            else if (Vector3.Distance(agent.transform.position, target.position) > 25)
            {
                agent.SetDestination(target.position + randOffset);
            }

            if (Vector3.Distance(agent.transform.position, target.position) <= 25)
            {
                agent.SetDestination(target.position);
            }


            if (ai.GetComponent<CharacterStats>().HoldingFlag)
            {
                parentAI.ChangeState(new ReturnFlag(agent, parentAI.homebase));
            }

            if (parentAI.player.gameObject.GetComponent<CharacterStats>().HoldingFlag && ai.GetComponent<CharacterStats>().Score < parentAI.player.gameObject.GetComponent<CharacterStats>().Score)
            {
                parentAI.ChangeState(new Aggressive(agent, parentAI.player));
            }
            //else if (!parentAI.player.gameObject.GetComponent<CharacterStats>().HoldingFlag && ai.GetComponent<CharacterStats>().HoldingFlag)
            //{
            //    parentAI.ChangeState(new ReturnFlag(agent, parentAI.homebase));
            //}

            Debug.Log(parentAI.currentState);
        }
        public void Exit()
        {
            agent.ResetPath();
        }

    }

    public class Aggressive : State
    {

        private NavMeshAgent agent;
        private Transform target;
        private GameObject ai;

        public Aggressive(NavMeshAgent agent, Transform target)
        {
            this.agent = agent;
            this.target = target;
        }

        public void Enter()
        {
            agent.SetDestination(target.position);
        }
        public void Run()
        {
            capFlagAI parentAI = agent.gameObject.GetComponent<capFlagAI>();
            ai = agent.gameObject;
            agent.SetDestination(target.position);
            if (!parentAI.player.gameObject.GetComponent<CharacterStats>().HoldingFlag)
            {
                parentAI.ChangeState(new SeekFlag(agent, parentAI.redFlag));
            }
            //else if (!parentAI.player.gameObject.GetComponent<CharacterStats>().HoldingFlag && ai.GetComponent<CharacterStats>().HoldingFlag)
            //{
            //    parentAI.ChangeState(new SeekFlag(agent, parentAI.homebase));
            //}
            Debug.Log(parentAI.currentState);
        }
        public void Exit()
        {
            agent.ResetPath();
        }

    }
    public class ReturnFlag : State
    {

        private NavMeshAgent agent;
        private Transform target;
        private GameObject ai;

        public ReturnFlag(NavMeshAgent agent, Transform target)
        {
            this.agent = agent;
            this.target = target;
        }

        public void Enter()
        {
            Vector3 randOffset = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
            agent.SetDestination(target.position + randOffset);
        }
        public void Run()
        {
            capFlagAI parentAI = agent.gameObject.GetComponent<capFlagAI>();
            ai = agent.gameObject;



            if (Vector3.Distance(agent.transform.position, target.position) < 25)
            {
                agent.SetDestination(target.position);
            }

            if (!ai.GetComponent<CharacterStats>().HoldingFlag)
            {
                parentAI.ChangeState(new SeekFlag(agent, parentAI.redFlag));
            }

            Debug.Log(parentAI.currentState);
        }
        public void Exit()
        {
            agent.ResetPath();
        }

    }

    public class CaptureFlag : State
    {

        private NavMeshAgent agent;
        private Transform target;
        private GameObject ai;

        public CaptureFlag(NavMeshAgent agent, Transform target)
        {
            this.agent = agent;
            this.target = target;
        }

        public void Enter()
        {
            agent.SetDestination(target.position);
        }
        public void Run()
        {
            capFlagAI parentAI = agent.gameObject.GetComponent<capFlagAI>();
            ai = agent.gameObject;
            if (Vector3.Distance(agent.transform.position, parentAI.player.position) < 15)
            {
                agent.SetDestination(parentAI.player.position);
            }
            else
            {
                agent.SetDestination(target.position);
            }
            Debug.Log(parentAI.currentState);
        }
        public void Exit()
        {
            agent.ResetPath();
        }

    }
}
