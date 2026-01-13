using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

namespace BehaviourTree.Windows
{
	using Elements;
	public class BTGraphView : GraphView
	{
		public BTGraphView()
		{
			AddManipulators();
			AddGridBackground();

			AddStyles();
		}

		private void AddManipulators()
		{
			SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

			this.AddManipulator(CreateNodeContextualMenu());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());
			this.AddManipulator(new ContentDragger());

		}

		private IManipulator CreateNodeContextualMenu()
		{
			ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
				menuEvent => menuEvent.menu.AppendAction("Add Test Node", actionEvent => AddElement(CreateTestNode(actionEvent.eventInfo.localMousePosition)))
			);

			return contextualMenuManipulator;
		}

		private void AddGridBackground()
		{
			GridBackground gridBackground = new GridBackground();

			gridBackground.StretchToParentSize();

			Insert(0, gridBackground);
		}

		private BTTestNode CreateTestNode(Vector2 position)
		{
			BTTestNode node = new BTTestNode();

			node.Initialize(position);
			node.Draw();

			return node;

		}

		private void AddStyles()
		{
			StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("BehaviourTree/BTGraphViewStyles.uss");
			styleSheets.Add(styleSheet);
		}
	}
}
