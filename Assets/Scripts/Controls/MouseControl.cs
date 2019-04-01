using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseControl : MonoBehaviour
{
	public double Gravity = 1.62;
	public double Thrust = 1;


	public float speed = 3.5f;
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
		if (Input.GetKey(KeyCode.Space))
		{
			MainBody.AddForce(new Vector3(0, 3, 0));
		}


		MainBody.AddForce(this.transform.forward);
		
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * rotationSpeed * Time.deltaTime;
		rotX += mouseY * rotationSpeed * Time.deltaTime;
		
		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;
		

	}
}
