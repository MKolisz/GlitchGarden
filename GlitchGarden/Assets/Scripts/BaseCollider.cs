using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();
        if(attacker)
        {
            FindObjectOfType<PlayerHealth>().DealDamage(attacker.GetDamageToPlayer());
            Destroy(attacker.gameObject, 2f);
        }
    }

}
