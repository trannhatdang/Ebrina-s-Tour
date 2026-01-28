using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] List<DialogueSO> _dialogueThisScene;

    [Header("UpperDialogueBox")]
    [SerializeField] private DialogueBox _upperDialogueBox;

    [Header("BackgroundBox")]
    [SerializeField] private DialogueBox _backgroundBox;

    [Header("LowerDialogueBox")]
    [SerializeField] private GameObject _charactersParent;
    [SerializeField] private GameObject _imagePrefab;
    [SerializeField] private DialogueBox _lowerDialogueBox;
    // AudioSFX??? here???
    private bool _isPlaying = false;
    private int _nextDialogue = 0;
    private List<int> _XPositions = new List<int>();
    private List<Image> _characterImages = new List<Image>();

    public static DialogManager instance {get; private set;}

    void Awake()
    {
	if(instance && instance != this)
	{
		Destroy(this.gameObject);
	}
	instance = this;
	_nextDialogue = 0;
    }

    public async UniTask RequestPlayDialogue()
    {
	if(_nextDialogue < 0 || _nextDialogue >= _dialogueThisScene.Count) return;
	if(_isPlaying) return;

	if(_dialogueThisScene[_nextDialogue].DialogueEntries.Count == 0)
	{
		_nextDialogue++;
		return;
	}

	await Play();
    }

    public async UniTask RequestPlayDialogue(DialogueSO _inputDialogueSO)
    {
	if(_isPlaying) return;
	if(_nextDialogue < 0) 
	{
		_nextDialogue = 0;
	}

	_dialogueThisScene.Insert(_nextDialogue, _inputDialogueSO);
	await Play();
    }

    private async UniTask Play()
    {
	_isPlaying = true;
	_XPositions.Clear();
	_characterImages.Clear();
	List<Dialogue> _dialogueCurrent = _dialogueThisScene[_nextDialogue].DialogueEntries;
	DialogueBox _dialogueBox;

	switch(_dialogueThisScene[_nextDialogue].Location)
	{
		case DialogueLocation.UPPER:
			_dialogueBox = _upperDialogueBox;
			break;

		case DialogueLocation.BACKGROUND:
			_dialogueBox = _backgroundBox;
			break;

		default:
			_dialogueBox = _lowerDialogueBox;
			break;
	}

	_dialogueBox.gameObject.SetActive(true);
	
	for(int i = 0; i < _dialogueCurrent.Count; ++i)
	{
		Dialogue dialogue = _dialogueCurrent[i];
		int _spriteAlreadyIn = ContainsSprite(dialogue.SpeakerSprite);
		int _thereAreSpriteNearby = CheckIfSpriteTooNearby(dialogue.SpeakerXPosition);
		InsertSprite(_spriteAlreadyIn, _thereAreSpriteNearby, dialogue.SpeakerXPosition, dialogue.SpeakerSprite);

		await _dialogueBox.PlayDialogue(dialogue);
	}
	_nextDialogue++;
	_isPlaying = false;

	_dialogueBox.gameObject.SetActive(false);
    }

    int ContainsSprite(Sprite sprite)
    {
	for(int i = 0; i < _characterImages.Count; ++i)
	{
		var spr = _characterImages[i];
		if(spr.sprite == sprite)
		{
			return i;
		}
	}

	return -1;
    }

    int CheckIfSpriteTooNearby(int dialogueXPosition)
    {
	dialogueXPosition = Math.Abs(dialogueXPosition);
	for(int i = 0; i < _XPositions.Count; ++i)
	{
		int pos = Math.Abs(_XPositions[i]);
		if(dialogueXPosition >= (pos - 200) && dialogueXPosition <= (pos + 200))
		{
			return i;
		}
	}

	return -1;
    }

    void DisableSprite(int index)
    {
	if(index < 0 || index >= _characterImages.Count)
	{
		return;
	}
	_characterImages[index].gameObject.SetActive(false);
	_XPositions.RemoveAt(index);
    }

    int NewSprite(Sprite _toAdd)
    {
	GameObject newObject = Instantiate(_imagePrefab, new UnityEngine.Vector3(-1, transform.position.y, transform.position.z), Quaternion.identity, _charactersParent.transform);
	_characterImages.Add(newObject.GetComponent<Image>());

	int newIndex = _characterImages.Count-1;
	_characterImages[newIndex].sprite = _toAdd;
	return newIndex;
    }

    void MoveSprite(Transform tfs, int posToMove)
    {
	if(tfs.position.x >= 0 && _XPositions.Contains((int)tfs.position.x))
	{
		_XPositions.Remove((int)tfs.position.x);
	}
	(tfs as RectTransform).position = new UnityEngine.Vector3(Mathf.Max(0, Mathf.Min(posToMove, 1920)), tfs.position.y, tfs.position.z);
	_XPositions.Add(posToMove);
	//hort size of screen
    }

    void InsertSprite(int _spriteAlreadyIn, int _spriteNearby, int posToMove, Sprite newSprite = null)
    {
	if(_spriteNearby >= 0)
	{
		DisableSprite(_spriteNearby);
	}

	if(_spriteAlreadyIn < 0 && newSprite)
	{
		_spriteAlreadyIn = NewSprite(newSprite);
	}

	if(_spriteAlreadyIn >= 0)
	{
		Image _sprite = _characterImages[_spriteAlreadyIn];
		_sprite.gameObject.SetActive(true);
		MoveSprite(_sprite.gameObject.transform, posToMove);
	}
    }
}
