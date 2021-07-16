using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistanceManager : MonoBehaviour
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
    private int distanceBetweenCard;

    [SerializeField]
    private AudioSource music;

    private bool stopAndPlay;
    private bool inputChanged;

    private Animator animCard1Model;
    private Animator animCard2Model;

    // Start is called before the first frame update
    void Start()
    {
        animCard1Model = model1.GetComponent<Animator>();
        animCard2Model = model2.GetComponent<Animator>();
        animCard1Model.enabled = false;
        animCard2Model.enabled = false;
        stopAndPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleDistance();
    }

    private void HandleDistance()
    {
        if (Vector3.Distance(card1.transform.position, card2.transform.position) < distanceBetweenCard)
        {
            if (!stopAndPlay)
            {
                stopAndPlay = true;
                music.Play();
                animCard1Model.enabled = true;
                animCard2Model.enabled = true;
            }
        }
        else
        {
            if (stopAndPlay)
            {
                stopAndPlay = false;
                music.Stop();
                animCard1Model.enabled = false;
                animCard2Model.enabled = false;
            }
        }
    }
}
