using System.Collections.Generic;

public interface IAmAlive
{
    void TakeDamage(int d);
    bool SpendMana(int m);
    int GetHP();
    int GetMana();
}

interface IAmSpell
{
    void Cast();
    public List<int> GetPattern();
    public IAmAlive master { get; set; }
    public IAmAlive opponent { get; set; }
    int GetManaCost();

}