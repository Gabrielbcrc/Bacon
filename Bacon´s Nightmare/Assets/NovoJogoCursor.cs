using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NovoJogoCursor : MonoBehaviour 
{

	void OnMouseDown() 
	{
		GameObject.Find("Fade").GetComponent<Animator>().Play("FadeOut");
		Invoke("LoadScreen", 1);
	}

	void OnMouseOver()
	{
		this.GetComponent<SpriteRenderer>().color = new Color (255,0,0);
	}

	void LoadScreen()
	{
		SceneManager.LoadScene("Night Level Design");
	}
}
