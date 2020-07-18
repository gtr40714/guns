using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
	None,
    Left,
    Right,
    Forward,
    Backward,
}

public class PlayerController : MonoBehaviour
{

	private int velocity;
	private int runSpeed = 10;
	private int speed = 2;
	private Vector3 dir = Vector3.zero;
	private CharacterController chController;
	private float gravity = 10.0f;
	private Direction dirLR = Direction.None, dirFB = Direction.None;

	void Awake()
	{
		chController = GetComponent<CharacterController>();
	}

	void Update()
	{
		float rot = Input.GetAxis("Mouse X");
		// transform.rotation.y += rot;
		transform.rotation = Quaternion.Euler(transform.eulerAngles.x, rot + transform.eulerAngles.y, transform.eulerAngles.z);
		updateByObject();
	}

	Vector3 calcForward() {
		return transform.forward;
		// return Vector3.forward;
	}

	Vector3 calcBackward() {
		return -calcForward();
	}
	Vector3 calcLeft() {
		return -transform.right;
		// return Vector3.left;
	}
	Vector3 calcRight() {
		return -calcLeft();
	}

	private void detectDirection() {
		if(Input.GetKeyDown("w"))
	    {
			dirFB = Direction.Forward;
	    }
	    else if(Input.GetKeyUp("w"))
	    {
	    	dirFB = Direction.None;
	    }
	    else if(Input.GetKeyDown("s"))
	    {
			dirFB = Direction.Backward;
	    }
	    else if(Input.GetKeyUp("s"))
	    {
			dirFB = Direction.None;
	    }
	    if(Input.GetKeyDown("a"))
	    {
			dirLR = Direction.Left;
	    }
	    else if(Input.GetKeyUp("a"))
	    {
	    	dirLR = Direction.None;
	    }
	    else if(Input.GetKeyDown("d"))
	    {
			dirLR = Direction.Right;
	    }
	    else if(Input.GetKeyUp("d"))
	    {
			dirLR = Direction.None;
	    }
	}

	private void applyDirectionLR() {
		switch(dirLR) {
			case Direction.Right:
			dir += calcRight();
			break;
			case Direction.Left:
			dir += calcLeft();
			break;
			case Direction.None:
			// dir += Vector3.zero;
			break;
			default:
			// dir += Vector3.zero;
			break;
		}
	}

	private void applyDirectionFB() {
		switch(dirFB) {
			case Direction.Forward:
			dir += calcForward();
			break;
			case Direction.Backward:
			dir += calcBackward();
			break;
			case Direction.None:
			// dir += Vector3.zero;
			break;
			default:
			// dir += Vector3.zero;
			break;
		}
	}

	void updateByObject() {

		detectDirection();
		dir = Vector3.zero;
		applyDirectionLR();
		applyDirectionFB();
	    dir = dir.normalized;
	    bool isControlKeyDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
	    if(isControlKeyDown)
	    {
	    	velocity = runSpeed;
	    } else
	    {
	    	velocity = speed;
	    }
	    if (!chController.isGrounded)
        {
            dir.y -= gravity * Time.deltaTime;
        } else {

        }
	    // Debug.Log("Speed" + velocity.ToString());
	    // transform.Translate(dir * velocity * Time.deltaTime);
	    chController.Move(dir * velocity * Time.deltaTime);
	}

}
