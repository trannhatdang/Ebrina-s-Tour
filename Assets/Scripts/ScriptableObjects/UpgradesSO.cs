using UnityEngine;

[CreateAssetMenu(fileName="UpgradesSO", menuName="ScriptableObjects/UpgradesSO")]
public class UpgradesSO : ScriptableObject
{
	/*public enum UpgradeType {
		Player,
		Enemy
	}

	[SerializeField] UpgradeType _type;*/
	[SerializeField] int _hpBoost;
	[SerializeField] int _atkBoost;
	[SerializeField] int _defBoost;

	public int HPBoost
	{
		get { return _hpBoost; }
		private set { _hpBoost = value; }
	}

	public int ATKBoost
	{
		get { return _atkBoost; }
		private set { _atkBoost = value; }
	}

	public int DEFBoost
	{
		get { return _defBoost; }
		private set { _defBoost = value; }
	}
}
