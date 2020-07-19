using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character State Script List")]
public class CharacterStateScriptList : ScriptableObject
{
    [SerializeField] string fallScript = "CharacterStateFall";
    [SerializeField] string landScript = "CharacterStateLand";
    [SerializeField] string idleScript = "CharacterStateIdle";

    public string this[string propertyName] => GetType().GetProperty(propertyName).GetValue(this) as string;

    public string Fall => fallScript;
    public string Land => landScript;
    public string Idle => idleScript;
}
