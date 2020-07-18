using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{

	public Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        // Material meterial = GetComponent<Material>();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetTexture("_MainTex", texture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
