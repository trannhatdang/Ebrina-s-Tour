using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	[SerializeField] GameObject _astarBlob;

	public Vector3 Astar()
	{
		if(!_astarBlob) 
		{
			Debug.LogError("Enemy is assigned Astar but has no assigned astarblob");
		}

		AstarMoveBlob(_astarBlob.transform.position, Vector2.left);
		AstarMoveBlob(_astarBlob.transform.position, Vector2.right);
		AstarMoveBlob(_astarBlob.transform.position, Vector2.up);
		AstarMoveBlob(_astarBlob.transform.position, Vector2.down);
		AstarMoveBlob(_astarBlob.transform.position, new Vector2(1, 1));
		AstarMoveBlob(_astarBlob.transform.position, new Vector2(-1, 1));
		AstarMoveBlob(_astarBlob.transform.position, new Vector2(1, -1));
		AstarMoveBlob(_astarBlob.transform.position, new Vector2(-1, -1));
	}

	private int AstarMoveBlob(Vector3 pos, Vector2 dir)
	{
		pos += (Vector3)dir;

		Vector3.Distance(pos, )

		return 
	}
}
