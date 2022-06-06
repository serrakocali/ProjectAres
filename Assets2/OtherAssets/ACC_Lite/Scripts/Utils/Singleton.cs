using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// To access the heir by a static field "Instance".
/// </summary>
public abstract class Singleton<T> :MonoBehaviour where T : Singleton<T>
{

	[SerializeField] private bool dontDestroyOnLoad;

	private static T instance;

	public static T Instance
	{
		get
		{
			return instance;
		}
	}

	void Awake ()
	{
		if (instance == null)
		{
			instance = this as T;
			if (dontDestroyOnLoad)
			{
				DontDestroyOnLoad (gameObject);
			}
			AwakeSingleton ();
		}
		else
		{
			Destroy (gameObject.GetComponent<T> ());
		}
	}
	protected abstract void AwakeSingleton ();
}
