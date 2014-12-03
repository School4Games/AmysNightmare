using UnityEngine;
using System.Collections;

public class HideObject : MonoBehaviour {

	public GameObject target;
	public bool Hidden = true;

	// Use this for initialization
	void Start () {

	}
	void OnTriggerStay2D(Collider2D Colli) {
		if (Colli.gameObject.tag == "Player") {
			PlayerControlScript Player = target.GetComponent ("PlayerControlScript") as PlayerControlScript;
			//Bei niedrigen Verstecken
			if (!Hidden){
				if (Player.Crouch == true){
					Player.Hidden = true;
				}
				else 
				{
					Player.Hidden = false;
				}
			}
			if (Hidden){
				Player.Hidden = true;
			}
		}
	}
	void OnTriggerExit2D(Collider2D Colli) {
		if (Colli.gameObject.tag == "Player") {
			PlayerControlScript Player = target.GetComponent ("PlayerControlScript") as PlayerControlScript;
			//Bei niedrigen Verstecken
			Player.Hidden = false;
		}
	}

}
