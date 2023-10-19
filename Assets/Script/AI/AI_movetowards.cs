using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_movetowards : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agentComp;

    private void Awake()
    {
        agentComp = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        agentComp.destination = target.transform.position;
        
    }
}
