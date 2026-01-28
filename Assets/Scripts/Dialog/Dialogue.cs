using System;
using UnityEngine;
using UnityEditor;

public enum DialogueType {NORMAL, EXTENDS, SHAKING, FLAT}
[System.Serializable]
public class Dialogue
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public DialogueType Type
    {
	get => _type;
	private set {;}
    }
    public Sprite SpeakerSprite
    {
	get => _speakerSprite;
	private set {;}
    }
    public string SpeakerName
    {
	get => _speakerName;
	private set {;}
    }
    public int DelayInFrames
    {
	get => _delayInFrames;
	private set {;}
    }
    public bool Skippable
    {
	get => _skippable;
	private set {;}
    }
    public bool FreezesGame
    {
	get => _freezesGame;
	private set {;}
    }
    public int SpeakerXPosition
    {
	    get => _speakerXPosition;
	    private set{;}
    }
    public string Text
    {
	get => _text;
	private set {;}
    }

    [SerializeField] DialogueType _type;
    [SerializeField] Sprite _speakerSprite;
    [SerializeField] String _speakerName;
    [SerializeField, TextAreaAttribute] string _text;
    [SerializeField] int _delayInFrames;
    [SerializeField] int _speakerXPosition;
    [SerializeField] bool _skippable;
    [SerializeField] bool _freezesGame;
}
