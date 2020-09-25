using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    // Player variables
    public float moveSpeed = 5.0f;
    float moveX = 0.0f;
    float moveY = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("coin")) { 
            Debug.Log("Collided with " + collision.gameObject.tag);
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("wall")) {
            Debug.Log("Collided with " + collision.gameObject.tag);
            moveX = 0.0f;
            moveY = 0.0f;
        } else if (collision.gameObject.CompareTag("Ghost")) {
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        // get inputs
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 || inputY != 0) {
            moveX = inputX;
            moveY = inputY;
        }
        if (moveX < 0 || moveX > 0 ) {
            moveY = 0;
        }
        if (moveY < 0 || moveY > 0) {
            moveX = 0;
        }

        // move player
        transform.Translate(moveX * moveSpeed *  Time.deltaTime, 0.0f, moveY * moveSpeed * Time.deltaTime, Space.World);

        // calculate angle
        float angle = Mathf.Atan2(moveX, moveY) * Mathf.Rad2Deg;

        // check for needed rotation
        if(moveX != 0f || moveY != 0f)
            transform.rotation =  Quaternion.Euler(0f, angle, 0f);
    }
}
