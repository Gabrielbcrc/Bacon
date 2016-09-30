using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour {

	public GameObject death;
	public GameObject self;
	public GameObject vermelho;
	public AudioSource[] audio;
	public AudioSource pigFled;
	public AudioSource BNdeath;
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (self);
		DontDestroyOnLoad (death);
	}
	void Start () 
	{
		PlayerPrefs.SetInt ("passou", 1);
		//PlayerPrefs.SetInt("x",y)
		//audio = GetComponent<AudioSource>();
		pigFled = audio [0];
		BNdeath = audio [1];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void vaiPlaneta()
	{
		Destroy (vermelho.GetComponent<SpriteRenderer> ());
		SceneManager.LoadScene("Night Level Design");
	}
	void tocaMusica(){
		pigFled.Play();
	}
	void Mato(){
		Debug.Log ("Morreu");
		BNdeath.Play();
	}
	void acabou(){
		PlayerPrefs.SetInt ("passouCutscene", 1);
	}
}
