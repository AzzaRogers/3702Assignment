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
        moveX = 0.0f;
        moveY = 0.0f;
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

        // move player
        transform.Translate(moveX * moveSpeed *  Time.deltaTime, 0.0f, moveY * moveSpeed * Time.deltaTime, Space.World);

        // calculate angle
        float angle = Mathf.Atan2(moveX, moveY) * Mathf.Rad2Deg;

        // check for needed rotation
        if(moveX != 0f || moveY != 0f)
            transform.rotation =  Quaternion.Euler(0f, angle, 0f);
    }
}
