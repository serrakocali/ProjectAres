using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// FX and sounds effects.
/// </summary>
public class FXController :Singleton<FXController>
{

	[Header("Particles settings")]
	[SerializeField] ParticleSystem AsphaltSmokeParticles;      //Asphalt smoke (Gray).

	[Header("Trail settings")]
	[SerializeField] TrailRenderer TrailRef;                    //Trail ref, The lifetime of the tracks is configured in it.
	[SerializeField] Transform TrailsHolder;                    //Parent for copy of TrailRef.


	protected override void AwakeSingleton ()
	{
		//Hide ref objects.
		TrailRef.gameObject.SetActive (false);
	}

	#region Particles

	public ParticleSystem GetAspahaltParticles { get { return AsphaltSmokeParticles; } }


	#endregion //Particles

	#region Trail

	Queue<TrailRenderer> FreeTrails = new Queue<TrailRenderer>();

	/// <summary>
	/// Get first free trail and set start position.
	/// </summary>
	public TrailRenderer GetTrail (Vector3 startPos)
	{
		TrailRenderer trail = null;
		if (FreeTrails.Count > 0)
		{
			trail = FreeTrails.Dequeue ();
		}
		else
		{
			trail = Instantiate (TrailRef, TrailsHolder);
		}

		trail.transform.position = startPos;
		trail.gameObject.SetActive (true);

		return trail;
	}

	/// <summary>
	/// Set trail as free and wait life time.
	/// </summary>
	public void SetFreeTrail (TrailRenderer trail)
	{
		StartCoroutine (WaitVisibleTrail (trail));
	}

	/// <summary>
	/// The trail is considered busy until it disappeared.
	/// </summary>
	private IEnumerator WaitVisibleTrail (TrailRenderer trail)
	{
		trail.transform.SetParent (TrailsHolder);
		yield return new WaitForSeconds (trail.time);
		trail.Clear ();
		trail.gameObject.SetActive (false);
		FreeTrails.Enqueue (trail);
	}

	#endregion //Trail

}
