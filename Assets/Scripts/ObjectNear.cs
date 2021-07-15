using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNear : MonoBehaviour
{

    [SerializeField]
    private GameObject card1;

    [SerializeField]
    private GameObject card2;

    [SerializeField]
    private int distanceFromCard;

    [SerializeField]
    private AudioSource music;

    private bool stopAndPlay;
    private bool inputChanged;

    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        stopAndPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(card1.transform.position, card2.transform.position) < distanceFromCard)
        {
            Debug.Log(stopAndPlay);
            if (!stopAndPlay)
            {
                //Debug.Log("OK");
                stopAndPlay = true;
                music.Play();
            }
        } else
        {
            Debug.Log(stopAndPlay);
            if (stopAndPlay)
            {
                stopAndPlay = false;
                music.Stop();
            }
        }
    }
}
