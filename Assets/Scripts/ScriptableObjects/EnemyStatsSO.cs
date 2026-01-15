using UnityEngine;

public class EnemyStatsSO : StatsSO
{
	public override int GetHP(bool _hasUpgrades)
	{
		if(_hasUpgrades)
		{
			return GetHPAfterUpgrades(); 
		}
		else
		{
			return Mathf.Clamp(_hitPoints, 0, Limits.MAX_PLAYER_HP);
		}
	} 
	public override int GetATK(bool _hasUpgrades)
	{
		if(_hasUpgrades)
		{
			return GetATKAfterUpgrades();
		}
		else
		{
			return Mathf.Clamp(_attackStat, 0, Limits.MAX_PLAYER_ATTACK);
		}
	}
	public override int GetDEF(bool _hasUpgrades)
	{
		if(_hasUpgrades)
		{
			return GetDEFAfterUpgrades();
		}
		else
		{
			return Mathf.Clamp(_defenseStat, 0, Limits.MAX_PLAYER_DEFENSE)
		}
	}
}
