using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public GameObject target;
	public int lvl;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D Colli) {
		
		
		if (Colli.gameObject.tag == "Player") {
			Application.LoadLevel(lvl);
		}
	}
}
