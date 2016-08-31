using UnityEngine;
using System.Collections;

public class SmoothRotationAndFollow : MonoBehaviour 
{
	public Transform targetToMatch;

	public float smoothFollowRate = 0.01f;
	public float smoothRotateRate = 0.01f;

	void LateUpdate()
	{
		transform.position = Vector3.Lerp(transform.position, targetToMatch.position, smoothFollowRate);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetToMatch.rotation, smoothRotateRate);
	}
}
