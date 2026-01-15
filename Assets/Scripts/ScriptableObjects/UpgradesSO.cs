using UnityEngine;

[CreateAssetMenu(fileName="UpgradesSO", menuName="ScriptableObjects/UpgradesSO")]
public class UpgradesSO : ScriptableObject
{
	/*public enum UpgradeType {
		Player,
		Enemy
	}

	[SerializeField] UpgradeType _type;*/
	[SerializeField] string _upgradeName;
	[SerializeField] int _hpUpgrade;
	[SerializeField] int _atkUpgrade;
	[SerializeField] int _defUpgrade;

	public string UpgradeName
	{
		get { return _upgradeName; }
		private set { _upgradeName = value; }
	}
	public int HPUpgrade
	{
		get { return _hpUpgrade; }
		private set { _hpUpgrade = value; }
	}

	public int ATKUpgrade
	{
		get { return _atkUpgrade; }
		private set { _atkUpgrade = value; }
	}

	public int DEFUpgrade
	{
		get { return _defUpgrade; }
		private set { _defUpgrade = value; }
	}
}
