using UnityEngine;
using System.Collections;

public class SteeringAttributes : MonoBehaviour {
	
	//these are common attributes required for steering calculations 
	public float maxSpeed = 150.0f;
	public float maxForce = 150.0f;
	public float maxForceP = 20.0f;
	public float mass = 1.0f;
	public float radius = 1.0f;
	
	// These weights will be exposed in the Inspector window

	public float seekWt = 20.0f;
	public float inBoundsWt = 30.0f;
	public float avoidWt = 30.0f;
	public float avoidDist = 7.0f;
	
}
