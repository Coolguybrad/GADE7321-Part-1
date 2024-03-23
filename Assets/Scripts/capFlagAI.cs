using UnityEngine;
using UnityEngine.AI;

public class capFlagAI : MonoBehaviour
{
    // Start is called before the first frame update

    private State currentState;
    [SerializeField] private Transform redFlag;

    [SerializeField] private Transform player;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform homebase;

    

    

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
        if (currentState !=null)
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
               
        public SeekFlag(NavMeshAgent agent, Transform target) 
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

            if (Vector3.Distance(agent.transform.position, target.position) < 20)
            {
                agent.SetDestination(target.position);
            }

            if (ai.GetComponent<CharacterStats>().HoldingFlag)
            {
                parentAI.ChangeState(new ReturnFlag(agent, parentAI.homebase));
            }
        }
        public void Exit() 
        {
            agent.ResetPath();
        }

    }

    public class Agressive : State
    {

        private NavMeshAgent agent;
        private Transform target;

        public Agressive(NavMeshAgent agent, Transform target)
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



            if (Vector3.Distance(agent.transform.position, target.position) < 20)
            {
                agent.SetDestination(target.position);
            }

            if (!ai.GetComponent<CharacterStats>().HoldingFlag)
            {
                parentAI.ChangeState(new SeekFlag(agent, parentAI.redFlag));
            }
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

        }
        public void Exit()
        {
            agent.ResetPath();
        }

    }
}
