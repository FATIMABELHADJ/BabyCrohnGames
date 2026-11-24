using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayButton()
    {
        audioSource.Play();
    }
     
}
