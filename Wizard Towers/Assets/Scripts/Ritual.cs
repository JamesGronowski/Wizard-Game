using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ritual
{

    public static readonly Ritual FIREBALL = new Ritual("Fireball", 8, new Rune[] {Rune.a, Rune.f}, "FireballEffect", "FireballAnimation");

    private readonly string name;
	private readonly int priority;
    private readonly Rune[] runes;
    private readonly string effect;
	private readonly string animation;

    Ritual(string name, int priority, Rune[] runes, string effect, string animation)
    {
        this.name = name;
		this.priority = priority;
        this.runes = runes;
        this.effect = effect;
		this.animation = animation;
    }

    public static IEnumerable<Ritual> Values
    {
        get
        {
            yield return FIREBALL;
        }
    }

	public bool Castable(Rune[] bucket)
	{
		foreach (Rune r in System.Enum.GetValues(typeof(Rune)))
		{
			int min = RuneCount(runes, r);
			if (RuneCount(bucket, r) < min){
				return false;
			}
		}

		return true;
	}

	private int RuneCount(Rune[] runes, Rune rune) {
		int count = 0;
		foreach (Rune r in runes) {
			if (r == rune) {
				count++;
			}
		}

		return count;
	}
}