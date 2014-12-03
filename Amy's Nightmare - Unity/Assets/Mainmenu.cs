using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour {
	public AudioClip Click;
	// Use this for initialization
	void Start () {
	
	}

	void OnGUI (){
	GUI.color = Color.cyan;
	//GUI.skin
	GUIStyle style = GUI.skin.GetStyle ("Button");
	style.fontSize = Screen.width / 20;
	if (GUI.Button (new Rect (10, Screen.height - 10 - (Screen.height * 0.1f), Screen.width * 0.15f, Screen.height * 0.1f), "Exit", style))
		{	AudioSource.PlayClipAtPoint (Click, transform.position);
			Application.Quit ();
		}
		if (GUI.Button (new Rect (Screen.width - 10 - (Screen.width * 0.15f), Screen.height - 10 - (Screen.height * 0.1f), Screen.width * 0.15f, Screen.height * 0.1f), "Start", style))
		{	AudioSource.PlayClipAtPoint (Click, transform.position);
			Application.LoadLevel (1);
		}
	}

	void Update (){
				Time.timeScale = 1; 
		}
}
