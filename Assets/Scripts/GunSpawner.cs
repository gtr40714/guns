using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public GameObject prototype;
	public int maxCount = 1;
	public float range; // distance
	private int count = 0;
	private float delayTime = 1f;
	private bool isSpawningPaused = false;
	private GameObject m249;

	void Increase()
	{
		m249 = GameObject.FindWithTag("weapon");
		Debug.Log("Increase");
		count--;
		if(Input.GetMouseButtonDown(1))
		{
			GameObject.Destroy(m249);
			Debug.Log("Start Task by Increase fn");
			StartCoroutine("Task");
		}
	}

	void Spawn()
	 {
		Vector3 spPoint = transform.position + new Vector3(1, 0, 1) * Random.value * range;
		GameObject newObject = GameObject.Instantiate(prototype, spPoint, Quaternion.identity);
		newObject.SendMessage("SetSpawner", this);
		count++;
	}

	IEnumerator Task() 
	{
		while(count < maxCount)
		{
			Spawn();
	    	yield return new WaitForSeconds(delayTime);
		}
		isSpawningPaused = true;
	}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
