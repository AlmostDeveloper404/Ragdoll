using UnityEngine;
using UnityEngine.AI;
using Vadim;
public class PlayerMovement : Singleton<PlayerMovement>
{
    
    
    NavMeshAgent navMeshAgent;
    Animator animator;

    Vector3 desiredPos;

    bool isRunning = true;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        desiredPos = Waypoints.Instance.points[1].transform.position;
        ChangePosition(desiredPos);
    }

    private void Update()
    {
        if (isRunning)
        {
            CheckReachedTarget();
        }
    }

    public void CheckReachedTarget()
    {
        float distanceToPoint = Vector3.Distance(transform.position, desiredPos);
        if (distanceToPoint < .4f)
        {
            Waypoints.Instance.OnReachedTarget();
            
            isRunning = false;
            animator.SetBool("IsMoving", isRunning);
        }
    }

    public void ChangePosition(Vector3 _desiredPos)
    {
        isRunning = true;
        animator.SetBool("IsMoving",isRunning);
        desiredPos = _desiredPos;
        navMeshAgent.SetDestination(_desiredPos);
        
    }
}
