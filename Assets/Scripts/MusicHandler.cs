using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    AudioSource music;
    bool stopAndPlay;
    bool inputChanged;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        stopAndPlay = false;
        inputChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)){
            stopAndPlay = !stopAndPlay;
            inputChanged = true;
            Debug.Log("I Get There");
        }
        
        if (stopAndPlay & inputChanged) {
            Debug.Log("Play");
            music.Play();
        } else if (!stopAndPlay & inputChanged){
            Debug.Log("Stop");
            music.Stop();
        }

        inputChanged = false;
    }
}
