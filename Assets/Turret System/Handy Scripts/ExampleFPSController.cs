using UnityEngine;
using System.Collections;

public class ExampleFPSController : MonoBehaviour 
{
	//Just a simple player controller to show the FPS capabilities of the Turret System

	public float speed = 5;
	public Transform cam;

	private float x;
	private float y;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () 
	{
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		Vector3 dir = new Vector3(x,0,y).normalized;
		Vector3 actualDir = cam.TransformDirection(dir);
		actualDir.y = 0;
		rb.AddForce(actualDir * speed * Time.deltaTime);
	}
}
