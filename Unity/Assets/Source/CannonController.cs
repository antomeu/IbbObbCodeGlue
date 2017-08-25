using System;
using UnityEngine;


public class CannonController : MonoBehaviour
{
    #region Assigned in Unity
    public float ShootForce = 10f;
    public Rigidbody Projectile;
    public Transform CrossHair;
    public Transform InstantiateTransform;
    public ParticleSystem MuzzleSmoke;
    public Animator CamerAnimator;
    public Animator CannonAnimator;

    #endregion




    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootProjectile();
        MoveCanon();
    }

    private void MoveCanon()
    {
        transform.LookAt(CrossHair);
    }

    public void ShootProjectile()
    {
        Rigidbody CannonBallClone;
        CannonBallClone = (Rigidbody)Instantiate(Projectile, InstantiateTransform.position,InstantiateTransform.rotation);
        CannonBallClone.AddForce(ShootForce * transform.forward);
        Destroy(CannonBallClone.gameObject, 6f);
        MuzzleSmoke.Play();
        CamerAnimator.SetTrigger("Shoot");
        CannonAnimator.SetTrigger("Shoot");
    }

}