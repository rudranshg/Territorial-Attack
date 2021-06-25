using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
	public Collided collided;
	public int Hits;
	public TextMeshProUGUI Number;

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
		
	}
	
	void HitCounter(){
		//TextMeshPro Number = GetComponent<TextMeshPro>();
		Number.text = Hits.ToString();
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
		
		Hits = collided.HitCount;
		HitCounter();
		

	}	
}
