using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapons : MonoBehaviour
{

    // Start is called before the first frame update

    public float shootingForce;
    public Transform bulletSpawn;
    public float recoilForce;
    public float damage;
    private Rigidbody rigidbody;

    private XRGrabInteractable interactableWeapon;
    void Awake()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.selectEntered.AddListener(PickUpWeapon);
        interactableWeapon.selectExited.AddListener(DropWeapon);
        interactableWeapon.activated.AddListener(StartShooting);
        interactableWeapon.deactivated.AddListener(StopShooting);
    }

    protected virtual void StopShooting(DeactivateEventArgs arg0)
    {
    }

    protected virtual void StartShooting(ActivateEventArgs arg0)
    {
    }

    protected virtual void DropWeapon(SelectExitEventArgs arg0)
    {
    }

    protected virtual void PickUpWeapon(SelectEnterEventArgs arg0)
    {
    }

    protected virtual void Shoot()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
