using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Break : MonoBehaviour
{
    public GameObject fractured;
    public float breakForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            BreakTheThing();
        }
    }

    public void BreakTheThing()
    {
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);
        frac.transform.localScale = transform.localScale;

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }

        Destroy(gameObject);
    }
}
