using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ritual
{

    public static readonly Ritual FIREBALL = new Ritual("Fireball", new Rune[] {Rune.a, Rune.f}, "Boom");

    private readonly string name;
    private readonly Rune[] runes;
    private readonly string effect;

    Ritual(string name, Rune[] runes, string effect)
    {
        this.name = name;
        this.runes = runes;
        this.effect = effect;
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