using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectController : MonoBehaviour {

    #region set in Unity
    public GameObject StandPrefab;
    public StandController StandController;
    #endregion

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisin!");
        Invoke("InstantiateStand",1f);
            StandController.DestroyStand();
    }

    void InstantiateStand()
    {
        Instantiate(StandPrefab, Vector3.zero, Quaternion.identity);
    }
}
