using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float maxHealth = 100f;
	public float currentHealth;
	public GameObject enemy;

	public HealthBar healthBar;

	public Collided collided;

	public AudioSource HitAudio;
	public GameObject NextLevelImage;
	public AudioSource WinAudio;

	public void Damage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	public void HealthBooster()
	{
		healthBar.SetHealth(maxHealth);
		healthBar.slider.value = 100f;
	}

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		NextLevelImage.SetActive(false);
	}


	void DestroyObject()
	{
		Destroy(enemy);
		WinAudio.Play();
		NextLevelImage.SetActive(true);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(collided.i !=0) HitAudio.Play();
		Damage(collided.i * 10);
		collided.i = 0;
		if (currentHealth <= 0)
		{
			DestroyObject();
		}
	}
}
