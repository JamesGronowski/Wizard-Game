using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private Phase currentPhase;
    public enum Phase {Results, Player1, Player2};

	public Player player1, player2;
	[HideInInspector]
	public Player currentCaster;

	public static GameController instance;


    void Start()
    {
		if (instance == null) {
			instance = new GameController();
		} else {
			Destroy(this);
		}
    }

	public GameController() {
		currentPhase = Phase.Player1;
		TriggerPhaseObjects();
	}

    public void EndTurn()
    {
        
        if (currentPhase == Phase.Player2)
        {
            currentPhase = Phase.Results;
        }
        else
        {
            currentPhase++;
        }

        Debug.Log(currentPhase.ToString());
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a}));
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a, Rune.f}));
        
        TriggerPhaseObjects();

        if (currentPhase == Phase.Results) {
            RunResults();
        }
    }

    void TriggerPhaseObjects()
    {
        PhaseButton[] phaseObjects = FindObjectsOfType(typeof(PhaseButton)) as PhaseButton[];
        foreach (PhaseButton p in phaseObjects)
        {
            p.OnPhase(currentPhase);
        }
    }

    void RunResults()
    {
        Player[] players = FindObjectsOfType(typeof(Player)) as Player[];
        foreach (Player p in players)
        {
            p.addRunes();
        }

		Ritual p1Ritual = player1.getTurn().ritualCast;
		Ritual p2Ritual = player2.getTurn().ritualCast;
		if (p1Ritual != null && p2Ritual != null) {
			//P1 goes first on same-spell. Shouldn't make a difference. Can case-by-case it later.
			if (p1Ritual.GetPriority() < p2Ritual.GetPriority()) {
				currentCaster = player2;
				Cast();
				currentCaster = player1;
				Cast();
			} else {
				currentCaster = player1;
				Cast();
				currentCaster = player2;
				Cast();
			}
		} else if (p1Ritual != null) {
			currentCaster = player1;
			Cast();
		} else if (p2Ritual != null) {
			currentCaster = player2;
			Cast();
		}

		TurnCleanup();
    }

	void Cast() {
		currentCaster.castingEffect = true;
		RitualEffect.Invoke(currentCaster.getTurn().ritualCast);
		while (currentCaster.castingEffect == true) {
			yield return null;
		}
	}

	void TurnCleanup() {
		player1.TurnCleanup();
		player2.TurnCleanup();
	}

}
