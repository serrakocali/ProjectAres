using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PG_Physics.Wheel {

	[CustomEditor (typeof (PG_WheelCollider)), CanEditMultipleObjects]
	public class PG_WheelColliderEditor :Editor
	{
		public override void OnInspectorGUI ()
		{

			EditorGUI.BeginChangeCheck ();
			
			base.OnInspectorGUI ();

			if (EditorGUI.EndChangeCheck ())
			{
				for (int i = 0; i < targets.Length; i++)
				{
					(targets[i] as PG_WheelCollider).UpdateConfig ();
				}
			}
		}

		void OnEnable ()
		{
			for (int i = 0; i < targets.Length; i++) 
			{
				if ((targets[i] as PG_WheelCollider).CheckFirstEnable())
				{
					serializedObject.SetIsDifferentCacheDirty ();
					serializedObject.Update ();
				}
			}
		}
	}

	[CustomPropertyDrawer (typeof (FullField))]
	public class FullPropertyPG_WheelColliderConfigDrawer :PG_WheelColliderConfigDrawer
	{
		protected override bool IsFullProperty { get { return true; } }
	}

	[CustomPropertyDrawer (typeof (PG_WheelColliderConfig))]
	public class PG_WheelColliderConfigDrawer :PropertyDrawer
	{
		protected virtual bool IsFullProperty { get { return false; } }

		float LineHeight = 18;
		float Space = 4;
		float LineIndent = 8;

		Rect Rect;

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.LabelField (position, GUIContent.none, EditorStyles.helpBox);

			float x = position.x + Space + LineIndent;
			float y = position.y + Space;
			float inspectorWidth = position.width - Space * 2 - LineIndent;

			Rect = new Rect (x, y, inspectorWidth, LineHeight);

			EditorGUI.BeginProperty (position, label, property);

			bool isFoldout = false;

			if (!IsFullProperty)
			{
				Rect.x += LineIndent;
				var isFoldoutField = property.FindPropertyRelative ("IsFoldout");
				isFoldoutField.boolValue = !EditorGUI.Foldout (Rect, !isFoldoutField.boolValue, label);
				isFoldout = isFoldoutField.boolValue;
				Rect.y += LineHeight;
				Rect.x -= LineIndent;
			}
			else
			{
				DrawLabel (label.text);
			}

			if (isFoldout)
			{
				EditorGUI.EndProperty ();
				return;
			}

			DrawSpace ();

			var isFullConfig = property.FindPropertyRelative ("IsFullConfig");

			var mass = property.FindPropertyRelative ("Mass");
			var radius = property.FindPropertyRelative ("Radius");
			var wheelDampingRate = property.FindPropertyRelative ("WheelDampingRate");
			var suspensionDistance = property.FindPropertyRelative ("SuspensionDistance");
			var forceAppPointDistance = property.FindPropertyRelative ("ForceAppPointDistance");
			var center = property.FindPropertyRelative ("Center");

			var spring = property.FindPropertyRelative ("Spring");
			var damper = property.FindPropertyRelative ("Damper");
			var targetPoint = property.FindPropertyRelative ("TargetPoint");

			var sidewaysFriction = property.FindPropertyRelative ("SidewaysFriction");
			var forwardFriction = property.FindPropertyRelative ("ForwardFriction");

			bool needShowFullProperty;

			if (IsFullProperty)
			{
				needShowFullProperty = true;
				isFullConfig.boolValue = true;
			}
			else
			{
				DrawBoolField ("Is Full Config", isFullConfig, withoutLineIndent: true);
				needShowFullProperty = isFullConfig.boolValue;
				if (needShowFullProperty)
				{
					DrawSpace ();
				}
			}

			if (needShowFullProperty)
			{
				DrawFloatField ("Mass", mass);
				DrawFloatField ("Radius", radius);
				DrawFloatField ("Wheel Damping Rate", wheelDampingRate);
				DrawFloatField ("Suspension Distance", suspensionDistance);
				DrawFloatField ("Force App Point Distance", forceAppPointDistance);
				DrawVector3Field ("Center", center);

				DrawSpace ();
				DrawLabel ("Suspension Spring");

				DrawRangeFloatField ("Spring", spring);
				DrawRangeFloatField ("Damper", damper);
				DrawFloatField ("TargetPoint", targetPoint);
			}

			DrawSpace ();
			DrawLabel ("Frictions");
			DrawRangeFloatField ("Forward Friction", forwardFriction, toolTip: "0 - Minimum friction, 1 - Maximum friction");
			DrawRangeFloatField ("Sideways Friction", sidewaysFriction, toolTip: "0 - Minimum friction, 1 - Maximum friction");

			EditorGUI.EndProperty ();
		}

		private void DrawFloatField (string fieldName, SerializedProperty property, bool withoutLineIndent = false)
		{
			if (withoutLineIndent)
			{
				Rect.x -= LineIndent;
			}
			var content = new GUIContent (fieldName);
			property.floatValue = EditorGUI.FloatField (Rect, content, property.floatValue);
			Rect.y += LineHeight;

			if (withoutLineIndent)
			{
				Rect.x += LineIndent;
			}
		}

		private void DrawRangeFloatField (string fieldName, SerializedProperty property,
			bool withoutLineIndent = false, float minValue = 0, float maxValue = 1, string toolTip = "0 - Minimum value, 1 - Maximum value")
		{
			if (withoutLineIndent)
			{
				Rect.x -= LineIndent;
			}

			var content = new GUIContent (fieldName, toolTip);
			property.floatValue = EditorGUI.Slider (Rect, content, property.floatValue, minValue, maxValue);
			Rect.y += LineHeight;

			if (withoutLineIndent)
			{
				Rect.x += LineIndent;
			}
		}

		private void DrawBoolField (string fieldName, SerializedProperty property, bool withoutLineIndent = false)
		{
			if (withoutLineIndent)
			{
				Rect.x -= LineIndent;
			}

			var content = new GUIContent (fieldName);
			property.boolValue = EditorGUI.Toggle (Rect, content, property.boolValue);
			Rect.y += LineHeight;

			if (withoutLineIndent)
			{
				Rect.x += LineIndent;
			}
		}

		private void DrawVector3Field (string fieldName, SerializedProperty property, bool withoutLineIndent = false)
		{
			if (withoutLineIndent)
			{
				Rect.x -= LineIndent;
			}

			var content = new GUIContent (fieldName);
			property.vector3Value = EditorGUI.Vector3Field (Rect, content, property.vector3Value);
			Rect.y += LineHeight;

			if (withoutLineIndent)
			{
				Rect.x += LineIndent;
			}
		}

		private void DrawSpace (int spaceCount = 1)
		{
			Rect.y += Space * spaceCount;
		}

		private void DrawLabel (string LabelName, bool withoutLineIndent = true)
		{
			if (withoutLineIndent)
			{
				Rect.x -= LineIndent;
			}

			EditorGUI.LabelField (Rect, LabelName);
			Rect.y += LineHeight;

			if (withoutLineIndent)
			{
				Rect.x += LineIndent;
			}
		}

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
		{
			float lines = 0;
			float allSpace = 0;

			if (IsFullProperty)
			{
				lines = LineHeight * 14;
				allSpace = Space * 5;
			}
			else
			{
				bool isFoldout = property.FindPropertyRelative("IsFoldout").boolValue;
				if (isFoldout)
				{
					lines = LineHeight * 1;
					allSpace = Space * 2;
				}
				else
				{
					lines = LineHeight * 5;
					allSpace = Space * 4;

					bool isFullConfig = property.FindPropertyRelative("IsFullConfig").boolValue;

					if (isFullConfig)
					{
						lines += LineHeight * 10;
						allSpace += Space * 2;
					}
				}
			}


			return lines + allSpace;
		}
	}
}
