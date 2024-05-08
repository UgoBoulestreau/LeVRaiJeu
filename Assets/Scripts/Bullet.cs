using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectiles
{
    private Rigidbody rigidbody;
    public float lifeTime;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public override void Init(Weapons weapon)
    {
        base.Init(weapon);
        Destroy(gameObject, lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        rigidbody.AddRelativeForce(Vector3.forward * weapon.shootingForce, ForceMode.Impulse);
    }
}
