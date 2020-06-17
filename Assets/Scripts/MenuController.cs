using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public AudioClip audioClip;
    public AudioSource audioSource;
    RaycastHit hit;
    Ray ray;
    Vector3 centerScreen = Vector3.zero;

    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
    }

    void Update()
    {
        string buttonName;
        ray = Camera.main.ScreenPointToRay(centerScreen);
        Debug.DrawRay(centerScreen, transform.forward, Color.blue);

        if (Physics.Raycast(ray, out hit) && Input.anyKey)
        {
            if (hit.rigidbody != null)
            {
                buttonName = hit.rigidbody.transform.name.ToLower();
                
                if (buttonName == "start")
                {
                    SceneManager.LoadScene(2);
                }
                else if (buttonName == "exit")
                {
                    Application.Quit();
                }
                else if (buttonName == "howtoplay")
                {
                    SceneManager.LoadScene(1);
                }
            }

        }
    }

}
