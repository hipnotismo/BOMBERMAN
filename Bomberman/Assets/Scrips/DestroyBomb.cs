using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    int destroyTime = 3;
    float destroTimer =0;
    float range = 40f;

    void Update()
    {
        RaycastHit hit;

        //Destroy(gameObject,3f);
        destroTimer += 1 * Time.deltaTime;
        Debug.Log(destroTimer);
        if (destroTimer > destroyTime)
        {
            if (Physics.Raycast(transform.position, transform.forward,out hit, range))
            {
                Debug.Log(hit.transform);

            }
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green,4f);
            Debug.Log("its time");

        }
    }
}
