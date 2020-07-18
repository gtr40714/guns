using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
	public Texture chDefault;
	public Texture chAimed;
	private Texture crosshairTex;
	private Rect rect;
	private float texW = 64, texH = 64;

	void Awake() {
		blurTarget();
		// focusTarget();
	}

	private void focusTarget() {
		crosshairTex = chAimed;
		if(crosshairTex) {
			rect = new Rect((Screen.width - texW) * .5f, (Screen.height - texH) * .5f, texW, texH);
		}
	}

	private void blurTarget() {
		crosshairTex = chDefault;
		if(crosshairTex) {
			rect = new Rect((Screen.width - texW) * .5f, (Screen.height - texH) * .5f, texW, texH);
		}
	}

    void OnGUI() {
    	Cursor.lockState = CursorLockMode.Locked;
    	if(crosshairTex) {
    		GUI.DrawTexture(rect, crosshairTex, ScaleMode.StretchToFill);
    	}
    }
}
