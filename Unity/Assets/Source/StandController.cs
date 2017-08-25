using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandController : MonoBehaviour {

    #region set in Unity

    public GameObject Plane;


    #endregion

    public void DestroyStand()
    {
        Destroy(Plane, 0.5f);
        Destroy(this, 1f);
    }

}
