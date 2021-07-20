using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolume : MonoBehaviour
{
    public AudioSource Audio; // our audio to be played
    public float audioVolume = 0.4f;
    public GameObject cam;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Audio.volume = audioVolume;
    }

    public void updateVolume(float volume)
    {
        audioVolume = volume;
    }
    public void Enable()
    {
        cam.GetComponent<AudioSource>().enabled = true;
    }
}
