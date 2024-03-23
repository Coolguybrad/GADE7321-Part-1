using UnityEngine;
using UnityEngine.AI;

public class capFlagAI : MonoBehaviour
{
    // Start is called before the first frame update

    private State currentState;
    [SerializeField] private Transform playerFlag;

    [SerializeField] private Transform player;

    [SerializeField] private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeState(new SeekFlag(agent, playerFlag));
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

        public SeekFlag(NavMeshAgent agent, Transform target) 
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

        public ReturnFlag(NavMeshAgent agent, Transform target)
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
