using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class MoveForward : MonoBehaviour 
{
	public float speed = 2;
	Rigidbody myRig;

	void Start()
	{
		myRig = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate()
	{
		myRig.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
	}
}
