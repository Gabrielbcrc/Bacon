using UnityEngine;
using System.Collections;

public class BorboletaController : MonoBehaviour 
{
	Animator anim;
	Vector2 posInicial;
	public float range;
	bool isfly;
	GameObject target;
	public string estado;
	public float velocidade;
	Vector2 limites;
	bool direcao;
	bool triggerOnce;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();

		target = GameObject.Find ("Antonito");
		posInicial = transform.position;

		estado = "entrada";
		limites = new Vector2 (transform.position.y + 0.2f, transform.position.y - 0.2f);

	}
	
	// Update is called once per frame
	void Update () 
	{
		

		if (estado == "entrada") {
			anim.Play("BorboletaFly");
			transform.eulerAngles = new Vector2 (0, 0);
			moverVertical ();


			if (target.transform.position.x + 2 > transform.position.x) {

				estado = "atencao";
				Invoke ("modoFly", 1);
			}

		} else if (estado == "espera") {
			anim.Play("BorboletaIdle");
			if (target.transform.position.x + 5 > transform.position.x)
				estado = "fly";
		    
		}

		if(estado == "embora")
		{
			moverVertical();
			transform.Translate (new Vector2 (15, 15) * Time.deltaTime);
			Invoke("morraSeya",2);

		}
		else if(estado == "fly")
		{
			anim.Play("BorboletaFly");
			fly ();
		}
	}

	void fly()
	{
		transform.eulerAngles = new Vector2 (0, 180);
		moverVertical ();

		if (target.transform.position.x + 10 < transform.position.x) {
			estado = "espera";
			Invoke ("modoEntrada", 3);
		}

		if (limites.y < target.transform.position.y + 2.2f) {
			transform.Translate (new Vector2 (0, 1) * Time.deltaTime);
			limites = new Vector2 (limites.x, limites.y + 0.1f);
		}else if (limites.y > target.transform.position.y - 2.2f) {
			transform.Translate (new Vector2 (0, -1) * Time.deltaTime);
			limites = new Vector2 (limites.x, limites.y - 0.1f);
		}
	}

	void moverVertical(){
		transform.Translate (new Vector2 (-velocidade, 0) * Time.deltaTime);

		if (direcao) {
			if (transform.position.y > limites.y)
				direcao = false;

			transform.Translate (new Vector2 (0, 1) * Time.deltaTime);

		} else {
			if (transform.position.y < limites.y)
				direcao = true;

			transform.Translate (new Vector2 (0, -1) * Time.deltaTime);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{

	}
	void modoFly()
	{
		estado = "fly";
	}

	void modoEntrada(){
		if(estado != "fly")
			estado = "entrada";
	}
	public void vaiEmbora()
	{
		estado = "embora";
	}
	void morraSeya()
	{
		Destroy(gameObject);
	}
}
