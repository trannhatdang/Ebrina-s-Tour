using System;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueLocation {UPPER, LOWER, BACKGROUND}
[CreateAssetMenu(fileName="DialogueSO", menuName="DialogueSO")]
public class DialogueSO : ScriptableObject
{
	public List<Dialogue> DialogueEntries 
	{
		get => _dialogueEntries;
		private set {;}
	}

	public DialogueLocation Location
	{
		get => _location;
		private set {;}
	}
	public InterruptTN InterruptTNType
	{
		get => _interruptTNType;
		private set {;}
	}
	[SerializeField] List<Dialogue> _dialogueEntries;
	[SerializeField] DialogueLocation _location;
	[SerializeField] InterruptTN _interruptTNType;
}
