using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private int velocity;
	private int runSpeed = 10;
	private int speed = 2;
	private Vector3 dir = Vector3.zero;
	private CharacterController chController;

	void Awake()
	{
		chController = GetComponent<CharacterController>();
	}

	void Update()
	{
		updateByObject();
		float rot = Input.GetAxis("Mouse X");
		// transform.rotation.y += rot;
		transform.rotation = Quaternion.Euler(transform.eulerAngles.x, rot + transform.eulerAngles.y, transform.eulerAngles.z);
	}

	Vector3 calcForward() {
		// return transform.forward;
		return Vector3.forward;
	}

	Vector3 calcBackward() {
		return -calcForward();
	}
	Vector3 calcLeft() {
		// return -transform.right;
		return Vector3.left;
	}
	Vector3 calcRight() {
		return -calcLeft();
	}

	void updateByObject() {
		if(Input.GetKeyDown("w"))
	    {
			dir = calcForward();
	    }
	    else if(Input.GetKeyUp("w"))
	    {
	    	dir = Vector3.zero;
	    }
	    else if(Input.GetKeyDown("s"))
	    {
			dir = calcBackward();
	    }
	    else if(Input.GetKeyUp("s"))
	    {
			dir = Vector3.zero;
	    }
	    if(Input.GetKeyDown("a"))
	    {
			dir += calcLeft();
	    }
	    else if(Input.GetKeyUp("a"))
	    {
	    	dir = Vector3.zero;
	    }
	    else if(Input.GetKeyDown("d"))
	    {
			dir += calcRight();
	    }
	    else if(Input.GetKeyUp("d"))
	    {
			dir = Vector3.zero;
	    }
	    dir = dir.normalized;
	    bool isControlKeyDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
	    if(isControlKeyDown)
	    {
	    	velocity = runSpeed;
	    } else
	    {
	    	velocity = speed;
	    }
	    // Debug.Log("Speed" + velocity.ToString());
	    // transform.Translate(dir * velocity * Time.deltaTime);
	    chController.Move(dir * velocity * Time.deltaTime);
	}

}
