using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class RBMovement : MonoBehaviour
{
    //Public Vars
    public float maxSpeed;
    public float movementSpeed;

    //Private Vars
    private Vector3 startPos;
    public Rigidbody rb;

    //Collider Information
    private CapsuleCollider capsuleCollider;
    public Vector3 center = Vector3.zero;
    public float radius;
    public float height;

    //Custom Cursor Information
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        startPos = transform.position;
        //Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f), cursorMode);
        rb = GetComponent<Rigidbody>();
        //capsuleCollider = new CapsuleCollider
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Debug.Break();
        // Movement & limiting the speed of the RigidBody 
        float forwardSpeed = movementSpeed * Input.GetAxis("Vertical");
        float leftSpeed = movementSpeed * Input.GetAxis("Horizontal");
        Vector3 movementVelocity = new Vector3(leftSpeed, 0, forwardSpeed);
        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed)
            movementVelocity = movementVelocity.normalized * maxSpeed;
        rb.AddForce(movementVelocity, ForceMode.Acceleration);
    }

    public void ResetPosition() => gameObject.transform.position = startPos;

    private void OnValidate()
    {
        if (maxSpeed < 0.1f) maxSpeed = 0.1f;
        if (movementSpeed < 0.1f) movementSpeed = 0.1f;
        if (height < 0.1f) height = 0.1f;
        if (radius < 0.1f) radius = 0.1f;
    }
}