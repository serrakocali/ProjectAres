using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtentions
{

	public static int LoopClamp (int value, int minValue, int maxValue)
	{
		while (value < minValue || value >= maxValue)
		{
			if (value < minValue)
			{
				value += maxValue - minValue;
			}
			else if (value >= maxValue)
			{
				value -= maxValue - minValue;
			}
		}
		return value;
	}

	public static float LoopClamp (float value, float minValue, float maxValue)
	{
		while (value < minValue || value >= maxValue)
		{
			if (value < minValue)
			{
				value += maxValue - minValue;
			}
			else if (value >= maxValue)
			{
				value -= maxValue - minValue;
			}
		}
		return value;
	}

	public static float Abs (this float value)
	{
		return Mathf.Abs (value);
	}

	public static float Clamp (this float value)
	{
		return Mathf.Clamp01 (value);
	}

	public static float Clamp (this float value, float minValue, float maxValue)
	{
		return Mathf.Clamp (value, minValue, maxValue);
	}

	public static float AbsClamp (this float value)
	{
		return value.Abs ().Clamp ();
	}

	public static float AbsClamp (this float value, float minValue, float maxValue)
	{
		return value.Abs ().Clamp (minValue, maxValue);
	}

	public static int ToInt (this float value)
	{
		return Mathf.RoundToInt (value);
	}
}
