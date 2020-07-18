using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{

	public string nextScene;
	// private AssetBundle myLoadedAssetBundle;
	// private string[] scenePaths;
    // Start is called before the first frame update
    // void Start()
    // {
    //     myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/Scenes");
    // 	scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    
    // }


    void OnTriggerEnter(Collider collider) {
    	SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
    	GameObject.Destroy(gameObject);
    }

    // void OnGUI()
    // {
    //     if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
    //     {
    //         Debug.Log("Scene2 loading: " + scenePaths[0]);
    //         SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    //     }
    // }
}
