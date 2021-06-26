using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;

	public bool isHit = false;

	public GameObject hero;
	public GameObject NextLevelImage;

	public HealthBar healthBar;

	public Collided collided;

	public AudioSource HitAudio;
    public AudioSource WinAudio;

	Animator m_Animator;

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
		m_Animator = GetComponent<Animator>();
	}


	void DestroyObject()
	{
		Destroy(hero);
		WinAudio.Play();
		NextLevelImage.SetActive(true);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		
		bool isDied = false;
		if (collided.i != 0)
		{
			isHit = true;
			m_Animator.SetBool("IsHit", isHit);
			HitAudio.Play();
		}
		Damage(collided.i * 10);
		collided.i = 0;
		if (currentHealth <= 0)
		{
			isDied = true;
			m_Animator.SetBool("HasDied", isDied);
			DestroyObject();
		}
		m_Animator.SetBool("IsHit", isHit);
	}
}
