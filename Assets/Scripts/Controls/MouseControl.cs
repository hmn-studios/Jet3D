using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseControl : MonoBehaviour
{
	[Header("Motion")]
	public bool AplyGravity = true;
	public float Gravity = 1.62f;
	public float Thrust = 1;
	public float Speed = 100f;


	[Header("Rotation")]
	public float rotationSpeed = 150.0f;
	private float rotY = 0.0f;
	private float rotX = 0.0f;
	public float clampAngle = 120.0f;


	private Rigidbody MainBody;


    // Start is called before the first frame update
    void Start()
	{
		MainBody = this.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
	{

	}

	void FixedUpdate()
	{
		if (AplyGravity)
		{
			//Aply gravity
			MainBody.AddRelativeForce(new Vector3(0, -Gravity, 0));
		}

		if (Input.GetAxis("Thurst") > 0)
		{
			MainBody.AddRelativeForce(new Vector3(0, 3, 0));
		}

		//Aply forward motion

		Vector3 move = this.transform.forward * Speed * Time.deltaTime;
		Vector3 actualPosition = this.transform.position;
		this.transform.position = new Vector3(actualPosition.x + move.x, actualPosition.y, actualPosition.z + move.z);


		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * rotationSpeed * Time.deltaTime;
		rotX += mouseY * rotationSpeed * Time.deltaTime;
		
		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;
		

	}
}
