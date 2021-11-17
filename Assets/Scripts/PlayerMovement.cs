using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton
    public static PlayerMovement instance;
    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    NavMeshAgent navMeshAgent;
    Animator animator;

    Vector3 desiredPos;
    Waypoints waypoints;
    GameManager gameManager;

    bool isRunning = true;
    int currentWaypointIndex;

    private void Start()
    {
        gameManager = GameManager.instance;
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        waypoints = Waypoints.instance;

        desiredPos = waypoints.points[1].transform.position;
        ChangePosition(desiredPos,1);
    }

    private void Update()
    {
        if (isRunning)
        {
            CanShoot();
        }
    }

    public bool CanShoot()
    {
        float distanceToPoint = Vector3.Distance(transform.position, desiredPos);
        if (distanceToPoint < .4f)
        {
            if (waypoints.IsLastWaypoint(currentWaypointIndex))
            {
                gameManager.Restart();
            }
            isRunning = false;
            animator.SetBool("IsMoving", isRunning);
            return true;
        }
        return false;
    }

    public void ChangePosition(Vector3 _desiredPos, int wayPointIndex)
    {
        isRunning = true;
        currentWaypointIndex = wayPointIndex;
        animator.SetBool("IsMoving",isRunning);
        desiredPos = _desiredPos;
        navMeshAgent.SetDestination(_desiredPos);
        
    }
}
