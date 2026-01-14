using UnityEngine;

public abstract class StatsSO : ScriptableObject 
{
	[SerializeField] private int _hitPoints = -1;
	[SerializeField] private int _attackStat = -1;
	[SerializeField] private int _defenseStat = -1;

	public abstract int GetHP();
	public abstract void SetHP(int val);
	public abstract int GetATK();
	public abstract void SetATK(int val);
	public abstract int GetDEF();
	public abstract void SetDEF(int val);
}
