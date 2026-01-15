using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "ScriptableObjects/Stats/PlayerStatsSO")]
public class PlayerStatsSO : StatsSO
{
	[SerializeField] private int _rageAttackStat = -1;
	[SerializeField] private int _calmAttackStat = -1;

	/*public override void SetHPStat(int val)
	{
		_hitPoints = Mathf.Clamp(val, 0, Limits.MAX_PLAYER_HPStat);	
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
