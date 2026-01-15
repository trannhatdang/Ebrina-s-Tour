using UnityEngine;

namespace BehaviourTree.Elements
{
	[CreateAssetMenu(fileName = "BTMoveNodeSO", menuName = "ScriptableObjects/Behaviour Tree/BTMoveNodeSO")]
	public class BTMoveNodeSO : BTNodeSO
	{
		public override bool CheckCondition(GameObject obj)
		{
			return false;
		}

		public override void DoBehaviour(GameObject obj)
		{
			return;
		}

	}
}
