using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public enum ModeTypes { opponent_battle};
    public ModeTypes mode;

    private IAmAlive opponent;
    private IAmAlive player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<IAmAlive>();
        opponent = GameObject.Find("Enemy").GetComponent<IAmAlive>();
    }

    void Update()
    {
        if (player.GetHP() <= 0)
        {

        }
        if(opponent.GetHP() <= 0)
        {

        }
    }
}
