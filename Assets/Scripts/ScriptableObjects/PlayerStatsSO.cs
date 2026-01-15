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
