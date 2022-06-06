using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OtherExtentions
{

	#region Object extensions

	public static void SetActive (this Component obj, bool value)
	{
		obj.gameObject.SetActive (value);
	}

	#endregion //Object extensions

	#region String extensions

	public static string ToStringTime (this float time)
	{
		time = Mathf.Abs (time);
		int minutes = (int)time / 60;
		int seconds = (int)time - 60 * minutes;
		int milliseconds = (int)(100 * (time - minutes * 60 - seconds));
		return string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
	}

	public static string ToStringTime (this float time, string format)
	{
		int minutes = (int)time / 60;
		int seconds = (int)time - 60 * minutes;
		int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
		return string.Format (format, minutes, seconds, milliseconds);
	}

	#endregion //String extensions

}
