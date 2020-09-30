using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMotion : MonoBehaviour
{
    float speed;
    float minDist;
    private bool isHurt;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        minDist = 2;
      isHurt = false;
    }

    public void Hurt()
    {
        isHurt = true;
    }

    IEnumerator Die()
    {
        GetComponent<Animation>().Play("die");
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurt)
        {
            StartCoroutine(Die());

        }
        else
        {
            GetComponent<Animation>().Play("walk");
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.5f, out hit)) // check obstacle
            {
                if (hit.distance < minDist) // change direction
                {
                    float angle = Random.Range(-100, 100);
                    transform.Rotate(new Vector3(0, angle, 0));
                }
            }
        }

    }
}
