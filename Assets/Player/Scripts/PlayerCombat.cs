using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ICombat
{
    public Button AttackButton;
    public void Attack()
    {
        Debug.Log("Entity has attacked");
    }

    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        AttackButton.ButtonClickedEvent += Attack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
