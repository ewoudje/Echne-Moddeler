using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var dir = transform.position - Vector3.zero; // find current direction
		var angle = Vector3.Angle(Vector3.forward, dir); // find current angle
		if (Vector3.Cross(Vector3.forward, dir).y < 0) angle = -angle;
		// define rotation angle according to tourchLeft/tourchRight:
		float rotAngle;
		rotAngle = 90;
		// calculate the clamped angle after rotation:
		var newAngle = Mathf.Clamp(angle + rotAngle, 180, -180);
		// find how much you can rotate without violating limits:
		rotAngle = newAngle - angle;
		// rotate it:
		transform.RotateAround(Vector3.zero, Vector3.up, rotAngle);
	}
}
