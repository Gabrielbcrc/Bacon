using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour {


	public AudioSource[] audio;
	public AudioSource pigFled;
	// Use this for initialization
	void Start () 
	{


		//audio = GetComponent<AudioSource>();
		pigFled = audio [0];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void vaiPlaneta()
	{
		SceneManager.LoadScene("CutScene");
	}
	void tocaMusica(){
		Debug.Log ("açleuriogçliauorhjglaer");
		pigFled.Play();
	}
}
