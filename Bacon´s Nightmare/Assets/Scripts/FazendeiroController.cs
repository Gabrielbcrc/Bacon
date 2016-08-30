using UnityEngine;
using System.Collections;

public class FazendeiroController : MonoBehaviour 
{
	private Antonito porco;
	GameObject cameraPos;
	public float fazendDestroy;
	//bool onScreen;
	//public float x,y;
	//GameObject porco;
	public float vSpeed;
	// Use this for initialization
	void Start () 
	{
		cameraPos = GameObject.Find("Main Camera");
		porco = (Antonito) FindObjectOfType(typeof(Antonito));

		//porco = GameObject.Find("Antonito");
		//transform.position = new Vector2 (porco.transform.position.x + x, porco.transform.position.y + y);
		//onScreen = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		walk ();

	}
	void FixedUpdate()
	{
		if(Mathf.Abs(transform.position.x) > Mathf.Abs(cameraPos.transform.position.x) + fazendDestroy)
		{
			Destroy(gameObject);
		}

	}
	void walk()
	{
		/*if (onScreen) 
		{
			transform.eulerAngles = new Vector2 (0, 0);
			if (transform.position.x > (posInicial.x + range))
			{
				onScreen = false;
			}

		} else //if (walkLimit == false) 
		{
			transform.eulerAngles = new Vector2 (0, 180);
			if (transform.position.x < posInicial.x)
			{
				onScreen = true;
			}
		}*/


		transform.Translate (new Vector2 (vSpeed, 0) * Time.deltaTime);
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("1");
			porco.life--;
		}
	}
}
