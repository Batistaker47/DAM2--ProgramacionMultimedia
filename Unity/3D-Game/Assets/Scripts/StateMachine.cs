using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State intialState;
    private State _currentState;

    void Start()
    {
        // Punto de entrada de la máquina de estado
        _currentState = intialState;
    }

    void Update()
    {
        State nState = _currentState.Run(gameObject);

        if(nState != _currentState) 
        {
            // Significa que la accion se ha cumplido y se cambia el estado
            _currentState = nState;
        }
    }
}
