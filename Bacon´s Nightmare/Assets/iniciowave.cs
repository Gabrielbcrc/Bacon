using UnityEngine;
using System.Collections;

public class iniciowave : MonoBehaviour {

	//public GameObject inicioSong;
	void Awake()
	{
		/*if(!PlayerPrefs.HasKey("passou"))
		{
			DontDestroyOnLoad (this);
		}
		
		if ((!PlayerPrefs.HasKey ("maçã")) && (!PlayerPrefs.HasKey ("passou"))) 
		{
			Debug.Log ("qwertyuiop");
			this.GetComponent<AudioSource> ().Play ();
		} else if ((PlayerPrefs.HasKey ("maçã")) && (!PlayerPrefs.HasKey ("passou"))) 
		{
			Debug.Log("poiuytrewq");
			Destroy (gameObject);
		}*/
		if (PlayerPrefs.HasKey ("passou"))
		{
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () 
	{
		
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
