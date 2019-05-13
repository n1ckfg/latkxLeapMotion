using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushInputLeap : MonoBehaviour {

	public LightningArtist lightningArtist;
	public Renderer[] targetRen;

	void Awake() {
		if (lightningArtist == null) lightningArtist = GetComponent<LightningArtist>();

		showRen(true);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.PageUp)) {
			lightningArtist.clicked = true;
			showRen(false);
		} else if (Input.GetKeyUp(KeyCode.PageUp)) {
     		lightningArtist.clicked = false;
			showRen(true);
		}		
	}

	void showRen(bool b) {
		for (int i = 0; i < targetRen.Length; i++) {
			targetRen[i].enabled = b;
		}
	}

}
