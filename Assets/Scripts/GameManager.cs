using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<GameObject> cars;
	public List<GameObject> pitCrew;
	public Transform pitCar;
	private List<GameObject> wayPointsB = new List<GameObject>();
	private List<GameObject> wayPointsW = new List<GameObject>();
	
	public GameObject targ;
	public GameObject target;
	
	public GameObject TargetPrefab;
	public GameObject GuyPrefab;
	public GameObject GuyPrefab2;
	public GameObject ObstaclePrefab;

	public bool pitUsed;
	public bool raceStart;
	
	//Vector3 centroid;
	//Vector3 direction;
	
	// Use this for initialization
	void Start () {

		AudioListener.pause = true;

		Vector3 pos = new Vector3(Random.Range(-120, 120), 4f, Random.Range( -120, 120));
		
		pos = new Vector3(0, 1.0f, 0);
		
		//black waypoints
		for(int i = 1; i < 54; i++)
		{
			wayPointsB.Add (GameObject.Find("wP" + i + "B"));
		}
		//white waypoints
		for(int i = 1; i < 54; i++)
		{
			wayPointsW.Add (GameObject.Find("wP" + i + "W"));
		}

		cars = new List<GameObject>();
		pitCrew = new List<GameObject>();
		//get cars
		for(int i = 0; i < 15; i++)
		{
			cars.Add(GameObject.Find("Stockcar" + (i+1)));
		}

		for(int i = 0; i < 7; i++)
		{
			pitCrew.Add(GameObject.Find("Guy" + (i+1)));
		}

		/*
		for(int i = 0; i <30; i++)
		{
			pos = new Vector3(Random.Range(-120, 120), 4f, Random.Range( -120, 120));
			myGuys.Add((GameObject)GameObject.Instantiate(GuyPrefab, pos, Quaternion.identity));
		}
		for(int i = 0; i <30; i++)
		{
			pos = new Vector3(Random.Range(-120, 120), 4f, Random.Range( -120, 120));
			myGuys.Add((GameObject)GameObject.Instantiate(GuyPrefab2, pos, Quaternion.identity));
		}
		*/
		
		
		//make some obstacles
		/*
		for (int i=0; i<20; i++) 
		{
			pos =  new Vector3(Random.Range(-120, 120), 4f, Random.Range(-120, 120));
			Quaternion rot = Quaternion.Euler(0, Random.Range(0, 90), 0);
			GameObject o = (GameObject)GameObject.Instantiate(ObstaclePrefab, pos, rot);
			
			float scal = Random.Range(2f, 5f);
			o.transform.localScale = new Vector3(scal, scal, scal);
		}
		*/
		
		//tell camera to follow myGuy
		Camera.main.GetComponent<SmoothFollow>().target = cars[0].transform;

		pitUsed = false;
		raceStart = false;

		
	}
	
	// Update is called once per frame
	void Update () {
		//updateCentroid();
		//updateDirection();

		if(Input.GetKeyDown(KeyCode.Space))
		{
			raceStart = true;
			AudioListener.pause = false;
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Camera.main.GetComponent<SmoothFollow>().target = cars[ Random.Range(0,cars.Count)].transform;
		}
		if(Input.GetKeyDown(KeyCode.F1))
		{
			Camera.main.GetComponent<SmoothFollow>().target = cars[0].transform;
		}
		if(Input.GetKeyDown(KeyCode.F2))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[1].transform;
		}
		if(Input.GetKeyDown(KeyCode.F3))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[2].transform;
		}
		if(Input.GetKeyDown(KeyCode.F4))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[3].transform;
		}
		if(Input.GetKeyDown(KeyCode.F5))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[4].transform;
		}
		if(Input.GetKeyDown(KeyCode.F6))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[5].transform;
		}
		if(Input.GetKeyDown(KeyCode.F7))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[6].transform;
		}
		if(Input.GetKeyDown(KeyCode.F8))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[7].transform;
		}
		if(Input.GetKeyDown(KeyCode.F9))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[8].transform;
		}
		if(Input.GetKeyDown(KeyCode.F10))
		   {
			Camera.main.GetComponent<SmoothFollow>().target = cars[9].transform;
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			Camera.main.GetComponent<SmoothFollow>().target = cars[10].transform;
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			Camera.main.GetComponent<SmoothFollow>().target = cars[11].transform;
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			Camera.main.GetComponent<SmoothFollow>().target = cars[12].transform;
		}
		if(Input.GetKeyDown(KeyCode.F))
		{
			Camera.main.GetComponent<SmoothFollow>().target = cars[13].transform;
		}
		if(Input.GetKeyDown(KeyCode.G))
		{
			Camera.main.GetComponent<SmoothFollow>().target = cars[14].transform;
		}
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Camera.main.GetComponent<SmoothFollow>().target = GameObject.FindWithTag("pitCamera").transform;
		}
}

	/*
	void updateCentroid()
	{
		Vector3 sum = new Vector3(0,0,0);
		for(int i = 0; i < myGuys.Count; i++)
		{
			sum += myGuys[i].transform.position;
		}
		sum /= myGuys.Count;
		centroid = sum;
		//Debug.Log(centroid);	
	}
	
	void updateDirection()
	{
		Vector3 sum = new Vector3(0,0,0);
		for(int i = 0; i < myGuys.Count; i++)
		{
			sum += myGuys[i].transform.position;
		}
		sum /= myGuys.Count;
		sum.Normalize();
		sum *= 12;
		direction  = sum;
	}
	*/
	
	public List<GameObject> getCars()
	{
		return cars;
	}

	public List<GameObject> getCrew()
	{
		return pitCrew;
	}

	/*
	public Vector3 getCentroid()
	{
		return centroid;
	}
	
	public Vector3 getDirection()
	{
		return direction;
	}
	*/
	
	public List<GameObject> getWayPointsB()
	{
		return wayPointsB;	
	}
	public List<GameObject> getWayPointsW()
	{
		return wayPointsW;	
	}
}
