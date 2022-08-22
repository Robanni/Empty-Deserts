using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombat
{
    public void TakeDamage(int damage);
    public void Attack();
}
