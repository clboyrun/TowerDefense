using UnityEngine;
using System.Collections;

public class TurretSystem_ParticleTurret : MonoBehaviour
{
	//all this will be assigned automatically if the particle is automatically added
	public string enemyTag;
	public string secondaryEnemyTag;
	public bool shootSecondaryToo;
	public float damageAmount;

	public void TriggerDamage(GameObject hitGO, float damageAmount)
	{
		hitGO.GetComponent<TurretSystem_Health>().TakeDamage(damageAmount);
	}

	void OnParticleCollision(GameObject other)
	{
		GameObject hitGO = other.transform.root.gameObject;
		if(hitGO.tag == enemyTag)
		{
			TriggerDamage(hitGO, damageAmount);
		}
		if(hitGO.tag == secondaryEnemyTag && shootSecondaryToo)
		{
			TriggerDamage(hitGO, damageAmount);
		}
	}
}
