using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;

	public GameObject Hit;
	public GameObject slider;
	public GameObject shoot;

	public int enemyCount = 0;

	public GameObject hero;
	public GameObject GameOverImage;
	public GameObject NextLevelImage;
	public Enemy enemy;

	public HealthBar healthBar;

	public Triggered trigger;

	public CountdownTimer timer;

	public GameObject healthPotion;

	public GameObject Pause;

	public AudioSource HitAudio;
	public AudioSource GameOverAudio;
	public Collided collided;
	public int Hits;
	public TextMeshProUGUI Number;
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
		healthPotion.SetActive(false);
		healthPotion.SetActive(true);

		healthBar.SetHealth(currentHealth);
	}

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		GameOverImage.SetActive(false);
		NextLevelImage.SetActive(false);
		m_Animator = GetComponent<Animator>();
	}

	void DestroyEnemy()
	{
		Hit.SetActive(false);
		slider.SetActive(false);
		shoot.SetActive(false);
		Pause.SetActive(false);
		NextLevelImage.SetActive(true);
	}

	public void DestroyObject()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<AudioSource>().enabled = false;
		GameOverAudio.Play();
		Hit.SetActive(false);
		slider.SetActive(false);
		shoot.SetActive(false);
		Pause.SetActive(false);
		GameOverImage.SetActive(true);
		//EndLevel();
	}

	void HitCounter(){
		//TextMeshPro Number = GetComponent<TextMeshPro>();
		Number.text = Hits.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{	Hits = collided.HitCount;
		HitCounter();
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
		for(int i=0;i<timer.number;i++)
        {
			if (timer.clonedEnemy[i].GetComponent<Enemy>().isDied)
			{
				for ( i = 0; i < timer.number; i++)
                {
					timer.clonedEnemy[i].GetComponent<Enemy>().isDied = false;
				}
				enemy.isDied = false;
					enemyCount += 1;
			}
        }
		if (enemy.isDied)
        {
			enemy.isDied = false;
			enemyCount += 1;
		}
		if (enemyCount == (timer.number + 1)) DestroyEnemy();

		m_Animator.SetBool("IsHit", isHit);
	}
}
