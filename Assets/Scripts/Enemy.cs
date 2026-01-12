using UnityEngine;

class MoveBehaviourNode : BehaviourNode
{
	public override void Behave(GameObject obj)
	{

	}

	public override bool Condition(GameObject obj)
	{

	}
}

public class Enemy : MonoBehaviour
{
	BehaviourNode* currNode;
	[SerializeField] BehaviourTree _tree;
	void Start()
	{
		_currNode = _tree.InitNode();
	}

	void Update()
	{
		_currNode->Behave(this);
		_currNode->Condition(this);
	}
}
