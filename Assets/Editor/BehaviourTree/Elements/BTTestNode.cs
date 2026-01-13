using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace BehaviourTree.Elements
{
	using Enumerations;
	public class BTTestNode : BTNode
	{
		[SerializeField] int testInt;
		public override void Initialize(Vector2 position)
		{
			base.Initialize(position);
			NodeName = "TestNode";
			NodeType = BTNodeType.Test;
		}

		public override void Draw()
		{
			base.Draw();
		}
	}
}
