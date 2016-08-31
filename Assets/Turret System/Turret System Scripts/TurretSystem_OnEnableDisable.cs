using UnityEngine;
using System.Collections;

public class TurretSystem_OnEnableDisable : MonoBehaviour 
{
	//for the sake of optimization set this in the inspector
	[Tooltip("Particle to be played on enable. Such as muzzle flash. If not assigned it will automatically be assigned. For the sake of optimization set this in the inspector.")]
	public ParticleSystem m_particle;
	[Tooltip("Audio to be played on enable. Such as gun shot. If not assigned it will automatically be assigned. For the sake of optimization set this in the inspector.")]
	public AudioSource m_audio;
	[Tooltip("For pooling set this to something other than 0. It will disable the gameobject when it hits 0.")]
	public float disableTimer = 0f;

	private float disableTimerKeeper;

	void Awake()
	{
		disableTimerKeeper = disableTimer;
		//if its not set, the script will try assigning it automatically on awake
		if(!m_particle && GetComponent<ParticleSystem>())
			m_particle = GetComponent<ParticleSystem>();
		if(!m_audio && GetComponent<AudioSource>())
			m_audio = GetComponent<AudioSource>();
	}

	void Update()
	{
		if(disableTimer < 0)
		{
			gameObject.SetActive(false);
			disableTimer = disableTimerKeeper;
		}

		if(disableTimer != 0)
			disableTimer-=1 * Time.deltaTime;
	}

	void OnEnable()
	{
		if(m_audio)
			m_audio.Play();
		if(m_particle)
			m_particle.enableEmission = true;
	}

	void OnDisable()
	{
		if(m_audio)
			m_audio.Stop();
		if(m_particle)
			m_particle.enableEmission = false;
	}
}
