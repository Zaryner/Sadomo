using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAmAlive
{
    [SerializeField] private Bar HPbar;
    [SerializeField] private Bar MPbar;

    private int maxHP = 100;
    private int hp = 100;
    private int maxMP = 20;
    private int mp = 20;

    void Start()
    {
        RecoverAllHP();
        RecoverAllMP();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TakeDamage(5);
        }
        if (Input.GetMouseButtonDown(1))
        {
            HPbar.HideBarValues();
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            HPbar.UnhideBarValues();
        }
    }

    private void RecoverAllHP()
    {
        hp = maxHP;
        HPbar.ChangeMaxValueTo(maxHP);
        HPbar.ChangeValueTo(hp);
    }
    private void RecoverAllMP()
    {
        mp = maxMP;
        MPbar.ChangeMaxValueTo(maxMP);
        MPbar.ChangeValueTo(mp);
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
