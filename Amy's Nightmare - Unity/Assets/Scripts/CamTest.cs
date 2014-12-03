using UnityEngine;
using System.Collections;

public class CamTest : MonoBehaviour {

	public Transform target;
	public float smooth = 1.0f;
	public float speed = 1.0f;
	public float height;

	void Start () {
		transform.position = new Vector3 (target.position.x, transform.position.y, transform.position.z);
		}
	// Update is called once per frame
	void Update () {
		//smooth camera
		if (Input.GetAxis ("Horizontal") != 0) {	
			transform.position += Vector3.right * Time.deltaTime * speed * Input.GetAxis ("Horizontal");
		} 
		//if (Input.anyKey == false ) {
			Vector3 newposition = new Vector3 (target.position.x, target.position.y+height, transform.position.z);
			transform.position = Vector3.Lerp(transform.position,newposition,Time.deltaTime * smooth);
		}

}