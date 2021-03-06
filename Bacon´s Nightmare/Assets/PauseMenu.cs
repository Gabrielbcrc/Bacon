﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject PauseUI;

	private bool paused = false;

	void Start ()
	{
		PauseUI.SetActive(false);
	}

	void Update()
	{
		if(Input.GetButtonDown("Pause"))
		{
			paused = !paused;
		}

		if(paused)
		{
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}


	public void Resume ()
	{
		paused = false;
	}

	public void Restart()
	{
		SceneManager.LoadScene("Night Level Design");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Mainmenu()
	{
		SceneManager.LoadScene("Menu");
	}

}

