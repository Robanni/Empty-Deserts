using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, ICombat
{
    protected Transform _enemyTarget;
    protected int _health = 1;
    [SerializeField] protected float _speed = 10f;
    [SerializeField] protected float _attackRadius = 1;
    protected int _attackDamage = 1;
    protected float _attackReload = 1f;
    protected Rigidbody2D _enemyRB;

    public Transform AttackPoint;
    public LayerMask PlayerLayerMask;

    public void Attack()
    {
        if ((_enemyTarget.position - transform.position).magnitude > _attackRadius) return;//ищет модуль расстояния до игрока 

        Collider2D[] attackedEntities = Physics2D.OverlapCircleAll(AttackPoint.position, _attackRadius, PlayerLayerMask);

        foreach (Collider2D attackedEntity in attackedEntities)
        {
            attackedEntity.GetComponent<ICombat>().TakeDamage(_attackDamage);
        }
    }

    protected IEnumerator AttackReload()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(_attackReload);
        }
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0) Destroy(gameObject);
    }

    protected void EnemyMovement()
    {
        Vector2 targetDiraction =  (_enemyTarget.position - transform.position).normalized;
        _enemyRB.velocity = new Vector2( targetDiraction.x * _speed , _enemyRB.velocity.y);
    }
}
