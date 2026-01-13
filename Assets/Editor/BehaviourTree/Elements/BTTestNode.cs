using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace BehaviourTree.Elements
{
	public class BTTestNode : BTNode
	{
		public override bool CheckCondition(GameObject obj)
		{
			return false;
		}
		public override void Behave(GameObject obj)
		{
			Debug.Log("test");
		}
		public void Draw()
		{
			TextField dialogueNameTextField = new TextField()
			{
				value = NodeName
			};

			titleContainer.Insert(0, dialogueNameTextField);

			Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));

			inputPort.portName = "Node Connection";

			inputContainer.Add(inputPort);
		}
	}
}
