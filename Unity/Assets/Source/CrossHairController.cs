using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairController : MonoBehaviour {

    #region SET IN UNITY
    public Camera Camera;
    //public Plane InputPlane;
    
    #endregion
    


    void Update ()
    {
        Plane InputPlane = new Plane(transform.forward, Vector3.zero);
        Ray mouseRay = Camera.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (InputPlane.Raycast(mouseRay, out rayDistance))
            transform.position = mouseRay.GetPoint(rayDistance);
    }
}
