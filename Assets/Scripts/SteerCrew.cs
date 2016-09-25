using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[RequireComponent(typeof(SteeringAttributes))]
[RequireComponent(typeof(CharacterController))]

public class SteerCrew : MonoBehaviour
{
	Vector3 dv = Vector3.zero; 	// desired velocity, used in calculations
	SteeringAttributes attr; 	// attr holds several variables needed for steering calculations
	CharacterController characterController;
	BoxCollider boxC;
	private SteeringPerson vehicle;
	
	void Start ()
	{
		//attr = gameObject.GetComponent<SteeringAttributes> ();
		GameObject main = GameObject.Find ("MainGO");
		attr = main.GetComponent<SteeringAttributes>();
		characterController = gameObject.GetComponent<CharacterController> ();
		boxC = gameObject.GetComponent<BoxCollider>();
		vehicle = gameObject.GetComponent<SteeringPerson> ();
	}
	
	
	//-------- functions that return steering forces -------------//
	public Vector3 Seek (Vector3 targetPos)
	{
		//find dv, desired velocity
		dv = targetPos - transform.position;
		dv = dv.normalized * vehicle.maxSpeed; 	//scale by maxSpeed
		
		dv -= characterController.velocity;
		dv.y = 0;								// only steer in the x/z plane
		return dv;
	}
	
	public Vector3 Flee (Vector3 targetPos)
	{
		//find dv, desired velocity
		dv = transform.position - targetPos;
		//dv.x *= -1;
		//dv.z *= -1;
		dv = dv.normalized * vehicle.maxSpeed; 	//scale by maxSpeed
		dv -= characterController.velocity;
		dv.y = 0;								// only steer in the x/z plane
		
		
		
		return dv;
	}
	
	/*
	public Vector3 Allignment(Vector3 direction)
	{
		Vector3 steer = direction - characterController.velocity;
		steer.y = 0;
		return steer;
	}
	
	
	
	public Vector3 Cohesion(Vector3 centroid)
	{
		return Seek (centroid);
	}
	*/
	
	
	public Vector3 Seperation(List <GameObject> flockers)
	{
		float dist = 0;
		float minDist = 10000;
		Vector3 closest = new Vector3(0,0,0);
		int avoidNum = 0;
		
		for(int i = 0; i < flockers.Count; i++)
		{
			dist = (flockers[i].transform.position - transform.position).sqrMagnitude;
			if(dist < minDist && dist > 1)
			{
				minDist = dist;
				closest = flockers[i].transform.position;
				avoidNum = i;
			}
		}
		//Debug.Log(flockers.Count);
		if((closest - transform.position).magnitude < 5)
		{
			return Flee(closest);
		}
		return Seek(transform.position);
		
	}
	
	
	
	// tether type containment - not very good!
	public Vector3 StayInBounds (float radius, Vector3 center)
	{
		if (Vector3.Distance (transform.position, center) > radius)
			return Seek (center);
		else
			return Vector3.zero;
	}
	
	
	public Vector3 AvoidObstacle (GameObject obst, float safeDistance)
	{ 
		dv = Vector3.zero;
		float obRadius = obst.GetComponent<ObstacleScript> ().Radius;
		
		//vector from vehicle to center of obstacle
		Vector3 vecToCenter = obst.transform.position - transform.position;
		//eliminate y component so we have a 2D vector in the x, z plane
		vecToCenter.y = 0;
		float dist = vecToCenter.magnitude;
		
		// if too far to worry about, out of here
		if (dist > safeDistance + obRadius + attr.radius)
			return Vector3.zero;
		
		//if behind us, out of here
		if (Vector3.Dot (vecToCenter, transform.forward) < 0)
			return Vector3.zero;
		
		float rightDotVTC = Vector3.Dot (vecToCenter, transform.right);
		
		//if we can pass safely, out of here
		if (Mathf.Abs (rightDotVTC) > attr.radius + obRadius)
			return Vector3.zero;
		
		//obstacle on right so we steer to left
		if (rightDotVTC > 0)
			dv += transform.right * -attr.maxSpeed * safeDistance / dist;
		else
			//obstacle on left so we steer to right
			dv += transform.right * attr.maxSpeed * safeDistance / dist;
		
		return dv;	
	}
}
	
	
