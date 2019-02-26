using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {
    private float startY;
    private Animator anim;
    private float speed = 5f;
    private int hp = 1;

    private Camera mainCamera;
    public Vector2 widthThresold;
    public Vector2 heightThresold;
    // Use this for initialization
    void Start () {
        //get the intitial y position
        startY = transform.position.y;

        //get the animator
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hp > 0)
        {
            Vector2 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //if the enemy is dead, don't do anything
        if (hp <= 0)
            return;
        
            //if you collided with the player, then do something to the player
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                TakeDamage(hp);
                player.CollidedWithTree(this);
            }

      

        
    }

    void TakeDamage(int amount)
    {
        //subtract the damage amount from the enemie's hp
        hp -= amount;

        //if out of hp, die
        if (hp <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        hp = 0;

        Destroy(gameObject);
        //trigger the explosion animation
        //anim.SetTrigger("Explode");

        //in half a second, call the CleanUp function
        //Invoke("CleanUp", 0.5f);
       
    }

    void DestroyIfOffscreen()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
            Destroy(gameObject);
    }

    void CleanUp()
    {
        //remove this object from the scene
        Destroy(gameObject);
    }
}
