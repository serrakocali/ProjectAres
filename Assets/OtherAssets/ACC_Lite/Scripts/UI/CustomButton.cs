using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

/// <summary>
/// base Button, for added actions "onPointerDown" and "onPointerUp".
/// </summary>
public class CustomButton :Button
{
	public bool ButtonIsPressed { get { return base.IsPressed (); } }
}
