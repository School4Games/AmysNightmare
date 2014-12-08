using UnityEngine;
using System.Collections;


public class PlayerControlScript : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpforce = 1.0f;
	public float flip;
	Animator anim;
	private bool Flip = false;
	private bool Respawn = false;
	private bool Detection = false;
	private bool Escaped = true;
	private bool Pause = false;


	public AudioClip C;

	[HideInInspector]
	public bool Crouch = false;

	[HideInInspector]
	public bool Hidden = false;

	private float StartCounter = 0.0f;
	private float Counter = 10.0f;
	public float Countspeed = 1.0f;
	public Transform Spawnpoint;
	public GameObject Amy;

	// Use this for initialization
	
	void Start() 
	{
		anim = Amy.GetComponent<Animator>() as Animator;
		Flip = false;
		transform.position = new Vector3 (Spawnpoint.position.x, Spawnpoint.position.y, transform.position.z);
		StartCounter = Counter;
	}

	void OnGUI() 
	{
		if (Pause) {
						GUI.color = Color.yellow;
						GUIStyle style = GUI.skin.GetStyle ("Box");
						style.fontSize = Screen.width / 20;
						GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "");
						GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "");
						GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "Pause");
			GUI.color = Color.cyan;
			//GUI.skin
			GUIStyle style2 = GUI.skin.GetStyle ("Button");
			style2.fontSize = Screen.width / 20;
			if (GUI.Button (new Rect (10, Screen.height - 10 - (Screen.height * 0.1f), Screen.width * 0.15f, Screen.height * 0.1f), "Menu", style2))
			{
				AudioSource.PlayClipAtPoint (C, transform.position);
				Application.LoadLevel (0);
			}
			if (GUI.Button (new Rect (Screen.width - 10 - (Screen.width * 0.15f), Screen.height - 10 - (Screen.height * 0.1f), Screen.width * 0.15f, Screen.height * 0.1f), "Exit", style2))
			{	
				AudioSource.PlayClipAtPoint (C, transform.position);
				Application.Quit ();
			}
				} 
		else {
						GUI.color = Color.red;
						//GUI.skin
						GUIStyle style = GUI.skin.GetStyle ("label");
						style.fontSize = Screen.width / 20;
						GUI.Label (new Rect (10, Screen.height - 10 - (Screen.height * 0.1f), Screen.width * 0.1f, Screen.height * 0.1f), Counter.ToString ("0"), style);
				}
	}

	void OnTriggerStay2D(Collider2D Colli) {
				if (Colli.gameObject.tag == "HideOB") {
						if (Hidden && !Escaped){
						Counter += Time.deltaTime*Countspeed;
						if (Counter >= StartCounter){
							Escaped = true;
							Counter = StartCounter;
						}

						Debug.Log ("You're hidden");
						}
				}
		if (Colli.gameObject.tag == "Black") {
			Debug.Log ("Fallen death");
			Respawn = true;

		}
			
		if (Colli.gameObject.tag == "LightBeam" && Hidden == false) {
			Detection = true;
			Escaped = false;

			Debug.Log ("You're not hidden and going to die");

			}
		}
	



	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {  
						if (Time.timeScale == 1) {   
								Screen.showCursor = true;         
								Pause = true;
								Time.timeScale = 0;
						} else {
								Screen.showCursor = false;
								Pause = false; 
								Time.timeScale = 1;                
						}
				}
		
					

				if (Detection && !Escaped) {
						Counter -= Time.deltaTime*Countspeed;
						if (Counter <= 0.0f){
							Counter = 0.0f;
							Respawn = true;
						}
				}	
				

				if (Respawn) {
						Escaped = true;
						transform.position = new Vector3 (Spawnpoint.position.x, Spawnpoint.position.y, transform.position.z);
						Counter = StartCounter;
						Respawn = false;
						
						}
		 
				if (Input.GetAxis ("Horizontal") < 0) {
						Debug.Log ("Flip = true");
						Flip = true;
		}

		if (Flip) {
			Debug.Log ("***>> flipping");
						transform.localScale = new Vector3 (-flip, transform.localScale.y, transform.localScale.z);
						
						if (Input.GetAxis ("Horizontal") > 0) {
						transform.localScale = new Vector3 (flip, transform.localScale.y, transform.localScale.z);
								Debug.Log ("Flip = false");
								Flip = false;
						}
				}

						
		if (Input.GetAxis ("Horizontal") != 0) {
						transform.position += Vector3.right * Time.deltaTime * speed * Input.GetAxis ("Horizontal");
						anim.SetBool ("Walk", true);
						} 
		else {
								anim.SetBool ("Walk", false);
						}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {

						Crouch = true;
						anim.SetBool ("Crouch", true);
				} 
		else {
			Crouch = false;
		}
		}
	/*if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
		
		Crouch = true;
		anim.SetBool ("Crouch", true);
	} 
	else {
		Crouch = false;
		anim.SetBool ("Idle", true);
	}
	
	if ((Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space))&& Jump) {
		rigidbody2D.AddForce (Vector2.up * jumpforce, ForceMode2D.Impulse);
		anim.SetBool ("Jump", true);
		Jump = false;
		anim.SetBool ("Crouch",false);
	}
	else
	{
		Jump = false;
		anim.SetBool ("Jump", false);
	}
}*/

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag != "Wall" && !Crouch) 
		{
			JumpCheck ();
		}
	}


	void OnCollisionStay2D(Collision2D coll) 
	{

		if (coll.gameObject.tag != "Wall" && !Crouch) 
		
		{
						JumpCheck ();
		} 

	}

	void JumpCheck()
	{
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space))
		{
			rigidbody2D.AddForce (Vector2.up * jumpforce, ForceMode2D.Impulse);
			anim.SetBool ("Jump", true);
			anim.SetBool ("Walk",false);	
		}
		else
		{
			anim.SetBool ("Jump", false);
			anim.SetBool ("Crouch", false);
		}
	}
}