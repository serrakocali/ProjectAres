using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Car sound controller, for play car sound effects
/// </summary>

[RequireComponent (typeof (CarController))]
public class CarSoundController :MonoBehaviour
{

	[Header("Engine sounds")]
	[SerializeField] AudioClip EngineIdleClip;
	[SerializeField] AudioClip EngineBackFireClip;
	[SerializeField] float PitchOffset = 0.5f;
	[SerializeField] AudioSource EngineSource;

	[Header("Slip sounds")]
	[SerializeField] AudioSource SlipSource;
	[SerializeField] float MinSlipSound = 0.15f;
	[SerializeField] float MaxSlipForSound = 1f;

	CarController CarController;

	float MaxRPM { get { return CarController.GetMaxRPM; } }
	float EngineRPM { get { return CarController.EngineRPM; } }

	private void Awake ()
	{
		CarController = GetComponent<CarController> ();
		CarController.BackFireAction += PlayBackfire;
	}

	void Update ()
	{

		//Engine PRM sound
		EngineSource.pitch = (EngineRPM / MaxRPM) + PitchOffset;

		//Slip sound logic
		if (CarController.CurrentMaxSlip > MinSlipSound
		)
		{
			if (!SlipSource.isPlaying)
			{
				SlipSource.Play ();
			}
			var slipVolumeProcent = CarController.CurrentMaxSlip / MaxSlipForSound;
			SlipSource.volume = slipVolumeProcent * 0.5f;
			SlipSource.pitch = Mathf.Clamp (slipVolumeProcent, 0.75f, 1);
		}
		else
		{
			SlipSource.Stop ();
		}
	}

	void PlayBackfire ()
	{
		EngineSource.PlayOneShot (EngineBackFireClip);
	}
}
