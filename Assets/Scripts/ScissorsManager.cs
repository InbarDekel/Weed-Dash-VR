using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsManager : MonoBehaviour
{
    Animator m_Animator;
    public SpaceShipScript spaceShip;
    public AudioClip audioClip;
    public AudioSource audioSource;
    private bool enableCut = false;
    private float cutTime;

    void Start()
    {
        audioSource.clip = audioClip;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            m_Animator.SetTrigger("Cut");
            audioSource.Play();
            enableCut = true;
            cutTime = Time.fixedTime;
        }

        if (enableCut && cutTime <= Time.fixedTime - 1)
        {
            enableCut = false;
        }

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name.Contains("Flower") && enableCut)
        {
            Light objectLight = other.transform.GetChild(0).GetComponent<Light>();
            if (other.transform.GetChild(0).GetComponent<Light>().intensity > 0)
            {
                other.transform.GetChild(0).GetComponent<Light>().intensity = 0;
                spaceShip.FollowSpeed += 0.02f;
                //spaceShip.FollowSpeed = 0.175f;
                //spaceShip.TargetDistance = 0f;
                //spaceShip.CutFlag = true;
                //policeOfficer.FollowSpeed = 0.15f;
                //policeOfficer.TargetDistance = 0f;
                //policeOfficer.CutFlag = true;
            }
        }
    }
}
