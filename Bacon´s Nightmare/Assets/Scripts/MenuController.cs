using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour 
{
	public AudioSource[] sounds;
	public AudioSource alternar;
	public AudioSource selecionar;
	public List<GameObject> itensMenuPrincipal;
	public SaveCheck gerSave;
	Animator menuAnim;
	string modo;
	int opcao;
	public GameObject seletor;

	// Use this for initialization
	void Start () 
	{
		sounds = GetComponents<AudioSource>();
		alternar = sounds[0];
		selecionar = sounds[1];
		//menuAnim = GetComponent<Animator> ();
		modo = "principal";
		opcao = 1;
		PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			alternar.Play();
			if (modo == "principal") 
			{
				opcao++;
				if (opcao > 3)
					opcao = 0;
			}
		   
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			alternar.Play();
			if (modo == "principal") 
			{
				opcao--;
				if (opcao < 0)
					opcao = 3;
			}

		}

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			selecionar.Play();
			if ((modo == "principal") && (opcao == 1))
			{
				
				GameObject.Find("Fade").GetComponent<Animator>().Play("FadeOut");
				//LoadScreen (opcao);
				Invoke("LoadScreen", 1);


			}
			if ((modo == "principal") && (opcao == 3))
			{
				Application.Quit();
			}

		}





	}


	void OnGUI()
	{
	
		if (modo == "principal") 
		{

			if (opcao == 0) {
				seletor.transform.position = new Vector2 (itensMenuPrincipal [0].transform.position.x - 1.7f, itensMenuPrincipal [0].transform.position.y);
				itensMenuPrincipal [0].GetComponent<SpriteRenderer> (). color = new Color (255, 0, 0);
				itensMenuPrincipal [0].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0);
				itensMenuPrincipal [1].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
				itensMenuPrincipal [2].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
				itensMenuPrincipal [3].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);

			} else if (opcao == 1) {
				seletor.transform.position = new Vector2 (itensMenuPrincipal [1].transform.position.x -2f, itensMenuPrincipal [1].transform.position.y);
				itensMenuPrincipal [1].GetComponent<SpriteRenderer>(). color = new Color (255, 0, 0);
				itensMenuPrincipal [1].GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0);
				itensMenuPrincipal [0].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
				itensMenuPrincipal [2].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
				itensMenuPrincipal [3].GetComponent<SpriteRenderer>().color = new Color (255, 255, 255);

			}else if (opcao == 2) {
				seletor.transform.position = new Vector2 (itensMenuPrincipal [2].transform.position.x -1.4f, itensMenuPrincipal [2].transform.position.y);
				itensMenuPrincipal [2].GetComponent<SpriteRenderer> (). color = new Color (255, 0, 0);
				itensMenuPrincipal [2].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0);
				itensMenuPrincipal [1].GetComponent<SpriteRenderer>().color = new Color (255, 255, 255);
				itensMenuPrincipal [0].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
				itensMenuPrincipal [3].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
			}else if (opcao == 3) {
				seletor.transform.position = new Vector2 (itensMenuPrincipal [3].transform.position.x -1.1f, itensMenuPrincipal [3].transform.position.y);
				itensMenuPrincipal [3].GetComponent<SpriteRenderer> (). color = new Color (255, 0, 0);
				itensMenuPrincipal [3].GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0);
				itensMenuPrincipal [1].GetComponent<SpriteRenderer>().color = new Color (255, 255, 255);
				itensMenuPrincipal [2].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
				itensMenuPrincipal [0].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
			}


		}
	
	}

	void LoadScreen()
	{
		/*Invoke("LoadScreen", 1);
		string nome = "";

		if (numero == 0) 
		{
			nome = "d";
		}else if (numero == 1) 
		{
			nome = "Scene 1";
			gerSave.criaNovoJogo ();
		}if (numero == 2) 
		{
			nome = "c";
		}*/

		SceneManager.LoadScene("Level 01 - alpha");


	}
}
