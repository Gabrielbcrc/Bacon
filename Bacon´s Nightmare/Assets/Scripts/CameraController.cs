using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public GameObject player;
	private Vector3 offset;
	//public float limitY;
	//public float inicialY;

	public bool bounds;

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	// Use this for initialization
	void Start () 
	{
		//player = GameObject.FindGameObjectsWithTag ("Player");
		//offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	/*void LateUpdate () 
	{
		if (player.transform.position.y < limitY) 
		{
			transform.position = new Vector3 (player.transform.position.x, inicialY, offset.z);
			//transform.position = player.transform.position + offset;
		} else 
		{
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, offset.z);
			//transform.position = player.transform.position + offset;
		}

	}*/

	void FixedUpdate()
	{
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds) 
		{
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}

}