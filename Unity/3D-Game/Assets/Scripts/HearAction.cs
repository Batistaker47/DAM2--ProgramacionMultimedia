using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearAction : Actions
{
    public float radius = 10f;
    public override bool Check(GameObject owner)
    {
        //Casteamos una esfera alrededor del dueño
        Collider[] hits = Physics.OverlapSphere(owner.transform.position, radius );

        //Recorremos todo lo que hay dentro para buscar al jugador
        foreach ( Collider hit in hits ) 
        {
            if(hit.GetComponent<PlayerMovement>())
            {
                // Estoy detectando al jugador
                return true;
            }
        }

        return false;
    }
}
