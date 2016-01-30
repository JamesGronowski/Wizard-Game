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
		Player target = ChooseTarget(source);

		if (!target.currentEffects.Contains(Player.StatusEffect.Shield)) {
			target.addHealth(-10);
		}
		source.castingEffect = false;
	}

	public static void ShieldEffect() {
		Player source = GameController.instance.currentCaster;
		Player target = ChooseTarget(source);

		target.addStatus(Player.StatusEffect.Shield);

		source.castingEffect = false;
	}

	public static void ConfuseEffect() {
		Player source = GameController.instance.currentCaster;
		Player target = ChooseTarget(source);
		
		target.addStatus(Player.StatusEffect.Confuse);
		
		source.castingEffect = false;
	}

	static Player ChooseTarget(Player source) {
		Player target = source.getTurn().target;

		if (!source.currentEffects.Contains(Player.StatusEffect.Confuse)) {
			if (Random.value > 0.5f) {
				if(target == GameController.instance.player1) {target = GameController.instance.player2;}
				else {target = GameController.instance.player1;}
			}
		}
	}
}
