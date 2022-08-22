using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        _enemyTarget = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMovement();
    }
}
