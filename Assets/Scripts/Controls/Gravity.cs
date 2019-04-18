using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
	[Header("Motion")]
	public bool AplyGravity = true;
	public float GravityValue = 1.62f;
	public float Thrust = 1;
	public float Speed = 100f;


	private Rigidbody MainBody;


	// Start is called before the first frame update
	void Start()
	{
		MainBody = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
		if (AplyGravity)
		{
			print(-GravityValue * Time.deltaTime);
			//Aply gravity
			MainBody.AddRelativeForce(new Vector3(0, -GravityValue, 0));
		}

		//MainBody.AddRelativeForce(new Vector3(0, 0, 2));


		if (Input.GetKey(KeyCode.Space))
		{
			MainBody.AddRelativeForce(new Vector3(0, Thrust, 0));
		}

		this.transform.rotation = Quaternion.Euler(MainBody.GetRelativePointVelocity(new Vector3(0, 0, 0)));
	}
}
