using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    public GameObject player;
    private bool isDoorOpened = false;
    private Transform originalTransform;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update() 
    {
        //print(Vector3.Distance(transform.position, player.transform.position));
        if (!isDoorOpened && Vector3.Distance(transform.position, player.transform.position) < 11)
        {
            //print("Open: " + Vector3.Distance(transform.position, player.transform.position));
            transform.rotation = Quaternion.identity;
            transform.RotateAround(transform.position + new Vector3(-5.0f, 0, 0), Vector3.down, 40.0f);
            isDoorOpened = true;
            //GetComponent<AudioSource>().PlayOneShot(aClip);
        }
        else if (isDoorOpened && Vector3.Distance(transform.position, player.transform.position) > 20)
        {
            isDoorOpened = false;
            //print("Close: " + Vector3.Distance(transform.position, player.transform.position));
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}
