using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAmAlive
{
    [SerializeField] private Bar HPbar;

    private int maxHP = 100;
    private int hp = 100;

    void Start()
    {
        RecoverAllHP();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TakeDamage(5);
        }
    }

    private void RecoverAllHP()
    {
        hp = maxHP;
        HPbar.ChangeMaxValueTo(maxHP);
        HPbar.ChangeValueTo(hp);
    }

    public void TakeDamage(int d)
    {
        hp -= d;
        if (hp <= 0)
        {
            hp = 0;

        }
        HPbar.ChangeValueTo(hp);
    }
}
