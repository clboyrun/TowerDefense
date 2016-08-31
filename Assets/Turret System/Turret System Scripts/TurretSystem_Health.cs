using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretSystem_Health : MonoBehaviour 
{
	public float health = 100;
	public GameObject explossion; //assign death explosion
	public bool destroyParent; //check this if you wish to destroy the parent object of this script
	public GameObject healthBar;
	public Canvas canvas;
	public Vector3 healthBarOffset;

	private Transform target;
	private float maxHealth;
	private float healthBarMaxWidth;

	void Start()
	{
		if(healthBar)
		{
			target = transform;
			healthBar = Instantiate(healthBar, transform.position, Quaternion.identity) as GameObject;
			if(!canvas && GameObject.FindGameObjectWithTag("World Canvas"))
			{
				canvas = GameObject.FindGameObjectWithTag("World Canvas").GetComponent<Canvas>();
			}
			healthBar.transform.SetParent(canvas.transform, false);
			maxHealth = health;
			healthBarMaxWidth = healthBar.transform.localScale.x;
		}
	}

	void Update()
	{
		if(healthBar)
		{
			healthBar.transform.position = target.position + healthBarOffset;
			healthBar.transform.rotation = Camera.main.transform.rotation;
		}
	}

	public void TakeDamage(float dmg)
	{
		health-= dmg;
		if(health <= 0)
			Explode();
		if(healthBar)
			CalculatePercentage();
	}

	public virtual void Explode ()
	{
		if(explossion)
			Instantiate(explossion, transform.position, Quaternion.identity);
		if(destroyParent)
			Destroy(transform.parent.gameObject);
		else
			Destroy(gameObject);

		Destroy (healthBar);
	}

	void CalculatePercentage()
	{
		float dec = health / maxHealth; //turn to decimal
		float decPerc = dec * 100; //get percentage of max health

		float perDec = decPerc / 100; //turn to decimal
		float result = perDec * healthBarMaxWidth; //get percentage of max health bar width

		Vector3 newScale = new Vector3(result,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
		healthBar.transform.localScale = newScale;
	}

}
