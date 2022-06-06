using UnityEngine;

/// <summary> 
/// Fast access to settings.
/// B - Balance.
/// </summary>
public static class B
{
	public static float SpeedInHourMultiplier { get { return C.KPHMult; } }

}

/// <summary> 
/// Constants used in game
/// C - Constants
/// </summary>
/// 
public static class C
{
	//CarParams constants
	public const float MPHMult = 2.23693629f;
	public const float KPHMult = 3.6f;

}
