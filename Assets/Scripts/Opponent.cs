using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour, IAmAlive
{
    private Bar HPbar;
    private Bar MPbar;

    [SerializeField] private int maxHP = 100;
    private int hp = 100;
    [SerializeField] private int maxMP = 20;
    private int mp = 20;

    void Start()
    {
        HPbar = GameObject.Find("EnemyHP").GetComponent<Bar>();
        MPbar = GameObject.Find("EnemyMP").GetComponent<Bar>();
        RecoverAllHP();
        RecoverAllMP();
    }

    void Update()
    {

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
    public bool SpendMana(int m)
    {
        if (mp < m) return false;
        mp -= m;
        MPbar.ChangeValueTo(mp);
        return true;
    }
    public int GetMana()
    {
        return mp;
    }
    public int GetHP()
    {
        return hp;
    }
}
