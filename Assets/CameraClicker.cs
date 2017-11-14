using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				RenderCube renderCube = hit.transform.gameObject.GetComponent<RenderCube>();
				if (renderCube != null)
				{
					CubeHandler.SelectCube(renderCube.id);
				}
			}
		}
	}
}
