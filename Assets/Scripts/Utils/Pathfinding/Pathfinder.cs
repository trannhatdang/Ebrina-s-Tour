using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	[SerializeField] GameObject _astarBlob;

	public Vector2 Astar(Vector2 target)
	{
		if(!_astarBlob) 
		{
			Debug.LogError("Enemy is assigned Astar but has no assigned astarblob");
		}

		Vector2 retval = new Vector2(0, 0);
		int maxDist = -1;

		for(int i = -1; i <= 1; ++i)
		{
			for(int j = -1; j <= 1; ++j)
			{
				Vector2 dir = new Vector2(i, j);
				int newDist = AstarMoveBlob((Vector2)_astarBlob.transform.position, dir, target);

				if(newDist > maxDist)
				{
					newDist = maxDist;
					retval = dir;
				}
			}
		}

		return retval;
	}

	private int AstarMoveBlob(Vector2 pos, Vector2 dir, Vector2 target)
	{
		pos += (Vector2)dir;

		return Vector2.Distance(pos, target);
	}
}
