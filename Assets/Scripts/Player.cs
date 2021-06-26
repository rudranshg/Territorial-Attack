using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;

	public GameObject hero;
	public GameObject GameOverImage;

	public HealthBar healthBar;

	public Triggered trigger;

	public AudioSource HitAudio;
	public AudioSource GameOverAudio;

	public bool IsDead = false;	

	Animator m_Animator;


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
		m_Animator = GetComponent<Animator>();
	}


	void DestroyObject()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<AudioSource>().enabled = false;
		GameOverAudio.Play();
		GameOverImage.SetActive(true);
		//EndLevel();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		bool isHit = false;
        if (trigger.i !=0 && !IsDead)
        {
			isHit = true;
			m_Animator.SetBool("IsHit", isHit);
			HitAudio.Play();
			Damage(20);
			trigger.i = 0;
		}
		if (currentHealth <= 0)
		{
			IsDead = true;
			m_Animator.SetBool("HasDied", IsDead);
			DestroyObject();
		}
		m_Animator.SetBool("IsHit", isHit);
	}
}
