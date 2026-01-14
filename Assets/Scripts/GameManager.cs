using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] Player _player;

	void Start()
	{
		if(!_player)
		{
			//Debug.LogError("No Player assigned to GameManager!");
		}
	}

	void Update()
	{

	}
}
