using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Evento1 : MonoBehaviour 
{
	public Fade fade;
	GameObject cameraPos;
	public BorboletaController borboleta;
	public AudioSource[] sounds;
	public AudioSource noise1;
	public AudioSource noise2;
	public Antonito porco;
	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetInt ("passou") == 1) 
		{
			gameObject.SetActive (false);
			borboleta.gameObject.SetActive (false);
		}
		fade = FindObjectOfType<Fade> ();
		cameraPos = GameObject.Find("Main Camera");
		sounds = GetComponents<AudioSource>();
		porco = (Antonito) FindObjectOfType(typeof(Antonito));
		noise1 = sounds[0];
		noise2 = sounds[1];
		borboleta = FindObjectOfType<BorboletaController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.tag == "Player")
		{
			GameObject.Find("Fade").GetComponent<Fade>().fadeOut();
			porco.blockPlayer ();
			PlayerPrefs.SetInt ("passou",1);
			if (GameObject.Find ("Borboleta") != null) 
			{
				borboleta.morraSeya();
			}

			Invoke ("load", 1);
		}
	}
	void load()
	{
		Debug.Log(porco.cenaNumero);
		SceneManager.LoadScene("CutScene");
	}
	void antonitoAudioSusto()
	{
		noise1.Play();
	}
	void serraAudio()
	{
		noise2.Play();
	}
}
