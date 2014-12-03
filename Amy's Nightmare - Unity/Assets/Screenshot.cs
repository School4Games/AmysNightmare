using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {
	// Use this for initialization

	void Start (){
		//transform.localScale = new Vector3 (1.39f, 1.39f, 1.0f);
		//AudioSource.PlayClipAtPoint (Menu.Click, transform.position);
		}

	// Update is called once per frame
	void Update () {
						if (transform.position.x >= 1) {
			Destroy (gameObject);

				}

		}
}
