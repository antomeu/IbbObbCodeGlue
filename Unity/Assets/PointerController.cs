using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {
    public Camera Camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Plane InputPlane = new Plane(transform.forward, 40 * Vector3.forward);
        Ray mouseRay = Camera.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (InputPlane.Raycast(mouseRay, out rayDistance))
            transform.position = mouseRay.GetPoint(rayDistance);
    }
}
