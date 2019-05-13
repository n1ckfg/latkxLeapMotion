using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapToolFinder : MonoBehaviour {

	Vector3 scale = Vector3.one;
	private GameObject target;

	void Update () {
		if (target == null) {
			target = GameObject.FindGameObjectWithTag("Tool");
		} else if (target != null) {
			transform.position = new Vector3(target.transform.position.x * scale.x, target.transform.position.y * scale.y, target.transform.position.z * scale.z);
			transform.rotation = target.transform.rotation;
			transform.localScale = target.transform.localScale;
		}
	}

}
