using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    #region Set in Unity
    public Player Player;
    public Rigidbody Rigidbody;
    public Collider JumpCollider;
    #endregion
    public float JumpForce = 5f;
    public float MoveForce = 5f;
    public float MaxMoveSpeed = 2f;
    public float AirControl = 0.1f;
    public float GravityDirection = 1;
    private bool IsGrounded = false;

    void FixedUpdate()
    {
        float jump =0;
        float horizontal = 0;
        if (Player == Player.Player1)
        {
            jump = Input.GetAxis("Jump1");
            horizontal = Input.GetAxis("Horizontal1");
        }
        if (Player == Player.Player2)
        {
            jump = Input.GetAxis("Jump2");
            horizontal = Input.GetAxis("Horizontal2");
        }

        if (jump !=0)
            Jump(jump);
        if (horizontal != 0)
            Walk(horizontal);
        UpdateGravity();

        RotateOnGravitySwap();
    }

    private void Jump(float jump)
    {
        if (IsGrounded)
            Rigidbody.AddForce(GravityDirection * jump* JumpForce * Vector3.up, ForceMode.VelocityChange);
    }

    private void Walk(float horizontal)
    {
        if (Mathf.Abs(Rigidbody.velocity.x) <= MaxMoveSpeed)
        {
            if (IsGrounded)
                Rigidbody.AddForce(horizontal * MoveForce * Vector3.right);
            else
                Rigidbody.AddForce(horizontal * AirControl * MoveForce * Vector3.right);
        }
    }

    private void UpdateGravity()
    {
        GravityDirection = Mathf.Sign(transform.position.y);
        Rigidbody.AddForce(GravityDirection * Globals.Gravity * Vector3.up);
    }

    private void RotateOnGravitySwap()
    {
        if (GravityDirection == 1)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.forward, Vector3.up), 10f);
        if (GravityDirection == -1)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.forward, Vector3.down), 10f);
    }


    private void OnTriggerEnter()
    {
        IsGrounded = true;
    }

    private void OnTriggerExit()
    {
        IsGrounded = false;
    }
}