using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HTPController : MonoBehaviour
{

    RaycastHit hit;
    Ray ray;
    Vector3 centerScreen = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        string buttonName;
        ray = Camera.main.ScreenPointToRay(centerScreen);
        Debug.DrawRay(centerScreen, transform.forward, Color.blue);

        if (Physics.Raycast(ray, out hit) && Input.anyKeyDown)
        {
            if (hit.rigidbody != null)
            {
                buttonName = hit.rigidbody.transform.name.ToLower();

                if (buttonName == "back")
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

    }
}

