using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, IAmSpell
{
    [SerializeField] private string name;
    [SerializeField] private int cost;
    [SerializeField] private int damage;
    [SerializeField] private int heal;
    [SerializeField] private bool splash;
    [SerializeField] private List<int> pattern;
    [SerializeField] private string animationToPlay;
    [SerializeField] int destroyItAfter;

    private Animator anim;
    private ParticleSystem particls;
    
    public IAmAlive master { get; set; }
    public IAmAlive opponent { get; set; }

    public void Cast()
    {
        anim = GetComponent<Animator>();
        particls = GetComponent<ParticleSystem>();
        particls.Play();
        anim.Play(animationToPlay);
        opponent.TakeDamage(damage);
        master.TakeDamage(-heal);
        StartCoroutine(DestroyMeAfter(destroyItAfter));
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
        particls = GetComponent<ParticleSystem>();
    }

    public List<int> GetPattern()
    {
        return pattern;
    }

    public int GetManaCost()
    {
        return cost;
    }

    IEnumerator DestroyMeAfter(float s)
    {
        yield return new WaitForSeconds(s);
        Destroy(this.gameObject);
    }
}
