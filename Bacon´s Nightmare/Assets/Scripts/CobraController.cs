using UnityEngine;
using System.Collections;

public class CobraController : MonoBehaviour 
{
	/*
	Animator anim;
	bool walkLimit;
	Vector2 posInicial;
	public float range;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		anim.Play("Cobra Walk");
		walkLimit = true;
		posInicial = transform.position;


	}
	
	// Update is called once per frame
	void Update () 
	{
		walk();
	}

	void walk()
	{
		if (walkLimit) {
			transform.eulerAngles = new Vector2 (0, 0);
			if (transform.position.x > (posInicial.x + range)) {
				walkLimit = false;
			}

		}
		else
		{
			transform.eulerAngles = new Vector2 (0, 180);
			if (transform.position.x < posInicial.x)
			{
				walkLimit = true;
			}
		}
			
		transform.Translate (new Vector2 (3, 0) * Time.deltaTime);
	}
}
*/
		private Vector3 posA;

		private Vector3 posB;

		private Vector3 nexPos;

		[SerializeField]
		private float speed;

		[SerializeField]
		private Transform childTransform;

		[SerializeField]
		private Transform transformB;

		[SerializeField]
		private Transform transformA;

		// Use this for initialization
		void Start () {

			//posA = childTransform.localPosition;
			posA = transformA.localPosition;
			posB = transformB.localPosition;

			nexPos = posB;

		}

		// Update is called once per frame
		void Update () {
			Move ();
		}

		private void Move ()
		{
			childTransform.localPosition = Vector3.MoveTowards (childTransform.localPosition, nexPos, speed * Time.deltaTime);
			if (Vector3.Distance (childTransform.localPosition, nexPos) <= 0.1) {
				ChangeDestination ();
			}

		}
		private void ChangeDestination(){
			//		nexPos = nexPos != posA ? posA : posB;
			nexPos = nexPos != posA ? posA : posB;
		}
	}
