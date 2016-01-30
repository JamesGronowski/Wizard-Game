using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed;

	public Player playObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		gameObject.transform.position += playObj.transform.position * speed * Time.deltaTime;


		//transform.Translate(speed * Time.deltaTime,0,0);
		
	
	}
}
