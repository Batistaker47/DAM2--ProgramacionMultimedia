using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions
{
    // ESTA ES LA CONDICION QUE SE DEBE DE CUMPLIR PARA EL CAMBIO DE ESTADO
    public bool value;

    // M�TODO PARA COMPROBAR EL VALOR DEL VALUE (TRUE O FALSE)
    public abstract bool Check(GameObject owner);
}
