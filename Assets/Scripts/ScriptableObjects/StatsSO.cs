using UnityEngine;
using System.Collections.Generic;


public abstract class StatsSO : ScriptableObject 
{
	[SerializeField] private int _hitPoints = -1;
	[SerializeField] private int _attackStat = -1;
	[SerializeField] private int _defenseStat = -1;
	[SerializeField] private List<UpgradesSO> _upgrades;
	[SerializeField] private List<BuffsSO> _buffs;

	protected int GetHPStatAfterUpgrades()
	{
		if(_upgrades.Count == 0) return;
		int retval = _hitPoints;

		for(var upgrade in _upgrades)
		{
			retval += _upgrades.HPBoost;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_HP);
	}
	
	protected int GetATKStatAfterUpgrades()
	{
		if(_upgrades.Count == 0) return;
		int retval = _attackStat;

		for(var upgrade in _upgrades)
		{
			retval += _upgrades.ATKBoost;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_ATK);
	}

	protected int GetDEFStatAfterUpgrades()
	{
		if(_upgrades.Count == 0) return;
		int retval = _defenseStat;

		for(var upgrade in _upgrades)
		{
			retval += _upgrades.DEFBoost;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_DEF);
	}

	public abstract int GetHP(bool _hasUpgrades = true);
	public abstract int GetATK(bool _hasUpgrades = true);
	public abstract int GetDEF(bool _hasUpgrades = true);
	//public abstract void SetHP(int val);
	//public abstract void SetATK(int val);
	//public abstract void SetDEF(int val);
}
