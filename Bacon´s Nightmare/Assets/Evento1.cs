using UnityEngine;
using System.Collections;

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
			if (PlayerPrefs.GetInt("Cena") == 2)
			{
				porco.blockPlayer();
				PlayerPrefs.SetInt("Cena", 3);
				Invoke("load", 2);
			}

			if (PlayerPrefs.GetInt("Cena") == 1)
			{
				serraAudio();
				porco.blockPlayer();
				borboleta.vaiEmbora();

				PlayerPrefs.SetInt("Cena", 2);
				Invoke("antonitoAudioSusto", 1);
				//fade.transform.position = new Vector2 (cameraPos.transform.position.x, cameraPos.transform.position.y);
				//GameObject.Find("Fade").GetComponent<Animator>().Play("FadeOut");
				//fade.fadeOut();
				//fade.GetComponent<Animator>().Play("FadeOut");
				Invoke("load", 2);
				//Destroy(gameObject);
			}

		}
	}
	void load()
	{
		Debug.Log(porco.cenaNumero);
		porco.LoadScreen();
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
