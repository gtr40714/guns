using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	private Transform lastHitTrans;
	private Vector3 lastHitPoint;
	private GameObject camObject;
	private Camera cam;
  private Gun gun = PropCreator.CreateGunM249(5);
  private AudioSource audio;

	int CalculateAtkValue() {
		return gun.AttackValue + (int)(Random.value * gun.AttackRange);
	}

	void Awake()
	{
		camObject = GameObject.FindWithTag("MainCamera");
		cam = camObject.GetComponent<Camera>();
    audio = GetComponent<AudioSource>();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void updateHitTarget()
    {
      RaycastHit hit;
      // Vector3 screenPosition = Input.mousePosition;
      Vector3 screenPosition = new Vector3(Screen.width * .5f, Screen.height * .5f, 0);
      Ray ray = cam.ScreenPointToRay(screenPosition);
      Vector3 direction = ray.direction;
      Debug.DrawRay(cam.transform.position, (direction) * 10, Color.green);
      Vector3 point = cam.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, cam.nearClipPlane));
      if (Physics.Raycast(point, direction, out hit, Mathf.Infinity))
      {
      	// if(hit.transform.tag == "Terrain")
      	// {
      		if(lastHitTrans != hit.transform)
      		{
      			lastHitTrans = hit.transform;
      			// Debug.Log("Name: " + lastHitTrans.name);
      		}
      		lastHitPoint = hit.point;
      		// Debug.Log("Point: " + lastHitPoint);
          transform.root.gameObject.SendMessage("focusTarget");
      	// }
      }
      else
      {
      	if(lastHitTrans)
      	{
      		// Debug.Log("No hit target");
      		lastHitTrans = null;
          transform.root.gameObject.SendMessage("blurTarget");
      	}
      }
    }

    void detectInputAndMove()
    {
    	if (Input.GetMouseButtonDown(0))
   		{
   			if(lastHitTrans)
   			{
            Debug.Log("Name: " + lastHitTrans.name);
            Debug.Log("Point: " + lastHitPoint);
            if(lastHitTrans.gameObject)
            {
                lastHitTrans.gameObject.SendMessage("ApplyDamage", CalculateAtkValue());
                // audio.Play();
            }
   			}
        audio.Play();
    	}
    }

    // Update is called once per frame
    void Update()
    {
    	// Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
     //    Debug.DrawRay(transform.position, forward, Color.green);
    	updateHitTarget();
    	detectInputAndMove();
   	}
}
