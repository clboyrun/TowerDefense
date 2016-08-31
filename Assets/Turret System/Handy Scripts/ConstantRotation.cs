using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour 
{
	public float rotationSpeed = 100;
	public Vector3 localRotationAxis = new Vector3(0,1,0);

	void Update() 
	{
		transform.Rotate(localRotationAxis * rotationSpeed * Time.deltaTime);
	}
}
