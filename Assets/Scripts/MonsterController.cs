using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

	private GameObject camObject;
	private int hp = 50;
    private SpawnerController spController;
    private GameObject target;
    private int velocity = 3;

	void Awake()
	{
		camObject = GameObject.FindWithTag("MainCamera");
        target = GameObject.FindWithTag("Player");
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     	// foreach(transform.MainCamera);
     	transform.LookAt(camObject.transform); 
        ChaseTarget();
    }

    void ChaseTarget()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if(dist > 15) {
            Vector3 dir = transform.position - target.transform.position;
            dir = dir.normalized;
            transform.Translate(dir * velocity * Time.deltaTime);
        }
        
    }

    void ApplyDamage(int dmg) {
    	Debug.Log("ApplyDamage!!!" + dmg.ToString());
    	hp -= dmg;
    	if(hp <= 0)
    	{
    		Die();
    	}
    }

    void Die()
    {
    	Debug.Log("Die!!!" + hp.ToString());
    	GameObject.Destroy(gameObject);
        if(this.spController)
        {
            this.spController.SendMessage("Increase");
        }
    }

    void SetSpawner(SpawnerController spController)
    {
        Debug.Log("SetSpawner!!!");
        this.spController = spController;
    }

}
