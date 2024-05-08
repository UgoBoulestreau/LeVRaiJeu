using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    protected Weapons weapon;

    public virtual void Init(Weapons weapon)
    {
        this.weapon = weapon;
    }

    public virtual void Launch()
    {

    } 
}
