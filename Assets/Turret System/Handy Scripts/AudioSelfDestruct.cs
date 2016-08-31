using UnityEngine;
using System.Collections;

public class AudioSelfDestruct : MonoBehaviour 
{
	void Update()
	{
		if(!GetComponent<AudioSource>().isPlaying)
			Destroy(gameObject);
	}
}
