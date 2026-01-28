using UnityEngine;

namespace BehaviourTree.Elements
{
	[CreateAssetMenu(fileName = "BTTestNodeSO", menuName = "ScriptableObjects/Behaviour Tree/BTTestNodeSO")]
	public class BTTestNodeSO : BTNodeSO
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
