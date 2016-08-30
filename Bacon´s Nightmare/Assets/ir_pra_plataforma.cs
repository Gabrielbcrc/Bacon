using UnityEngine;
using System.Collections;

public class ir_pra_plataforma : MonoBehaviour {

	public GameObject plataforma;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (plataforma.transform.position.x, plataforma.transform.position.y);
	
	}
}
