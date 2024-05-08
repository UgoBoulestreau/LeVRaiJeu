using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapons
{

    [SerializeField] private Projectiles bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void StartShooting(ActivateEventArgs intercator)
    {
        base.StartShooting(intercator);
        Shoot();
    }

    protected override void Shoot()
    {
        base.Shoot();
        Projectiles projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }

    protected override void StopShooting(DeactivateEventArgs interactor)
    {
        base.StopShooting(interactor);
    }
}
