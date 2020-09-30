using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera aCamera;
    public GameObject target;
    public GameObject GunEnd;
    LineRenderer ShotLine;
    WaitForSeconds ShotDuration = new WaitForSeconds(0.1f);
    public AudioClip aClip;
    public GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        ShotLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Shoot") || Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(aClip);

            RaycastHit hit;
            if(Physics.Raycast(aCamera.transform.position,aCamera.transform.forward,out hit)) // if the ray has hit some object
            {
                // GetComponent<AudioSource>().PlayOneShot(aClip); 
                StartCoroutine(GunShooting());
                target.transform.position = hit.point;
                ShotLine.SetPosition(0, GunEnd.transform.position);
                ShotLine.SetPosition(1, hit.point);

                if( Vector3.Distance(hit.point,npc.transform.position) < 5)
                {
                    npc.GetComponent<NPCMotion>().Hurt();
                }
                    
             }
        }
    }

    IEnumerator GunShooting()
    {
       ShotLine.enabled = true;
       yield return ShotDuration;
       ShotLine.enabled = false;
    }
}
