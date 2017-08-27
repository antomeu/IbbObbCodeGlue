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
    public Transform Pivot;

    public LineRenderer Laser;
    public Transform LaserPoint;
    #endregion

    float RotateScreenZone = 0.15f;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootProjectile();
        MoveCanon();
        ManageLaserPointer();
        RotatePivot();
    }

    private void ManageLaserPointer()
    {
        RaycastHit hit;
        if (Physics.Raycast(Laser.transform.position + 1 * Laser.transform.up, Laser.transform.up, out hit, 30))
        {
            Laser.SetPosition(1, (hit.distance + 10) * Vector3.up);
            LaserPoint.gameObject.SetActive(true);
            LaserPoint.position = hit.point;
            LaserPoint.forward = hit.normal;
        }
        else
        {
            LaserPoint.gameObject.SetActive(false);

            Laser.SetPosition(1, 60 * Vector3.up);
        }
    }

    private void RotatePivot()
    {
        float RotateSpeed = 0;
        if (Screen.width * RotateScreenZone - Input.mousePosition.x > 0)
            RotateSpeed = Screen.width * RotateScreenZone - Input.mousePosition.x;
        if (Screen.width * (1 - RotateScreenZone) - Input.mousePosition.x < 0)
            RotateSpeed = Screen.width * (1 - RotateScreenZone) - Input.mousePosition.x;

        Pivot.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
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