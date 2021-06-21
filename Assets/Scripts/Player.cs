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
	}


	void DestroyObject()
	{
		Destroy(gameObject);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        if (trigger.i !=0)
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
}
