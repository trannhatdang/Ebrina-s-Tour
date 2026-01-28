using UnityEngine;

public class EnemyStatsSO : StatsSO
{
	public override int GetHP(bool _hasBuffs)
	{
		if(_hasBuffs)
		{
			return GetHPStatAfterBuffs();
		}
		else
		{
			return GetHPStatAfterUpgrades(); 
		}
	} 
	public override int GetATK(bool _hasBuffs)
	{
		if(_hasBuffs)
		{
			return GetATKStatAfterBuffs();
		}
		else
		{
			return GetATKStatAfterUpgrades();
		}
	}
	public override int GetDEF(bool _hasBuffs)
	{
		if(_hasBuffs)
		{
			return GetDEFStatAfterBuffs();
		}
		else
		{
			return GetDEFStatAfterUpgrades();
		}
	}
}
