﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right *speed* Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var healthComponent = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (healthComponent && attacker)
        {
            healthComponent.DealDamage(damage);
            Destroy(gameObject);
        }
    }

}
