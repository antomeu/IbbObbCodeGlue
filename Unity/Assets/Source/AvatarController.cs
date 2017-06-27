using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    #region Assigned in Unity
    public Player Player;
    public Rigidbody Rigidbody;
    public Collider JumpCollider;
    #endregion

    public float JumpForce = 50f;
    public int MaxVerticalSpeed = 3;
    public float MoveForce = 5f;
    public float MaxMoveSpeed = 2f;
    public float AirControl = 0.1f;

    public int GravityDirection //Is positive if gravity is pulling down, negative if gravity is pulling up
    {
        get { return _gravityDirection; }
        set
        {
            if (_gravityDirection != value)
            {
                BoostOnGravityChange();
                _gravityDirection = value;
            }
        }
    }
    private int _gravityDirection;
    private bool _isGrounded;
    
    void FixedUpdate()
    {
        float jump = 0;
        float horizontal = 0;
        if (Player == Player.Obb)
        {
            jump = Input.GetAxis("Jump1");
            horizontal = Input.GetAxis("Horizontal1");
        }
        if (Player == Player.Ibb)
        {
            jump = Input.GetAxis("Jump2");
            horizontal = Input.GetAxis("Horizontal2");
        }

        if (jump >= 0.5)
            Jump(jump);
        if (Mathf.Abs(horizontal) > 0.1)
            Walk(horizontal);

        ApplyGravity();

        RotateOnGravitySwap();

        Debug.Log("Player: " + Player.ToString() + " | jump: " + jump.ToString() + " | Isgrounded: " + _isGrounded + " | velocity: " + Rigidbody.velocity.y);
    }

    private void Jump(float jump)
    {
        if (_isGrounded && Rigidbody.velocity.y < MaxVerticalSpeed)
        {
            Rigidbody.AddForce(GravityDirection * JumpForce * Vector3.up, ForceMode.VelocityChange);
        }
    }

    private void Walk(float horizontal)
    {
        if (Mathf.Abs(Rigidbody.velocity.x) <= MaxMoveSpeed)
        {
            if (_isGrounded)
                Rigidbody.AddForce(horizontal * MoveForce * Vector3.right);
            else
                Rigidbody.AddForce(horizontal * AirControl * MoveForce * Vector3.right);
        }
    }

    private void ApplyGravity()
    {
        GravityDirection = Mathf.RoundToInt(Mathf.Sign(transform.position.y));
        Rigidbody.AddForce(GravityDirection * Globals.Gravity * Vector3.up);
    }

    private void BoostOnGravityChange()
    {
        if (Mathf.Abs(Rigidbody.velocity.y) < 4f)
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 4 * Rigidbody.velocity.normalized.y, 0);
    }

    private void RotateOnGravitySwap()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.forward, GravityDirection * Vector3.up), 10f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger) // Makes sure it is only called when Trigger is owned by self
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            _isGrounded = false;
        }
    }
}