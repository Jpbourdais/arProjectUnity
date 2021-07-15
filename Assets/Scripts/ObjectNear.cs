using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNear : MonoBehaviour
{

    [SerializeField]
    private GameObject card1;

    [SerializeField]
    private GameObject model1;

    [SerializeField]
    private GameObject card2;

    [SerializeField]
    private GameObject model2;

    [SerializeField]
    private int distanceFromCard;

    [SerializeField]
    private AudioSource music;

    private bool stopAndPlay;
    private bool inputChanged;

    private Animation animCard1Model;
    private Animation animCard2Model;

    // Start is called before the first frame update
    void Start()
    {
        animCard1Model = model1.GetComponent<Animation>();
        animCard2Model = model2.GetComponent<Animation>();
        stopAndPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(card1.transform.position, card2.transform.position) < distanceFromCard)
        {
            if (!stopAndPlay)
            {
                stopAndPlay = true;
                music.Play();
                animCard1Model.Play("animation");
                animCard2Model.Play("animation");
            }
        } else
        {
            if (stopAndPlay)
            {
                stopAndPlay = false;
                music.Stop();
                animCard1Model.Stop("animation");
                animCard2Model.Stop("animation");
            }
        }
    }
}
