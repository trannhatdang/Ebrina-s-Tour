using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Elements
{
	public abstract class BTNodeSO : ScriptableObject
	{
		[SerializeField] List<BTNodeSO> _next;
		[SerializeField] BTNodeSO _prev;

		public abstract bool CheckCondition(GameObject obj);
		public abstract void DoBehaviour(GameObject obj);
	}
}
