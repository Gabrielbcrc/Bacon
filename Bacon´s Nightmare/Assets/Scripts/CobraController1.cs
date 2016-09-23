using UnityEngine;
using System.Collections;

public class CobraController1 : MonoBehaviour {

	// Use this for initialization
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
			if(childTransform.eulerAngles.y == 0)
				childTransform.eulerAngles = new Vector2 (0, 180);
			else
				childTransform.eulerAngles = new Vector2 (0, 0);
		}

	}
	private void ChangeDestination(){
		//		nexPos = nexPos != posA ? posA : posB;
		nexPos = nexPos != posA ? posA : posB;
	}
}

