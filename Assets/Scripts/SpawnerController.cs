using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    
	public GameObject prototype;
	public int maxCount;
	public float range; // distance
	private int count = 0;
	private float delayTime = 1f;
	private bool isSpawningPaused = false;

	void Increase()
	{
		Debug.Log("Increase");
		count--;
		if(isSpawningPaused)
		{
			Debug.Log("Start Task by Increase fn");
			StartCoroutine("Task");
		}
	}

	void Spawn() {
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
		StartCoroutine("Task");
	}




}
