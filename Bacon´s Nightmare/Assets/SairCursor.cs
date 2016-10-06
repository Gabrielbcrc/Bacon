using UnityEngine;
using System.Collections;

public class SairCursor : MonoBehaviour {

	void OnMouseDown()
	{
		Application.Quit();
	}

	void OnMouseOver()
	{
		this.GetComponent<SpriteRenderer>().color = new Color (255,0,0);
	}
}
