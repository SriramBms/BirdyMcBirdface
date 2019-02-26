using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour {
    private float startY;
    private Animator anim;
    private float speed = 2f;
    private SpriteRenderer sprite;
    private string sortingLayer = "Clouds";
    // Use this for initialization
    void Start () {
        startY = transform.position.y;

        //get the animator
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        if (sprite)
        {
            sprite.sortingOrder = 0;
            sprite.sortingLayerName = sortingLayer;
        }
    }
	
	// Update is called once per frame
	void Update () {
        MoveCloud();
    }

    private void MoveCloud()
    {
        //keep moving to the right
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetSortingLayer(string layerName)
    {
        sortingLayer = layerName;
    }

    void CleanUp()
    {
        //remove this object from the scene
        Destroy(gameObject);
    }
}
