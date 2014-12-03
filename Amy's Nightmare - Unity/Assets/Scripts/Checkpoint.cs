using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public GameObject P;
	public AudioClip CP;
	public Transform Respawn;

void OnTriggerEnter2D(Collider2D Colli) {
	if (Colli.gameObject.tag == "Player") {
			Respawn.position = transform.position;
			AudioSource.PlayClipAtPoint (CP, transform.position);
			Instantiate(P, new Vector3 (transform.position.x, transform.position.y+2, transform.position.z), transform.rotation);
			Destroy (gameObject);
		}
}
}
