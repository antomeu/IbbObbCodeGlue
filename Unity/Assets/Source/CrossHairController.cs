using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairController : MonoBehaviour {

    #region SET IN UNITY
    public Camera Camera;
    #endregion
    Plane InputPlane = new Plane(Vector3.forward, Vector3.zero);


    void Update ()
    {
        Ray mouseRay = Camera.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (InputPlane.Raycast(mouseRay, out rayDistance))
            transform.position = mouseRay.GetPoint(rayDistance);
    }
}
