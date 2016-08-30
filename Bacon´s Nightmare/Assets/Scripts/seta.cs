using UnityEngine;
using System.Collections;

public class seta : MonoBehaviour {

	public Renderer rend;
	Rigidbody2D rb;
	public float plataform_SPD;
	public GameObject plat;

	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = false;

		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		transform.Translate (new Vector2 (0, plataform_SPD / 100));
		if (plat.GetComponent<terra> ().avancar == true) {
			plataform_SPD = Mathf.Abs (plataform_SPD);
		} else {
			plataform_SPD = -Mathf.Abs (plataform_SPD);
		}
	}
}
