using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{
    
    void Start()
    {
        _enemyTarget = FindObjectOfType<PlayerController>().transform;
        _enemyRB = GetComponent<Rigidbody2D>();
        StartCoroutine(AttackReload());
    }
    
    void FixedUpdate()
    {
        EnemyMovement();
    }
}
