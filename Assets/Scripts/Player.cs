using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;

	public GameObject hero;

	public HealthBar healthBar;

	public Triggered trigger;

	public AudioSource HitAudio;
	public GameObject GameOverImage;
	public bool IsDead = false;
	public AudioSource GameOverAudio;


	public void Damage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	public void HealthBoost(float healthIncrease)
    {
		currentHealth += healthIncrease;

		healthBar.SetHealth(currentHealth);
	}

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		GameOverImage.SetActive(false);
	}


	void DestroyObject()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<AudioSource>().enabled = false;
		IsDead =true;
		GameOverAudio.Play();
		GameOverImage.SetActive(true);
		//EndLevel();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        if (trigger.i !=0 && !IsDead)
        {
			HitAudio.Play();
			Damage(20);
			trigger.i = 0;
        }
		if (currentHealth <= 0)
		{
			DestroyObject();
		}
	}

	//void EndLevel(CanvasGroup GameOverImage){};
		
	
}
