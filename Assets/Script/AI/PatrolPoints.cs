using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    [SerializeField]
    public List<Vector3> patrolPoints = new();
    public int originalPatrolCount, maxNextPatrolPointRange;
    private void Start()
    {
        while (patrolPoints.Count > originalPatrolCount)
        {
            patrolPoints.RemoveAt(patrolPoints.Count - 1);
        }

        originalPatrolCount--;
    }

    //Permite que si el punto a añadir esta en un rango especifico entre sus puntos de patrulla se añada a la lista
    public void AddPatrolPoint(Vector3 newPoint)
    {
        if (CheckIfPointIsInRange(newPoint))
        {
            patrolPoints.Add(newPoint);
        }
    }

    bool CheckIfPointIsInRange(Vector3 newPoint)
    {
        for (int i = 0; i < patrolPoints.Count; i++)
        {
            if (Vector3.Distance(patrolPoints[i], newPoint) <= maxNextPatrolPointRange)
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        for(int i = 0;i < patrolPoints.Count; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(patrolPoints[i], maxNextPatrolPointRange);
        }
    }
}
