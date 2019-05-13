using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapCam : MonoBehaviour {

	public Transform motionCtl;
	public Transform target;
	public Transform origin;
	public Vector3 offset = Vector3.zero;
	public float speed = 0.1f;
	public float joystickScale = 1f;
	public bool doSmoothDirVector = false;

	public bool doAlign = false;
	public bool doMove = false;

	private Transform originOrig;
	private Vector3 offsetOrig;
	private bool isAligned = false;
	private bool firstRun = true;

	void Start() {
		originOrig = origin;
		offsetOrig = offset;
	}

	void Update() {
		if (firstRun) {
			transform.position = target.position + offset;
			transform.LookAt (origin);
			firstRun = false;
		} else {
			// left/right, forward/back
			//Vector3 dirVectorAlt = transform.localRotation * (new Vector3(sixCtlAlt.joystickVal.x, 0f, sixCtlAlt.joystickVal.y) * joystickScale);
			Vector3 dirVectorAlt = transform.localRotation * (new Vector3(-motionCtl.position.x, 0f, -motionCtl.position.y) * joystickScale);

			// left/right, up/down
			//Vector3 dirVectorMain = transform.localRotation * (new Vector3(sixCtlMain.joystickVal.x, sixCtlMain.joystickVal.y, 0f) * joystickScale);

			// prevents weird results from joystick input
			if (doSmoothDirVector) {
				//dirVectorMain = smoothDirVector(dirVectorMain);
				dirVectorAlt = smoothDirVector(dirVectorAlt);
			}

			//sixCtlAlt.offset += dirVectorAlt;
			//sixCtlMain.offset += dirVectorAlt;

			//transform.position += dirVectorAlt;// + dirVectorMain;

			if (Input.GetKeyDown(KeyCode.PageDown)) {
				doAlign = true;
			} else if (Input.GetKeyUp(KeyCode.PageDown)) {
				doAlign = false;
			}

			if (doAlign) {
				Vector3 targetFinal = target.position + offset;
				transform.position = Vector3.Lerp (transform.position, targetFinal, speed);
				//origin.transform.position += dirVectorAlt;
				//transform.LookAt(origin);
			}

			if (doMove) {
				//
			}

		}
	}

	public void disableOffset() {
		offset = Vector3.zero;
	}

	public void enableOffset() {
		offset = offsetOrig;
	}

	public Vector3 smoothDirVector(Vector3 v) {
		if (v != Vector3.zero) { 
			float directionLength = v.magnitude;
			v = v / directionLength;
			directionLength = Mathf.Min(1.0f, directionLength);
			directionLength = directionLength * directionLength;
			v = v * directionLength;
		}
		return v;
	}

}
