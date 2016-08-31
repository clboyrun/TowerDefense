using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour 
{
	//pick different colors to randomize. you dont have to set the alpha value too. its maxed out in the script
	public Color[] colors;

	void Start () 
	{
		Color newColor = colors[Random.Range(0,colors.Length)]; //pick a random color
		newColor.a = 1; //set alpha to max
		if(GetComponent<ParticleSystem>()) //assign it to the particle system
			GetComponent<ParticleSystem>().startColor = newColor;
		if(GetComponent<Renderer>()) //assign it to the material
			GetComponent<Renderer>().material.SetColor("_Color", newColor);
	}

}
