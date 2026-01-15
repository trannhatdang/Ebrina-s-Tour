using UnityEngine;

namespace BehaviourTree.Elements
{
	[CreateAssetMenu(fileName = "BTIdleNodeSO", menuName = "ScriptableObjects/Behaviour Tree/BTIdleNodeSO")]
	public class BTIdleNodeSO : BTNodeSO
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
