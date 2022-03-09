using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string bird;
    public TextMesh birdText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        birdText.text = bird;
        //left restricted
        if (transform.position.x < 0)
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        //right restricted
        if (transform.position.x > 8)
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        //down restricted
        if (transform.position.z < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //up restricted
        if (transform.position.z > 8)
            transform.position = new Vector3(transform.position.x, transform.position.y, 8);
        
        //movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(new Vector3(0,0,2));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(new Vector3(0,0,-2));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(new Vector3(-2,0,0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(new Vector3(2,0,0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //display bird on cube
        bird = collision.gameObject.GetComponent<BirdOnCube>().getBird();
        Debug.Log(bird);
    }

}
