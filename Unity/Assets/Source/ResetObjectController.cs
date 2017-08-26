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
    public GameObject TextMesh;
    #endregion

    bool CanReset = true;
    float TimeBeforeNextReset = Globals.ResetTime;

    void Start()
    {
        InstantiateStand();
    }

    void Update()
    {
        if (!CanReset)
        {
            if (TimeBeforeNextReset > 0)
                TimeBeforeNextReset -= Time.deltaTime;
            else
                CanReset = true;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (CanReset)
        {
            ResetSequence();
            TimeBeforeNextReset = Globals.ResetTime;
        }

    }

    void ResetSequence()
    {
        var FloorClone = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject item in FloorClone)
        {
            Destroy(item, Globals.ResetTime / 8);
        }

        var StandClone = GameObject.FindGameObjectsWithTag("Stand");
        foreach (GameObject item in StandClone)
        {
            Destroy(item, Globals.ResetTime);
        }

        TextMesh.SetActive(false);
        CanReset = false;
        ParticleSystem.Play();
        Invoke("InstantiateStand", 2f);
    }

    void InstantiateStand()
    {
        
        Instantiate(StandPrefab, StandParent);
        
        Instantiate(StandFloor, StandParent);
        
        TextMesh.SetActive(true);
    }
}
