using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator InvincibilityFrame()
    {
        yield return new WaitForSeconds(2);
        isInvincible = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isInvincible)
            {
                isInvincible = true;
                GameManager.instance.DecreaseHealth(1);
                StartCoroutine(InvincibilityFrame());
            }
        }
    }
}
