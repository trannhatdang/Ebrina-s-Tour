using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace BehaviourTree.Elements
{
	using Enumerations;
	public abstract class BTNode : Node
	{
		public string NodeName { get; set; }
		public BTNodeType NodeType { get; set; }

		public virtual void Initialize(Vector2 position)
		{
			NodeName = "NodeName";

			SetPosition(new Rect(position, Vector2.zero));
		}

		public virtual void Draw()
		{
			TextField dialogueNameTextField = new TextField()
			{
				value = NodeName
			};

			titleContainer.Insert(0, dialogueNameTextField);

			Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));

			inputPort.portName = "Node Connection";

			inputContainer.Add(inputPort);
		}
	}
}
