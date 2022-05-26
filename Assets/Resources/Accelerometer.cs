using UnityEngine;
using System.Collections;

public class Accelerometer : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ConstantForce2D force = GetComponent<ConstantForce2D>();//transform.Translate(Input.acceleration.x / 10, 0, 0);//Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
        var myForce = force.force;
		var direction = 0f;
		if (Input.GetKey("a")) {
			direction = direction - 1f;
		}
		if (Input.GetKey("d")) {
			direction = direction + 1f;
		}
        myForce.x = Score.accelerometerDirection* direction * 2f;//originally "Score.accelerometerDirection* Input.acceleration.x * 8f;"
        force.force = myForce;


        float x = Input.acceleration.x;
        //GUI.Label(new Rect(0, 0, 100, 100), x.ToString());
	}
}

