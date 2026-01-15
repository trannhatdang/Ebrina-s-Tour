using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "ScriptableObjects/Stats/PlayerStatsSO")]
public class PlayerStatsSO : StatsSO
{
	[SerializeField] private int _rageAttackStat = -1;
	[SerializeField] private int _calmAttackStat = -1;

	/*public override void SetHP(int val)
	{
		_hitPoints = Mathf.Clamp(val, 0, Limits.MAX_PLAYER_HP);	
	}
	public override void SetATK(int val)
	{
		_attackStat = Mathf.Clamp(val, 0, Limits.MAX_PLAYER_ATTACK);
	}
	public override void SetDEF(int val)
	{
		_defenseStat = Mathf.Clamp(val, 0, Limits.MAX_PLAYER_DEFENSE);
	}*/
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
