using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ResetObjectController : MonoBehaviour {

    #region set in Unity
    public GameObject StandPrefab;
    public GameObject StandFloor;
    public Transform StandParent;
    public ParticleSystem ParticleSystem;

    #endregion

    GameObject FloorClone;
    GameObject StandClone;
    void Start()
    {
        InstantiateStand();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        Destroy(FloorClone,0.25f);
        Destroy(StandClone.gameObject, 3f);
        ParticleSystem.Play();
        Invoke("InstantiateStand", 2f);
    }

    void InstantiateStand()
    {
        ;
        StandClone = Instantiate(StandPrefab, StandParent);

        
        FloorClone = Instantiate(StandFloor, StandParent);
    }
}
