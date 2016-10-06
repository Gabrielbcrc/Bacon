using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour 
{
	public GameObject self;
	private bool created = false;
	void Awake(){
		self = gameObject;
		DontDestroyOnLoad (this);
		if (PlayerPrefs.HasKey ("maçã")) {
			Debug.Log ("ghoaioswghfoli");
			Destroy (self);
			Destroy (this);
		} else {
			Debug.Log("again");
		}
	}
	// Use this for initialization
	void Start ()
	{
		
	}
		/*
		if (!created) {
				// this is the first instance - make it persist
				DontDestroyOnLoad(this.gameObject);
				created = true;
		} else if(created == true) {
				// this must be a duplicate from a scene reload - DESTROY!
				Destroy(this.gameObject);
			} 

		/*this.name = "foo";
		if (FindObjectsOfType(GetType("foo")).Length > 1)
		{
			Destroy(gameObject);
		}
		if (self == null) {
			//self = this;
		} else {
			DestroyObject(gameObject);
		}*/
	
	
	// Update is called once per frame
	void Update () 
	{
		
		
		//Debug.Log (PlayerPrefs ("macã"));
	}
}
