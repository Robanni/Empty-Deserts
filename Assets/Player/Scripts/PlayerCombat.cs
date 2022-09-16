using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ICombat
{
    private Animator _playerAnimator;

    private int _health = 1;
    private int _attackDamage = 1;
    private float _attackRadius = 1;
    

    public Transform AttackPoint;    
    public Button AttackButton;
    public LayerMask EnemyLayerMask;
    
    void Start()
    {
        AttackButton.TimerButtonClickedEvent += PlayAttackAnimation;
        _playerAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        
        Collider2D[] attackedEntities = Physics2D.OverlapCircleAll(AttackPoint.position, _attackRadius, EnemyLayerMask);

        foreach (Collider2D attackedEntity in attackedEntities)
        {
            attackedEntity.GetComponent<ICombat>().TakeDamage(_attackDamage);
        }
        
    }
    private IEnumerator  PlayAttackAnimation()
    {
        _playerAnimator.SetTrigger("IsAttacking");
        yield return new WaitForSecondsRealtime(0.18f);
        Attack();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) Destroy(gameObject);
    }

    public int Health { get { return _health; } }
}
