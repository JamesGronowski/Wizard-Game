﻿using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Instantiate(

		transform.Translate(speed * Time.deltaTime,0,0);
		
	
	}
}
