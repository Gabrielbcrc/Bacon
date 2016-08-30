using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour 
{
	GameObject cameraPos;
	Animator fade;
	// Use this for initialization
	void Start () 
	{
		cameraPos = GameObject.Find("Main Camera");
		fade = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void fadeIn()
	{
		transform.position = new Vector2 (cameraPos.transform.position.x, cameraPos.transform.position.y);
		fade.Play("FadeIn");
	}
	public void fadeOut()
	{
		transform.position = new Vector2 (cameraPos.transform.position.x, cameraPos.transform.position.y);
		fade.Play("FadeOut");
	}
}
