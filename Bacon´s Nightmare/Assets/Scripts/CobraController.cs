using UnityEngine;
using System.Collections;

public class CobraController : MonoBehaviour 
{
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
