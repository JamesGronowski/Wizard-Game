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
}