using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour {

	public Antonito porco;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.tag == "Player")
		{
			porco.blockPlayer ();
			PlayerPrefs.SetInt ("passou",1);

			Invoke ("load", 1);
		}
	}
	void load()
	{
		Debug.Log (porco.cenaNumero);
		SceneManager.LoadScene ("Fim");
	}
}
