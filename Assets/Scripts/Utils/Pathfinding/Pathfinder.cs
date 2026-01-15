using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	[SerializeField] GameObject _astarBlob;

	public Vector2 AStar(Vector2 target)
	{
		if(!_astarBlob) 
		{
			Debug.LogError("Enemy is assigned Astar but has no assigned astarblob");
		}

		Vector2 retval = new Vector2(0, 0);
		float maxDist = 1.0f;

		for(int i = -1; i <= 1; ++i)
		{
			for(int j = -1; j <= 1; ++j)
			{
				Vector2 dir = new Vector2(i, j);
				float newDist = AstarMoveBlob((Vector2)_astarBlob.transform.position, dir, target);

				if(newDist > maxDist)
				{
					maxDist = newDist;
					retval = dir;
				}
			}
		}

		return retval;
	}

	private float AstarMoveBlob(Vector2 pos, Vector2 dir, Vector2 target)
	{
		pos += (Vector2)dir;

		return Vector2.Distance(pos, target);
	}
}
