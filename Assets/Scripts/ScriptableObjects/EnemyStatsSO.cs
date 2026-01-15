using UnityEngine;

public class EnemyStatsSO : StatsSO
{
	public override int GetHP(bool _hasBuffs)
	{
		if(_hasBuffs)
		{
			return GetHPAfterBuffs();
		}
		else
		{
			return GetHPAfterUpgrades(); 
		}
	} 
	public override int GetATK(bool _hasBuffs)
	{
		if(_hasBuffs)
		{
			return GetATKAfterBuffs();
		}
		else
		{
			return GetATKAfterUpgrades();
		}
	}
	public override int GetDEF(bool _hasBuffs)
	{
		if(_hasBuffs)
		{
			return GetDEFAfterBuffs();
		}
		else
		{
			return GetDEFAfterUpgrades();
		}
	}
}
