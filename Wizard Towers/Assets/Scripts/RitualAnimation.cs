using UnityEngine;
using System.Collections;

public class RitualAnimation : MonoBehaviour {

	public GameObject fireBallObj;
	public float speed;


	[Space(5)]
	public GameObject testPlayer;

	public void FireballAnimation(Player source) 
	{
		
		
		//Instantiate(fireBallObj,testPlayer.transform.position,Quaternion.identity);

		//Animate caster
		//Create fireball
		//source.transform.position
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			Instantiate(fireBallObj,new Vector3(fireBallObj.transform.position.x,fireBallObj.transform.position.y,-5),Quaternion.identity);
		}

	}
}
