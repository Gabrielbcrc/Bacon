using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Formulario : MonoBehaviour 
{

	void OnMouseDown(){
//		GameObject.Find("Fade").GetComponent<Animator>().Play("FadeOut");
//		Invoke("LoadScreen", 1);
		Invoke("QuitApp",1);
		Application.OpenURL ("https://docs.google.com/forms/d/e/1FAIpQLSdwB-m7t1lkdFPYyobWIbVDaa3MTWScMtVnP79acbJbO1sH5g/viewform");
	}

	void OnMouseExit(){
		this.GetComponent<UnityEngine.UI.Text>().color = new Color (10,10,10)/*(16,35,165)*/;
	}

	void OnMouseOver(){
		this.GetComponent<UnityEngine.UI.Text>().color = new Color (10,0,0);
	}

	void LoadScreen(){
		SceneManager.LoadScene("Night Level Design");
	}

	void QuitApp()
	{
		Application.Quit();
	}
}
