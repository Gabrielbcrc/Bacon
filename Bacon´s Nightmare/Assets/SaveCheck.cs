using UnityEngine;
using System.Collections;

public class SaveCheck : MonoBehaviour {

	void Start(){
		//teste para transformat string em dados
		string p = "1;10,11;100;10";


		string[] sp = p.Split (';');
		Debug.Log ("Level " + sp [0]);
		string[] sp2 = sp [1].Split (',');
		Debug.Log ("Pos x: " + sp2 [0]+" y "+ sp2 [1]);
		Vector2 pos = new Vector2 (float.Parse(sp2 [0]), float.Parse(sp2 [0]));

		Debug.Log ("Vida " + sp [2]);
		Debug.Log ("Municao " + sp [2]);
	}
	public void criaNovoJogo(){

		PlayerPrefs.SetString ("novojogo", "true");
	}


	public string verificaContinue()
	{

		if(PlayerPrefs.HasKey("novojogo"))
			return PlayerPrefs.GetString ("novojogo");

		return "false";

	}

	public void deleteSaves(){
		PlayerPrefs.DeleteAll ();
	}
}
