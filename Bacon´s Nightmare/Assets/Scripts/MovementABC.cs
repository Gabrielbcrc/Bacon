using UnityEngine;
using System.Collections;

public class MovementABC : MonoBehaviour {


	private Vector3 posA;

	private Vector3 posB;

	private Vector3 posC;

	private Vector3 posD;

	private Vector3 nexPos;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform childTransform;

	[SerializeField]
	private Transform transformB;

	[SerializeField]
	private Transform transformA;

	[SerializeField]
	private Transform transformC;

	[SerializeField]
	private Transform transformD;

	bool back;

	// Use this for initialization
	void Start () {

		//posA = childTransform.localPosition;
		posA = transformA.localPosition;
		posB = transformB.localPosition;
		posC = transformC.localPosition;
		posD = transformD.localPosition;

		back = false;

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

		if (nexPos == posA) {
			nexPos = posB;
			back = false;
		} else if (nexPos == posB)
		if (back == false)
			nexPos = posC;
		else
			nexPos = posA;
		else if (nexPos == posC) {
			nexPos = posD;
			back = true;
		}else if (nexPos == posD) 
			nexPos = posA;

		
	}
}
