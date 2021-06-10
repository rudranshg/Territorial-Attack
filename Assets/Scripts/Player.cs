using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public GameObject hero;

	public HealthBar healthBar;

	public void Damage(int damage)
	{
		currentHealth -= damage;

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
		Destroy(hero);
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Damage(10);
		}
		else if (Input.GetButtonDown("Fire2"))
        {
			Damage(20);
        }
        if (currentHealth == 0)
        {
			DestroyObject();
			Application.Quit();
        }
	}
}
