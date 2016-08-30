using UnityEngine;
using System.Collections;

public class platVertical : MonoBehaviour 
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
			transform.Translate (new Vector2 (0, speed) * Time.deltaTime);
			if (transform.position.y > (posInicial.y + range)) 
			{
				walkLimit = false;
			}

		}
		else
		{
			transform.Translate (new Vector2 (0, -speed) * Time.deltaTime);
			if (transform.position.y < posInicial.y)
			{
				walkLimit = true;
			}
		}


	}
}
