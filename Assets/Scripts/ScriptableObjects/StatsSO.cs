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
		int retval = _hitPoints;

		foreach(var upgrade in _upgrades)
		{
			retval += upgrade.HPUpgrade;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_HP);
	}
	
	protected int GetATKStatAfterUpgrades()
	{
		int retval = _attackStat;

		foreach(var upgrade in _upgrades)
		{
			retval += upgrade.ATKUpgrade;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_ATTACK);
	}

	protected int GetDEFStatAfterUpgrades()
	{
		int retval = _defenseStat;

		foreach(var upgrade in _upgrades)
		{
			retval += upgrade.DEFUpgrade;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_DEFENSE);
	}

	protected int GetHPStatAfterBuffs()
	{
		int retval = GetHPStatAfterUpgrades();

		foreach(var buff in _buffs)
		{
			retval += buff.HPBuff;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_HP);
	}
	
	protected int GetATKStatAfterBuffs()
	{
		int retval = GetATKStatAfterUpgrades();

		foreach(var buff in _buffs)
		{
			retval += buff.ATKBuff;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_ATTACK);
	}

	protected int GetDEFStatAfterBuffs()
	{
		int retval = GetDEFStatAfterUpgrades();

		foreach(var buff in _buffs)
		{
			retval += buff.DEFBuff;
		}

		return Mathf.Clamp(retval, 0, Limits.MAX_PLAYER_DEFENSE);
	}

	public abstract int GetHP(bool _hasBuffs = true);
	public abstract int GetATK(bool _hasBuffs = true);
	public abstract int GetDEF(bool _hasBuffs = true);
	//public abstract void SetHP(int val);
	//public abstract void SetATK(int val);
	//public abstract void SetDEF(int val);
}
