using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	float SpeedX;
	float SpeedY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SpeedX = 0;
		SpeedY = 0;

		if (Input.GetKey(KeyCode.W)) {
			SpeedY = 3.0f;
		}
		if (Input.GetKey(KeyCode.S)) {
			SpeedY = -3.0f;
		}
		if (Input.GetKey(KeyCode.A)) {
			SpeedX = -3.0f;
		}
		if (Input.GetKey(KeyCode.D)) {
			SpeedX = 3.0f;
		}

		transform.Translate(new Vector3(SpeedX,SpeedY,0) * Time.deltaTime);
	}
}
