using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Antonito : MonoBehaviour 
{
	public Fade fade;
	public LevelManager levelManager;
	public GameObject fazendeiro;
	public GameObject warning;
	GameObject cameraPos;
	Rigidbody2D rgb;
	Animator anim;
	//AudioSource audio;
	public AudioSource[] sounds;
	public AudioSource morte;
	public AudioSource pulo;
	public AudioSource walk;
	public AudioSource susto;
	public float inimigoX,inimigoY;
	public float jumpForce;
	public Transform checkFloor;
	public LayerMask platform;
	bool grounded = false;
	float groundRadius = 0.2f;
	//float vSpeed;
	public int life;
	int appleCont;
	public Text countText;
	public bool isEvent;
	float vSpeed;
	bool triggerOnce;
	bool gameover;
	public int cenaNumero;

	void Start () 
	{
		fade = FindObjectOfType<Fade> ();
		//fade = GameObject.Find("Fade");
		//fade = (Fade) FindObjectOfType(typeof(Fade));
		triggerOnce = true;
		//isEvent = true;
		levelManager = FindObjectOfType<LevelManager> ();
		cameraPos = GameObject.Find("Main Camera");
		warning.SetActive (false);
		appleCont = 0;
		setCountText();
		gameover = false;
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		//audio = GetComponent<AudioSource> ();
		sounds = GetComponents<AudioSource>();
		morte = sounds[0];
		pulo = sounds[1];
		susto = sounds[2];
		//walk = sounds[3];
		Invoke("unblockPlayer", 3f);
		//PlayerPrefs.DeleteAll (); //deletar todos os prefs TEMPORARIO
		//fade.fadeIn();


		if(PlayerPrefs.HasKey("x"))
		{
			//isEvent = false;
			levelManager.loadCheckpoint();
		}
		if(!PlayerPrefs.HasKey("Cena"))
		{
			PlayerPrefs.SetInt("Cena", 1);
		}
		else if(PlayerPrefs.GetInt("Cena") == 2)
		{
			transform.eulerAngles = new Vector2 (0, 180);
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow) && life > 0 && !isEvent)
		{
			Jump();
		}

		if((life <= 0) && (!gameover))
		{
			gameOver();
			//SceneManager.LoadScene("Scene 1");
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle(checkFloor.position, groundRadius, platform); //True se personagem está no chão
		anim.SetBool("Ground", grounded);
		anim.SetFloat("vSpeed", rgb.velocity.y);

		float vel = 0f;
		if (Input.GetKey(KeyCode.RightArrow) && life > 0 && !isEvent) 
		{

			vel=1f;
			Walk ("right");

		} else if (Input.GetKey(KeyCode.LeftArrow) && life > 0 && !isEvent) 
		{
			Walk ("left");
			vel=1f;
		} 
			
		anim.SetFloat ("vel",vel);



	}

	void Walk(string direction)
	{
		if (direction == "right") 
		{
			transform.eulerAngles = new Vector2 (0, 0);
		} else if (direction == "left") 
		{
			transform.eulerAngles = new Vector2 (0, 180);

		}

		transform.Translate (new Vector2 (5, 0)*Time.deltaTime);
	}

	void Jump()
	{
		if(grounded)
		{
			anim.SetBool("Ground", false);
			rgb.AddForce(new Vector2(0,jumpForce));
			pulo.Play();
			//vSpeed = rgb.velocity.y;
			//Debug.Log (vSpeed);
		}
			
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Coletavel")) 
		{
			appleCont++;
			other.gameObject.SetActive (false);
			setCountText();
		}
		if(other.tag == "Inimigo")
		{
			life--;
		}
			
		if(other.tag == "inimigoSpawnDireita")
		{
			warning.transform.position = new Vector2 (cameraPos.transform.position.x+12.2f, cameraPos.transform.position.y);
			warning.SetActive(true);
			GameObject g = Instantiate(fazendeiro);
			g.transform.position = new Vector2 (transform.position.x + inimigoX, transform.position.y + inimigoY);
			g.transform.eulerAngles = new Vector2 (0, 180);
			Destroy(other.gameObject);
			//warning.transform.position = new Vector2 (transform.position.x + 15, transform.position.y+5);
			//warning.SetActive(true);
			Invoke("desativarWarning", 3);

		}

		if(other.tag == "inimigoSpawnEsquerda")
		{
			warning.transform.position = new Vector2 (cameraPos.transform.position.x-12.2f, cameraPos.transform.position.y);
			warning.SetActive(true);
			GameObject g = Instantiate(fazendeiro);
			g.transform.position = new Vector2 (transform.position.x - inimigoX, transform.position.y + inimigoY);
			Destroy(other.gameObject);
			Invoke("desativarWarning", 3);
		}


		if(other.tag == "Borboleta" && triggerOnce)
		{
			
		}

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "platMove")
		{
			transform.parent = other.transform;
		
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "platMove") 
		{
			transform.parent = null;

		}
	}

	public void LoadScreen()
	{
		SceneManager.LoadScene("Night Level Design");
		//levelManager.respawnPlayer ();
		//life = 1;
		//anim.Play("Antonito Idle");
		/*
		if (PlayerPrefs.GetInt("Cena") == 1)
		{
			SceneManager.LoadScene("Level 01 - alpha");
		}
		else if (PlayerPrefs.GetInt("Cena") == 2)
		{
			SceneManager.LoadScene("Level 02 - alpha");
		}
		else if (PlayerPrefs.GetInt("Cena") == 3)
		{
			SceneManager.LoadScene("Level 03 - alpha");
		}*/
		//transform.position = levelManager.currentCheckpoint.transform.position;

	}
	void setCountText()
	{
		countText.text = "Hey Apple! " + appleCont.ToString();
	}
	void gameOver()
	{
		
		gameover = true;
		anim.SetBool("gameover",gameover);
		anim.Play("Antonito Death");

		morte.Play();

		fade.fadeOut();
		Invoke("LoadScreen", 2);
	}

	void desativarWarning()
	{
		warning.SetActive (false);
	}

	public void blockPlayer()
	{
		isEvent = true;
	}

	public void unblockPlayer()
	{
		isEvent = false;
	}

}