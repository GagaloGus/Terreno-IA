using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateMachine : MonoBehaviour
{
    public State initialState;
    State _currentState;

    private Color GamingGizmoCol;
    // Start is called before the first frame update
    void Start()
    {
        _currentState = initialState;
        _currentState.StartState(gameObject);

        StartCoroutine(ChangeCol());
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

    private void OnDrawGizmos()
    {
        Gizmos.color = GamingGizmoCol;
        if(_currentState != null)
        {
            _currentState.DrawAllGizmos(gameObject);
        }
    }

    IEnumerator ChangeCol()
    {
        float count = 0;
        while (count < 1)
        {
            Color rainbow = Color.HSVToRGB(count, 1, 1);

            GamingGizmoCol = rainbow;
            yield return new WaitForSeconds(1 / 360);

            count += 1 / 360f;
        }
        StartCoroutine(ChangeCol());

    }

}
