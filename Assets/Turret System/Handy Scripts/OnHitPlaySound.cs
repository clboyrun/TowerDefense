using UnityEngine;
using System.Collections;

public class OnHitPlaySound : MonoBehaviour 
{
	public AudioSource sound;
	public string myTag;

	public bool onCollision = true;
	public bool onTrigger = true;
	public bool onParticle = true;

	void Start () 
	{
		if(!sound)
			sound = GetComponent<AudioSource>();
	}
	
	void OnHitColl(Collision coll)
	{
		if(myTag != "")
		{
			if(myTag == coll.gameObject.tag)
				sound.Play();
		}
		else
		{
			sound.Play();
		}
	}
	void OnHitTrig(Collider coll)
	{
		if(myTag != "")
		{
			if(myTag == coll.gameObject.tag)
				sound.Play();
		}
		else
		{
			sound.Play();
		}
	}

	void OnHitParticle(GameObject gO)
	{
		if(myTag != "")
		{
			if(myTag == gameObject.tag)
				sound.Play();
		}
		else
		{
			sound.Play();
		}
	}

	void OnColliderEnter(Collision coll)
	{
		if(onCollision)
			OnHitColl(coll);
	}

	void OnTriggerEnter(Collider trig)
	{
		if(onTrigger)
			OnHitTrig(trig);
	}
	

	void OnParticleCollision(GameObject gO)
	{
		if(onParticle)
			OnHitParticle(gO);
	}
}
