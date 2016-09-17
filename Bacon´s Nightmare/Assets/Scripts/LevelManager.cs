using UnityEngine;
using System.Collections;


public class LevelManager : MonoBehaviour 
{
	
	GameObject borboleta;
	public GameObject currentCheckpoint;
	public Antonito porco;
	public GameObject balaoBorboleta;
	float x,y,z;
	public int checkPoint = 0;
	// Use this for initialization
	void Start () 
	{
		balaoBorboleta.SetActive(false);
		porco = (Antonito) FindObjectOfType(typeof(Antonito));
		if(GameObject.Find ("Borboleta") != null )
		{
			borboleta = GameObject.Find ("Borboleta");
			borboleta.transform.position = new Vector2 (porco.transform.position.x +16, porco.transform.position.y + 4);
		}
		/*if(PlayerPrefs.HasKey("x"))
		{
			if(Application.loadedLevel == 2)
			{
				PlayerPrefs.DeleteKey("x");
				PlayerPrefs.DeleteKey("y");
				PlayerPrefs.DeleteKey("z");
				checkPoint = 0;
			}
			else
			{
				checkPoint = PlayerPrefs.GetInt("CheckPoint");
			}
		}*/

		if(porco.cenaNumero == 2)
		{
			porco.transform.eulerAngles = new Vector2 (0, 180);
		}

		if (PlayerPrefs.GetInt("Cena") == 1)
		{
			Invoke("ativarBalao", 2);
			balaoBorboleta.transform.position = new Vector2 (porco.transform.position.x +0.75f, porco.transform.position.y + 2);
			Invoke("desativarBalao", 4f);
		}
	}

	void FixedUpdate()
	{
		balaoBorboleta.transform.position = new Vector2 (porco.transform.position.x +0.75f, porco.transform.position.y + 2);
	}
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void respawnPlayer()
	{
		porco.transform.position = currentCheckpoint.transform.position;
	}


	public void saveCheckpoint()
	{
		checkPoint++;
		PlayerPrefs.SetInt ("CheckPoint", checkPoint);
		PlayerPrefs.SetFloat("x", currentCheckpoint.transform.position.x);
		PlayerPrefs.SetFloat("y", currentCheckpoint.transform.position.y);
		//PlayerPrefs.SetFloat("z", currentCheckpoint.transform.position.z);
		x = PlayerPrefs.GetFloat("x", 0);
		y = PlayerPrefs.GetFloat("y", 0);
		//z = PlayerPrefs.GetFloat("z", 0);

		//Debug.Log(PlayerPrefs.GetFloat("z", 0));
	}

	public void loadCheckpoint()
	{
		x = PlayerPrefs.GetFloat("x", 0);
		y = PlayerPrefs.GetFloat("y", 0);
		//z = PlayerPrefs.GetFloat("z", 0);
		checkPoint = PlayerPrefs.GetInt ("CheckPoint", 0);
		porco.transform.position = new Vector2 (PlayerPrefs.GetFloat("x", 0),PlayerPrefs.GetFloat("y", 0));			
	}
	public void deleteSaves()
	{
		PlayerPrefs.DeleteAll ();
	}

	void desativarBalao()
	{
		balaoBorboleta.SetActive (false);
	}

	void ativarBalao()
	{
		balaoBorboleta.SetActive (true);
	}
}
