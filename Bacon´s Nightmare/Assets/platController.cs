using UnityEngine;
using System.Collections;

public class platController : MonoBehaviour 
{
	
	bool walkLimit;
	Vector2 posInicial;
	public float speed;
	public float range;
	// Use this for initialization
	void Start () 
	{
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
			if (walkLimit) 
			{
			transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
				if (transform.position.x > (posInicial.x + range)) 
				{
					walkLimit = false;
				}

			}
			else
			{
			transform.Translate (new Vector2 (-speed,0) * Time.deltaTime);
				if (transform.position.x < posInicial.x)
				{
					walkLimit = true;
				}
			}

	}
}