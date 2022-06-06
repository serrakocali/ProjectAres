using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtensions
{

	public static T GetSafe<T> (this T[] array, int index)
	{
		if (array == null || index < 0 || index > array.Length)
		{
			return default (T);
		}
		return array[index];
	}

}
