using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

namespace BehaviourTree.Elements
{
	public abstract class BTNode : Node
	{
		public string NodeName { get; set; }
		//public BTNodeType NodeType { get; set; }

		public void Initialize(Vector2 position)
		{
			NodeName = "NodeName";

			SetPosition(new Rect(position, Vector2.zero));
		}

		public abstract bool CheckCondition(GameObject obj);
		public abstract void Behave(GameObject obj);
	}
}
