using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpaceShipScript : MonoBehaviour
{
    private float startTime;
    public float FollowSpeed = 0.05f;
    public bool endSequence = false;
    public PlayerControl player;
    public RaycastHit Shot;
    private Vector3 moveDirection;
    private float distance;
    private Light shipLight;

    private void Start()
    {
        shipLight = this.GetComponent<Light>();
        shipLight.intensity = 0;
        startTime = Time.fixedTime;
    }

    void Update()
    {
        if (endSequence)
        {
            shipLight.intensity += 1;
        }
        else
        {
            moveDirection = Camera.main.transform.position;
            moveDirection.y = 0f;
            distance = Vector3.Distance(moveDirection, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, moveDirection, FollowSpeed);
            transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
            if (distance < 6.1)
            {
                transform.position = new Vector3(Camera.main.transform.position.x, 6f, Camera.main.transform.position.z);
                player.PlayerSpeed = 0f;
                endSequence = true;
            }

        }
        if (shipLight.intensity >= 100 || Time.fixedTime > startTime + 180)
        {
            player.audioSource.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }
}
