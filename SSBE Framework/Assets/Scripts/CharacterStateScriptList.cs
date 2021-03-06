﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character State Script List")]
public class CharacterStateScriptList : ScriptableObject
{
    [SerializeField] string fallScript = "CharacterStateLoopable";
    [SerializeField] string landScript = "CharacterStateEndAttack";
    [SerializeField] string idleScript = "CharacterStateLoopable";
    [SerializeField] string walkScript = "CharacterStateLoopable";
    [SerializeField] string dashScript = "CharacterStateEndAttack";
    [SerializeField] string runScript = "CharacterStateLoopable";
    [SerializeField] string skidScript = "CharacterStateEndAttack";
    [SerializeField] string runturnScript = "CharacterStateEndAttack";
    [SerializeField] string crouchScript = "CharacterStateLinger";
    [SerializeField] string jumpcrouchScript = "CharacterStateEndAttack";
    [SerializeField] string riseScript = "CharacterStateLinger";
    [SerializeField] string peakScript = "CharacterStateEndAttack";
    [SerializeField] string doublejumpScript = "CharacterStateEndAttack";
    [SerializeField] string shieldScript = "CharacterStateLinger";
    [SerializeField] string shieldreleaseScript = "CharacterStateEndAttack";
    [SerializeField] string dizzyScript = "CharacterStateLoopable";
    [SerializeField] string tumbleScript = "CharacterStateLoopable";
    [SerializeField] string airdodgeScript = "CharacterStateEndAttack";
    [SerializeField] string rollScript = "CharacterStateEndAttack";
    [SerializeField] string freefallScript = "CharacterStateLoopable";
    [SerializeField] string spotdodgeScript = "CharacterStateEndAttack";
    [SerializeField] string jabScript = "CharacterStateEndAttack";
    [SerializeField] string ftiltScript = "CharacterStateEndAttack";
    [SerializeField] string utiltScript = "CharacterStateEndAttack";
    [SerializeField] string dtiltScript = "CharacterStateEndAttack";
    [SerializeField] string fsmashScript = "CharacterStateEndAttack";
    [SerializeField] string usmashScript = "CharacterStateEndAttack";
    [SerializeField] string dsmashScript = "CharacterStateEndAttack";
    [SerializeField] string grabScript = "CharacterStateEndAttack";
    [SerializeField] string pummelScript = "CharacterStateEndAttack";
    [SerializeField] string fthrowScript = "CharacterStateEndAttack";
    [SerializeField] string uthrowScript = "CharacterStateEndAttack";
    [SerializeField] string bthrowScript = "CharacterStateEndAttack";
    [SerializeField] string dthrowScript = "CharacterStateEndAttack";
    [SerializeField] string nairScript = "CharacterStateEndAttack";
    [SerializeField] string fairScript = "CharacterStateEndAttack";
    [SerializeField] string uairScript = "CharacterStateEndAttack";
    [SerializeField] string bairScript = "CharacterStateEndAttack";
    [SerializeField] string dairScript = "CharacterStateEndAttack";
    [SerializeField] string nspecgScript = "CharacterStateEndAttack";
    [SerializeField] string sspecgScript = "CharacterStateEndAttack";
    [SerializeField] string uspecgScript = "CharacterStateEndAttack";
    [SerializeField] string dspecgScript = "CharacterStateEndAttack";
    [SerializeField] string nspecaScript = "CharacterStateEndAttack";
    [SerializeField] string sspecaScript = "CharacterStateEndAttack";
    [SerializeField] string uspecaScript = "CharacterStateEndAttack";
    [SerializeField] string dspecaScript = "CharacterStateEndAttack";
    [SerializeField] string dashatkScript = "CharacterStateEndAttack";
    [SerializeField] string holdScript = "CharacterStateLinger";
    [SerializeField] string hurtScript = "CharacterStateLinger";
    [SerializeField] string launchedScript = "CharacterStateLoopable";
    [SerializeField] string grabbedScript = "CharacterStateLinger";
    [SerializeField] string ledgehangScript = "CharacterStateLinger";
    [SerializeField] string ledgeclimbScript = "CharacterStateEndAttack";
    [SerializeField] string ledgeatkScript = "CharacterStateEndAttack";
    [SerializeField] string ledgerollScript = "CharacterStateEndAttack";
    [SerializeField] string ledgejumpcrouchScript = "CharacterStateEndAttack";
    [SerializeField] string crashScript = "CharacterStateLinger";
    [SerializeField] string crashgetupScript = "CharacterStateEndAttack";
    [SerializeField] string crashrollScript = "CharacterStateEndAttack";
    [SerializeField] string crashatkScript = "CharacterStateEndAttack";
    [SerializeField] string techScript = "CharacterStateEndAttack";
    [SerializeField] string techrollScript = "CharacterStateEndAttack";

    public string this[string propertyName] => GetType().GetProperty(propertyName).GetValue(this) as string;

    public string Fall => fallScript;
    public string Land => landScript;
    public string Idle => idleScript;
    public string Walk => walkScript;
    public string Dash => dashScript;
    public string Run => runScript;
    public string Skid => skidScript;
    public string Runturn => runturnScript;
    public string Crouch => crouchScript;
    public string Jumpcrouch => jumpcrouchScript;
    public string Rise => riseScript;
    public string Peak => peakScript;
    public string Doublejump => doublejumpScript;
    public string Shield => shieldScript;
    public string Shieldrelease => shieldreleaseScript;
    public string Dizzy => dizzyScript;
    public string Tumble => tumbleScript;
    public string Airdodge => airdodgeScript;
    public string Roll => rollScript;
    public string Freefall => freefallScript;
    public string Spotdodge => spotdodgeScript;
    public string Jab => jabScript;
    public string Ftilt => ftiltScript;
    public string Utilt => utiltScript;
    public string Dtilt => dtiltScript;
    public string Fsmash => fsmashScript;
    public string Usmash => usmashScript;
    public string Dsmash => dsmashScript;
    public string Grab => grabScript;
    public string Pummel => pummelScript;
    public string Fthrow => fthrowScript;
    public string Uthrow => uthrowScript;
    public string Bthrow => bthrowScript;
    public string Dthrow => dthrowScript;
    public string Nair => nairScript;
    public string Fair => fairScript;
    public string Uair => uairScript;
    public string Bair => bairScript;
    public string Dair => dairScript;
    public string Nspecg => nspecgScript;
    public string Sspecg => sspecgScript;
    public string Uspecg => uspecgScript;
    public string Dspecg => dspecgScript;
    public string Nspeca => nspecaScript;
    public string Sspeca => sspecaScript;
    public string Uspeca => uspecaScript;
    public string Dspeca => dspecaScript;
    public string Dashatk => dashatkScript;
    public string Hold => holdScript;
    public string Hurt => hurtScript;
    public string Launched => launchedScript;
    public string Grabbed => grabbedScript;
    public string Ledgehang => ledgehangScript;
    public string Ledgeclimb => ledgeclimbScript;
    public string Ledgeatk => ledgeatkScript;
    public string Ledgeroll => ledgerollScript;
    public string Ledgejumpcrouch => ledgejumpcrouchScript;
    public string Crash => crashScript;
    public string Crashgetup => crashgetupScript;
    public string Crashroll => crashrollScript;
    public string Crashatk => crashatkScript;
    public string Tech => techScript;
    public string Techroll => techrollScript;
}
