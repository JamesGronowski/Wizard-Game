using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhaseButton : MonoBehaviour
{

    public Vector2 p1Location, p2Location;

	public void OnPhase(GameController.Phase phase)
    {
        Button button = GetComponent<Button>();
        button.interactable = (phase != GameController.Phase.Results);
    }
}
