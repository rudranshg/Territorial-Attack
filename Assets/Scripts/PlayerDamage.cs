using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public GameObject hero;
    public GameObject player1;
    public GameObject player2;
    public HealthBar healthBar;
    public int flag = 0;

    public Player player;
    bool m_IsPlayerAtExit;

    void OnTriggerEnter(Collider other)
    {
        m_IsPlayerAtExit = true;
        if (other.gameObject == player1)
        {
            flag = 1;
        }
        else if (other.gameObject == player2)
        {
            flag = 2;
        }
    }

    private void Update()
    {
        if (m_IsPlayerAtExit && flag!=0)
        {
            player.Damage(flag * 10);
            flag = 0;
        }
    }
}