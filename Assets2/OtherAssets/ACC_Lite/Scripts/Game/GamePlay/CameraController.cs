using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move and rotation camera controller
/// </summary>

public class CameraController :Singleton<CameraController>
{

	[SerializeField] KeyCode SetCameraKey = KeyCode.C;                              //Set next camore on PC hotkey.
	[SerializeField] UnityEngine.UI.Button NextCameraButton;
	[SerializeField] List<CameraPreset> CamerasPreset = new List<CameraPreset>();   //Camera presets

	int ActivePresetIndex = 0;
	CameraPreset ActivePreset;

	CarController TargetCar { get { return GameController.PlayerCar; } }
	GameController GameController { get { return GameController.Instance; } }

	float SqrMinDistance;

	//The target point is calculated from velocity of car.
	Vector3 TargetPoint
	{
		get
		{
			if (GameController == null || TargetCar == null)
			{
				return transform.position;
			}
			Vector3 result = TargetCar.RB.velocity * ActivePreset.VelocityMultiplier;
			result += TargetCar.transform.position;
			result.y = 0;
			return result;
		}
	}

	protected override void AwakeSingleton ()
	{
		CamerasPreset.ForEach (c => c.CameraHolder.SetActive (false));
		UpdateActiveCamera ();

		if (NextCameraButton)
		{
			NextCameraButton.onClick.AddListener (SetNextCamera);
		}
	}

	private IEnumerator Start ()
	{
		while (GameController == null)
		{
			yield return null;
		}
		transform.position = TargetPoint;
	}

	private void Update ()
	{
		if (ActivePreset.EnableRotation && (TargetPoint - transform.position).sqrMagnitude >= SqrMinDistance)
		{
			Quaternion rotation = Quaternion.LookRotation (TargetPoint - transform.position, Vector3.up);
			ActivePreset.CameraHolder.rotation = Quaternion.Lerp (ActivePreset.CameraHolder.rotation, rotation, Time.deltaTime * ActivePreset.SetRotationSpeed);
		}

		transform.position = Vector3.LerpUnclamped (transform.position, TargetPoint, Time.deltaTime * ActivePreset.SetPositionSpeed);

		if (Input.GetKeyDown (SetCameraKey))
		{
			SetNextCamera ();
		}
	}

	public void SetNextCamera ()
	{
		ActivePresetIndex = MathExtentions.LoopClamp (ActivePresetIndex + 1, 0, CamerasPreset.Count);
		UpdateActiveCamera ();
	}

	public void UpdateActiveCamera ()
	{
		if (ActivePreset != null)
		{
			ActivePreset.CameraHolder.SetActive (false);
		}

		ActivePreset = CamerasPreset[ActivePresetIndex];
		ActivePreset.CameraHolder.SetActive (true);

		SqrMinDistance = ActivePreset.MinDistanceForRotation * 2;

		if (ActivePreset.EnableRotation && (TargetPoint - transform.position).sqrMagnitude >= SqrMinDistance)
		{
			Quaternion rotation = Quaternion.LookRotation (TargetPoint - transform.position, Vector3.up);
			ActivePreset.CameraHolder.rotation = rotation;
		}
	}

	[System.Serializable]
	class CameraPreset
	{
		public Transform CameraHolder;                  //Parent fo camera.
		public float SetPositionSpeed = 1;              //Change position speed.
		public float VelocityMultiplier;                //Velocity of car multiplier.

		public bool EnableRotation;
		public float MinDistanceForRotation = 0.1f;     //Min distance for potation, To avoid uncontrolled rotation.
		public float SetRotationSpeed = 1;              //Change rotation speed.
	}
}
