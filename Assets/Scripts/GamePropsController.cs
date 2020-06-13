using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePropsController : MonoBehaviour
{
	private float rotateSpeed = 30;
    private string propId = "gun1";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.Self);
    }

    void OnTriggerEnter(Collider collider)
    {
    	Debug.Log("Enter!!!");
        GameObject.Destroy(gameObject);
        collider.gameObject.SendMessage("OnPickProps", propId);
    }


    void OnTriggerExit(Collider collider)
    {

    }
}
