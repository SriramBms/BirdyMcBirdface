using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Transform bullet;

	private float speed = 10f;

	private Animator animator;
	private Transform bulletHolder;
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider;
	
	private const float timeToShoot = 0.2f;
	private float timeSinceShot = 0f;
	private bool shooting = false;
	private float maxY, maxX;
	private bool alive = true;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		spriteRenderer = GetComponent<SpriteRenderer> ();
        boxCollider = GetComponent<BoxCollider2D> ();

		//this is an empty game object on the player that will be used so we know where to place bullets
		bulletHolder = transform.Find ("bullet_holder");

		//find the camera bounds so that we do not leave the screen
		//note that this function is defined in Extensions.cs and is not a default part of unity
		Bounds cameraBounds = Camera.main.OrthographicBounds ();
		maxY = cameraBounds.max.y;
		maxX = cameraBounds.max.x;

		float spriteHeight = (transform.localScale.y / GetComponent<SpriteRenderer> ().sprite.bounds.size.y);
		maxY -= spriteHeight;
		maxX -= spriteHeight;

		//keep track of the intial position
		startPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
		//only do stuff if you are still alive
		if (alive) {
			CheckShooting ();

			MovePlayer ();
		}

	}

	void CheckShooting(){
		//if we are currently shooting, test to see if we need to create a new bullet
		//this is so we do not create a new bullet every frame
		if (shooting) {
			timeSinceShot += Time.deltaTime;
			if(timeSinceShot > timeToShoot){
				Shoot ();
			}
		}

		//allow the player to hold down the space button to keep on shooting
		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetBool("Shooting", true);
			shooting = true;
			Shoot ();
		}else if(Input.GetKeyUp(KeyCode.Space)){
			shooting = false;
			animator.SetBool("Shooting", false);
		}
	}
	
	
	void Shoot(){
		//reset the time since a shot
		timeSinceShot = 0f;

		//create a new bullet and assign it the position of the bullet holder
		//that is an empty game object on the player which allows us to place the bullet at a specific place rather than in the middle of our ship
		Transform newBullet = Transform.Instantiate (bullet);
		newBullet.position = bulletHolder.position;
	}
	void MovePlayer(){
		//check for movement

		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		Vector2 pos = transform.position;
		pos.y += vertical * speed * Time.deltaTime;
		pos.x += horizontal * speed * Time.deltaTime;
		
		//make sure we don't go off the screen
		pos.y = Mathf.Clamp(pos.y, maxY * -1, maxY);
		pos.x = Mathf.Clamp(pos.x, maxX * -1, maxX);
		
		
		transform.position = pos;
	}

    public void CollidedWithTree(TreeScript tree)
    {
        Debug.Log("Hit by tree");
    }

	void Die(){
		//in a second, call the RestartLevel function
		Invoke ("RestartLevel", 1f);

	}

	void RestartLevel(){
		//Reload the level/scene
		Application.LoadLevel (0);
	}


}
