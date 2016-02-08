using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

    Vector3 vel;
    Rigidbody myBody;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody>();
	}

    public void Move(Vector3 _velocity) {
        vel = _velocity;
    }

    void FixedUpdate() {
        myBody.MovePosition(myBody.position + vel * Time.fixedDeltaTime);
    }

    public void LookAt(Vector3 lookPoint) {
        Vector3 heightCorrect = new Vector3(lookPoint.x,transform.position.y,lookPoint.z);
        transform.LookAt(heightCorrect);
    }
}
