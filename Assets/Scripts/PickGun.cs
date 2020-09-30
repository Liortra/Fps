using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{

    public GameObject GunOnTable;
    public GameObject GunInHand;
    public GameObject Aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GunOnTable.SetActive(false);
        GunInHand.SetActive(true);
        Aim.SetActive(true);
    }
}
