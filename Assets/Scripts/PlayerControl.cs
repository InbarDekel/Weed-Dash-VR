using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float PlayerSpeed = 0.1f;
    private Vector3 moveDirection;
    public AudioClip audioClip;
    public AudioSource audioSource;

    void Start () {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        // should be changed to work with cardboard controls
        if (Input.GetKey("space"))
        {
            moveDirection = Camera.main.transform.forward;
            moveDirection.y = 0.0f;
            Vector3.Normalize(moveDirection);
            transform.position = transform.position + (moveDirection * PlayerSpeed);
            if (transform.position.x > 180f)
                transform.position = new Vector3(180f, 2f, transform.position.z);
            else if (transform.position.x < 40f)
                transform.position = new Vector3(40f, 2f, transform.position.z);
            if (transform.position.z > 200f)
                transform.position = new Vector3(transform.position.x, 2f, 200f);
            else if (transform.position.z < 50f)
                transform.position = new Vector3(transform.position.x, 2f, 50f);
        }
	}
}
