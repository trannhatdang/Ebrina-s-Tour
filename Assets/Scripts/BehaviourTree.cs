using System.Collections.Generic;

public abstract class BehvaiourNode
{
	protected List<Node*> next;
	protected Node* prev;
	protected string name;
	public abstract void Behave(GameObject obj);
	public abstract bool Condition(GameObject obj);

	public void AddNext(Node* node)
	{
		next.Add(node);
		node->prev = *this;
	}
}

[CreateAssetMenu(fileName = "Behaviour Tree", menuName = "ScriptableObjects/Behaviour")]
public class BehaviourTree : ScriptableObject
{

}
