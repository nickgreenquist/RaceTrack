using UnityEngine;
using System.Collections;


//Obstacle is just a GameObject that we need to avoid

public class ObstacleScript : MonoBehaviour {
	public float radius; //hard coded or set in inspector for now
	
	public void Start()
	{
		float s = transform.localScale.x/2;
		radius = Mathf.Sqrt((s*s) + (s*s)); 
		//Debug.Log("radius = " + radius);
	}
	
	public float Radius {
		get { return radius; }
	}
	
	
}

	