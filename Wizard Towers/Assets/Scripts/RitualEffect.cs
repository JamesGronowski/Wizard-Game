using UnityEngine;
using System.Collections;

public class RitualEffect : MonoBehaviour {

	public static RitualEffect instance;

	void Start()
	{
		if (instance == null) {
			instance = new RitualEffect();
		} else {
			Destroy(this);
		}
	}
	
	public RitualEffect() {
	}

	public static void FireballEffect() {
		Player source = GameController.instance.currentCaster;
		source.getTurn().target.addHealth(-10);
		source.castingEffect = false;
	}
}
