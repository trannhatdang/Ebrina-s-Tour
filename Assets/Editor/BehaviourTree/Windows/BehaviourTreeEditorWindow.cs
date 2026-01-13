using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace BehaviourTree.Windows
{
	public class BehaviourTreeEditorWindow : EditorWindow
	{
		[MenuItem("Window/Behaviour Tree/Behaviour Tree Graph")]
		public static void ShowExample()
		{
			GetWindow<BehaviourTreeEditorWindow>("Behaviour Tree Graph");
		}
		
		private void CreateGUI()
		{
			AddGraphView();

			AddStyles();

		}

		private void AddGraphView()
		{
			BTGraphView graphView = new BTGraphView();

			graphView.StretchToParentSize();

			rootVisualElement.Add(graphView);
		}

		private void AddStyles()
		{
			StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("BehaviourTree/BTVariables.uss");
			rootVisualElement.styleSheets.Add(styleSheet);

		}
	}

}
