using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public State nextState;
    public Actions action;


    // METODO QUE TE DEVUELVE SI LA ACCION SE HA CUMPLIDO.
    private bool CheckAction(GameObject owner) 
    {
        return action.Check(owner) == action.value;
    }

    // EL VIRTUAL PERMITE PODER SOBREESCRIBIR LA FUNCIÓN EN LAS CLASES HIJAS, Y TAMBIÉN IMPLEMENTARLO
    public virtual State Run(GameObject owner) 
    { 
        if(CheckAction(owner)) 
        {
            return nextState;
        }
        
        return this;    
    }

}
