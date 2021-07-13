using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public int secondsLeft = 10;
    public int counter = 0;
    public int number;

    public bool takingAway = false;

    public GameObject Stationary;
    public GameObject Enemy;
    public GameObject text;
    public GameObject Counter;

    void Start()
    {
        text.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            text.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            text.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
        if (secondsLeft <= 0) CloneEnemy(); 
    }

    public void CloneEnemy()
    {
        if (counter > number)
        {
            Counter.SetActive(false);
            return;
        }            
        GameObject Stoneclone = Instantiate(Enemy, Stationary.transform.position, Stationary.transform.rotation);
        secondsLeft = 10;
        counter++;
    }

}
