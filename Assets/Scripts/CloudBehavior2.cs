using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior2 : MonoBehaviour
{
    private float startY;
    private Animator anim;
    private float speed = 1f;
    // Use this for initialization
    void Start()
    {
        startY = transform.position.y;

        //get the animator
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCloud();
    }

    private void MoveCloud()
    {
        //keep moving to the right
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    void CleanUp()
    {
        //remove this object from the scene
        Destroy(gameObject);
    }
}
