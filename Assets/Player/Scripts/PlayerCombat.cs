using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ICombat
{
    private int _health = 1;
    private int _attackDamage = 1;
    private float _attackRadius = 1;
    

    public Transform AttackPoint;    
    public Button AttackButton;
    public LayerMask EnemyLayerMask;
    
    void Start()
    {
        AttackButton.ButtonClickedEvent += Attack;
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        Collider2D[] attackedEntities = Physics2D.OverlapCircleAll(AttackPoint.position, _attackRadius, EnemyLayerMask);

        foreach (Collider2D attackedEntity in attackedEntities)
        {
            attackedEntity.GetComponent<ICombat>().TakeDamage(_attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0) _health = 0;
    }

    public int Health { get { return _health; } }
}
