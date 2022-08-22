using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, ICombat
{
    protected Transform _enemyTarget;
    protected int _health = 1;
    [SerializeField]protected float _speed = 10f;
    protected float _attackRadius = 2;
    protected int _attackDamage = 1;

    public Transform AttackPoint;
    public LayerMask PlayerLayerMask;

    private void Update()
    {
        if ((_enemyTarget.position - transform.position).magnitude < _attackRadius) Attack();//ищет модуль расстояния до игрока 
    }

    public void Attack()
    {
        Collider2D[] attackedEntities = Physics2D.OverlapCircleAll(AttackPoint.position, _attackRadius, PlayerLayerMask);

        foreach (Collider2D attackedEntity in attackedEntities)
        {
            attackedEntity.GetComponent<ICombat>().TakeDamage(_attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0) Destroy(gameObject);
    }

    protected void EnemyMovement()
    {
        Vector2 targetDiraction = (_enemyTarget.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = targetDiraction * _speed * Time.deltaTime;
    }
}
