using UnityEngine;
using System.Collections;

public class RitualAnimation : MonoBehaviour {

	public GameObject fireBallObj;
	[Space(5)]
	public GameObject lightShieldObj;
	public float shieldXDistance;


	public void FireballAnimation(Player source) 
	{
		Instantiate(fireBallObj,new Vector3(source.transform.position.x,source.transform.position.y,-5),Quaternion.identity);

	}

	public void ShieldAnimation(Player source) 
	{
		Instantiate(lightShieldObj,new Vector3(source.transform.position.x + shieldXDistance,source.transform.position.y,-5),Quaternion.identity);

	}


}
