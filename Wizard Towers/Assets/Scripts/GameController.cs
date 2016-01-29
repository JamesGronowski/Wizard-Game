using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private Phase currentPhase;
    public enum Phase {Results, Player1, Player2};
    private enum GodFavour{Fire, Air, Earth, Water};
    private Dictionary<GodFavour, float> favourLevels;


    // Use this for initialization
    void Start()
    {
        currentPhase = Phase.Player1;
        TriggerPhaseObjects();
        favourLevels = new Dictionary<GodFavour, float>();
        foreach (GodFavour g in System.Enum.GetValues(typeof(GodFavour)))
        {
            favourLevels.Add(g, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

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


        TriggerPhaseObjects();
    }

    void TriggerPhaseObjects()
    {
        PhaseButton[] phaseObjects = FindObjectsOfType(typeof(PhaseButton)) as PhaseButton[];
        foreach (PhaseButton p in phaseObjects)
        {
            p.OnPhase(currentPhase);
        }
    }

}
