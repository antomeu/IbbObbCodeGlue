using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    #region Set in Unity
    public Player Player;
    public Rigidbody Rigidbody;
    #endregion
    public float JumpForce = 5f;
    public float MoveForce = 5f;
    public float GravityDirection = 1;

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

        Jump(jump);
        Walk(horizontal);
        UpdateGravity();
    }

    private void Jump(float jump)
    {
        Rigidbody.AddForce(GravityDirection * jump* JumpForce * Vector3.up, ForceMode.Impulse);
    }

    private void Walk(float horizontal)
    {
        Rigidbody.AddForce(horizontal * MoveForce* Vector3.right);
    }

    private void UpdateGravity()
    {
        GravityDirection = Mathf.Sign(transform.position.y);
        Rigidbody.AddForce(GravityDirection * Globals.Gravity * Vector3.up);
    }
}