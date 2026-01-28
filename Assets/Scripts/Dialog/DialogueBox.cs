using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks;
using TMPro;

public class DialogueBox : MonoBehaviour, IPointerDownHandler
{
	[SerializeField] private TMP_Text _textToCrawl;
	[SerializeField] private TMP_Text _name;
	private bool _skipped = false;
	private bool _inTextBox = false;

	public async UniTask PlayDialogue(Dialogue _dialogue)
	{
		_skipped = false;
		string _text = _dialogue.Text;

		if(_dialogue.DelayInFrames <= 0)
		{
			_skipped = true;
		}

		if(_dialogue.Type == DialogueType.EXTENDS)
		{
			_skipped = true;
			_textToCrawl.text = _textToCrawl.text + " " + _text;
		}

		_name.text = _dialogue.SpeakerName;
		_textToCrawl.text = _text;
		_textToCrawl.color = Color.clear;
		_textToCrawl.ForceMeshUpdate();

		for(int i = 0; i < _textToCrawl.textInfo.characterCount; ++i)
		{
			int meshIndex = _textToCrawl.textInfo.characterInfo[i].materialReferenceIndex;
			int vertexIndex = _textToCrawl.textInfo.characterInfo[i].vertexIndex;
			Color32[] vertexColors = _textToCrawl.textInfo.meshInfo[meshIndex].colors32;

			for(int j = 0; j < 4; ++j)
			{
				vertexColors[vertexIndex + j] = Color.white;
			}
			_textToCrawl.UpdateVertexData(TMP_VertexDataUpdateFlags.All);

			if(_dialogue.Skippable && _skipped)
			{
				break;
			}

			for(int j = 0; j < _dialogue.DelayInFrames; ++j)
			{
				if(_dialogue.Skippable && _skipped)
				{
					break;
				}

				await UniTask.NextFrame();
			}
		}
		_textToCrawl.color = Color.white;
		_textToCrawl.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
		_skipped = false;

		while(true)
		{
			if(_skipped) 
			{
				break;
			}
			await UniTask.NextFrame();
		}
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		_skipped = true;
	}
}
