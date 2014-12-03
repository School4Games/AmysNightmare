using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform START;
	public Transform END;
	public Transform Amy;
	private Transform target;
	public float speed = 1.0f;
	//private Vector3 newposition;


	// Use this for initialization
	void Start () 
	{
		target = Amy;

		transform.position = new Vector3 (START.position.x, transform.position.y, transform.position.z);
	}

	void Update () 
	{
		UpdatePosition ();
	}
	
	void OnTriggerEnter2D(Collider2D Colli) 
	{
		if (Colli.gameObject.tag == "Player") 
		{
			PlayerControlScript Player = Amy.GetComponent ("PlayerControlScript") as PlayerControlScript;
			if (!Player.Hidden)
			{
				target = Colli.gameObject.transform;
			}
			if (Player.Hidden && target != START)
			{
				target = END;
			}
		}

		if (Colli.gameObject.tag == "EnemyStart") 
		{
			target = END;
		}

		if (Colli.gameObject.tag == "EnemyEnd") 
		{
			target = START;
		}
	}
	
	void UpdatePosition()
	{
		// oldPosition ist die Position vor dem Update
		Vector3 oldPosition = transform.position;
		// fromPositionToTarget ist der Vektor von der eigenen Position zum Ziel (so lang wie die tatsächliche Distanz zwischen den Punkten)
		Vector3 fromPositionToTarget = -transform.position + target.position;
		// target dir ist die Richtung zum Ziel. Dafür normalisieren wir den Distanzvektor (= bringen auf die Länge 1)
		Vector3 targetDir = fromPositionToTarget.normalized;
		// movement ist das, was im letzten Frame an Strecke zurückgelegt wurde (= Geschwindigkeit mal vergangene Zeit mal die Richtung zum Ziel)
		Vector3 movement = speed * Time.deltaTime * targetDir;
		// newPosition entsteht aus der alten Position plus der zurückgelegten Strecke
		Vector3 newPosition = oldPosition + movement;
		
		transform.position = newPosition;
	}
}
