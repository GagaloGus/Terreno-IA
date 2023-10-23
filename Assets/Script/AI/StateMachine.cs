using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateMachine : MonoBehaviour
{
    public State initialState;
    private State _currentState;
    // Start is called before the first frame update
    void Start()
    {
        _currentState = initialState;
        _currentState.StartState(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        State nextState = _currentState.Run(gameObject);

        if(nextState != null)
        {
            ChangeState(nextState);
        }
    }

    void ChangeState(State nextState)
    {
        _currentState = nextState;
        _currentState.StartState(gameObject);
    }
}
