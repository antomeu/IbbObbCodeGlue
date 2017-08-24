using System;
using UnityEngine;


public class CannonController : MonoBehaviour
{
    #region Assigned in Unity
    public float ShootForce = 50f;
    public GameObject Projectile;
    public GameObject Canon;
    public GameObject CrossHair;

    #endregion




    public void Update()
    {
        if (Input.GetMouseButtonDown(0));
            ShootProjectile();
        MoveCanon();
    }

    private void MoveCanon()
    {
        throw new NotImplementedException();
    }

    public void ShootProjectile()
    {
        
    }

}