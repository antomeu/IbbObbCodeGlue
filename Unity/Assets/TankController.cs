using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {
    public WheelCollider WheelFront;
    public WheelCollider WheelBack;
    public float TorqueMultiplyer = 1000;
    public Rigidbody Rigidbody;

    public Rigidbody Projectile;
    public Transform InstantiateTransform;
    public ParticleSystem MuzzleSmoke;
    public Animator CamerAnimator;
    public Animator CannonAnimator;

    public float ShootForce = 1000;

    public Transform CanonBase;

    public Transform Pointer;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
	
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            ShootProjectile();

        CanonBase.LookAt(Pointer);
    }
	// Update is called once per frame
	void FixedUpdate () {



        WheelFront.motorTorque = TorqueMultiplyer * Input.GetAxis("Horizontal");

        WheelBack.motorTorque = TorqueMultiplyer * Input.GetAxis("Horizontal");

        Rigidbody.AddForce(1000 * Input.GetAxis("Vertical") * Vector3.up, ForceMode.Impulse);
    }

    public void ShootProjectile()
    {
        Rigidbody CannonBallClone;
        CannonBallClone = (Rigidbody)Instantiate(Projectile, InstantiateTransform.position, InstantiateTransform.rotation);
        CannonBallClone.AddForce(ShootForce * CanonBase.transform.forward);
        Destroy(CannonBallClone.gameObject, 6f);
        MuzzleSmoke.Play();
        CamerAnimator.SetTrigger("Shoot");
        CannonAnimator.SetTrigger("Shoot");

        Rigidbody.AddForce(-40000 * transform.forward);
    }
}
