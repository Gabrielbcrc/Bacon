using UnityEngine;
using System.Collections;

public class terra : MonoBehaviour {

	public Renderer rend;
	public GameObject seta;
	public bool avancar;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		avancar = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//	plataform_SPD = seta.GetComponent<plataforma> ().plataform_SPD;
//		Debug.Log (avancar);
		//Seta a posição da Terra para a posição da Seta
		transform.position = new Vector2 (seta.transform.position.x, seta.transform.position.y);
	}

	void OnTriggerEnter2D (Collider2D algo){
		if (algo.tag == "limite") {
			Debug.Log ("vira");
			avancar = !avancar;
		}
	}
}
