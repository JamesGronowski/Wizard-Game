using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	[HideInInspector]
	public bool castingEffect = false;
    
    public enum StatusEffect {Shield, Confuse };//fill
	public List<StatusEffect> currentEffects;
    private int health;
    private List<Rune> runeBucket;
    private Turn turn;

	void Start () {
        health = 100;
        runeBucket = new List<Rune>();
		currentEffects = new List<StatusEffect>();
		turn = new Turn();
	}

    public void addRunes()
    {
        runeBucket.AddRange(turn.runesAdded);
        turn.runesAdded.Clear();
    }

	public void addHealth(int damage) {
		health += damage;
	}

	public void addStatus(StatusEffect status) {
		currentEffects.Add(status);
	}
    
    public Turn getTurn() {
		return turn;
	}

	public void TurnCleanup() {
		turn = new Turn();
		currentEffects.Remove(StatusEffect.Confuse);
		currentEffects.Remove(StatusEffect.Shield);
	}
}
