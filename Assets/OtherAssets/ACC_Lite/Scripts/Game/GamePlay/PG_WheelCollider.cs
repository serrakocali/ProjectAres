using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PG_Physics.Wheel
{

	[RequireComponent (typeof (WheelCollider))]
	public class PG_WheelCollider :MonoBehaviour
	{
		[SerializeField, FullField] PG_WheelColliderConfig WheelConfig;

		[SerializeField, HideInInspector] WheelCollider m_WheelCollider;
		[SerializeField, HideInInspector] Rigidbody m_RB;

		public WheelCollider WheelCollider
		{
			get
			{
				if (m_WheelCollider == null)
				{
					m_WheelCollider = GetComponent<WheelCollider> ();
				}
				return m_WheelCollider;
			}
		}

		public Rigidbody RB
		{
			get
			{
				if (m_RB == null)
				{
					m_RB = WheelCollider.attachedRigidbody;
				}
				return m_RB;
			}
		}

		public void UpdateStiffness (float forward, float sideways)
		{
			var forwardFriction = WheelCollider.forwardFriction;
			var sidewaysFriction = WheelCollider.sidewaysFriction;

			forwardFriction.stiffness = forward;
			sidewaysFriction.stiffness = sideways;

			WheelCollider.forwardFriction = forwardFriction;
			WheelCollider.sidewaysFriction = sidewaysFriction;
		}

		public void UpdateConfig ()
		{
			UpdateConfig (WheelConfig);
		}

		public void UpdateConfig (PG_WheelColliderConfig newConfig)
		{
			if (RB == null)
			{
				Debug.LogError ("WheelCollider without attached RigidBody");
				return;		
			}
			WheelConfig.ForwardFriction = newConfig.ForwardFriction;
			WheelConfig.SidewaysFriction = newConfig.SidewaysFriction;

			if (newConfig.IsFullConfig)
			{
				float springValue = Mathf.Lerp(minSpring, maxSpring, newConfig.Spring);
				float damperValue = Mathf.Lerp(minDamper, maxDamper, newConfig.Damper);

				JointSpring spring = new JointSpring();
				spring.spring = springValue;
				spring.damper = damperValue;
				spring.targetPosition = newConfig.TargetPoint;

				WheelCollider.mass = newConfig.Mass;
				WheelCollider.radius = newConfig.Radius;
				WheelCollider.wheelDampingRate = newConfig.WheelDampingRate;
				WheelCollider.suspensionDistance = newConfig.SuspensionDistance;
				WheelCollider.forceAppPointDistance = newConfig.ForceAppPointDistance;
				WheelCollider.center = newConfig.Center;
				WheelCollider.suspensionSpring = spring;
			}

			WheelFrictionCurve forwardFriction = new WheelFrictionCurve();
			forwardFriction.extremumSlip = Mathf.Lerp (minExtremumSlip, maxExtremumSlip, newConfig.ForwardFriction);
			forwardFriction.extremumValue = Mathf.Lerp (minExtremumValue, maxExtremumValue, newConfig.ForwardFriction);
			forwardFriction.asymptoteSlip = Mathf.Lerp (minAsymptoteSlip, maxAsymptoteSlip, newConfig.ForwardFriction);
			forwardFriction.asymptoteValue = Mathf.Lerp (minAsymptoteValue, maxAsymptoteValue, newConfig.ForwardFriction);
			forwardFriction.stiffness = 1;

			WheelFrictionCurve sidewaysFriction = new WheelFrictionCurve();
			sidewaysFriction.extremumSlip = Mathf.Lerp (minExtremumSlip, maxExtremumSlip, newConfig.SidewaysFriction);
			sidewaysFriction.extremumValue = Mathf.Lerp (minExtremumValue, maxExtremumValue, newConfig.SidewaysFriction);
			sidewaysFriction.asymptoteSlip = Mathf.Lerp (minAsymptoteSlip, maxAsymptoteSlip, newConfig.SidewaysFriction);
			sidewaysFriction.asymptoteValue = Mathf.Lerp (minAsymptoteValue, maxAsymptoteValue, newConfig.SidewaysFriction);
			sidewaysFriction.stiffness = 1;

			WheelCollider.forwardFriction = forwardFriction;
			WheelCollider.sidewaysFriction = sidewaysFriction;
		}


		public bool CheckFirstEnable ()
		{
			if (m_WheelCollider != null) return false;

			var sprigValue = (WheelCollider.suspensionSpring.spring - minSpring) / (maxSpring - minSpring);
			var damper = (WheelCollider.suspensionSpring.damper - minDamper) / (maxDamper - minDamper);
			var forwardFriction = (WheelCollider.forwardFriction.extremumValue - minExtremumValue) / (maxExtremumValue - minExtremumValue);
			var sidewaysFriction = (WheelCollider.sidewaysFriction.extremumValue - minExtremumValue) / (maxExtremumValue - minExtremumValue);

			WheelConfig = new PG_WheelColliderConfig ();
			WheelConfig.Mass = WheelCollider.mass;
			WheelConfig.Radius = WheelCollider.radius;
			WheelConfig.WheelDampingRate = WheelCollider.wheelDampingRate;
			WheelConfig.SuspensionDistance = WheelCollider.suspensionDistance;
			WheelConfig.ForceAppPointDistance = WheelCollider.forceAppPointDistance;
			WheelConfig.Center = WheelCollider.center;
			WheelConfig.TargetPoint = WheelCollider.suspensionSpring.targetPosition;
			WheelConfig.Spring = sprigValue;
			WheelConfig.Damper = damper;
			WheelConfig.ForwardFriction = forwardFriction;
			WheelConfig.SidewaysFriction = sidewaysFriction;

			return true;
		}

		//Spring constants
		const float minSpring = 0;
		const float maxSpring = 60000;
		const float minDamper = 0;
		const float maxDamper = 10000;

		//Minimum friction constants
		const float minExtremumSlip = 0.4f;
		const float minExtremumValue = 0.7f;
		const float minAsymptoteSlip = 0.6f;
		const float minAsymptoteValue = 0.65f;

		//Maximum friction constants
		const float maxExtremumSlip = 0.4f;
		const float maxExtremumValue = 4.5f;
		const float maxAsymptoteSlip = 0.6f;
		const float maxAsymptoteValue = 4f;
	}

	[System.Serializable]
	public struct PG_WheelColliderConfig
	{
		[SerializeField] bool IsFoldout;
		public bool IsFullConfig;

		public float Mass;
		public float Radius;
		public float WheelDampingRate;
		public float SuspensionDistance;
		public float ForceAppPointDistance;
		public Vector3 Center;
		
		//Suspension spring
		public float Spring;
		public float Damper;
		public float TargetPoint;

		//Frictions;
		public float ForwardFriction;
		public float SidewaysFriction;
	}

	/// <summary>
	/// Custom FullField Attribute 
	/// </summary>
	[System.AttributeUsage (System.AttributeTargets.Field)]
	public class FullField :PropertyAttribute { }

}
