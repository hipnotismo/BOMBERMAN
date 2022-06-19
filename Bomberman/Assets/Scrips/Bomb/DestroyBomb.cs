using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyBomb : MonoBehaviour
{

    public static Action OnBoxDestroyed;

    int destroyTime = 1;
    float destroTimer =0;
    float range = 1f;
    int RycastAmount = 4;
    List<Vector3> directions = new List<Vector3>();

    public AudioSource explosion;

    private void Awake()
    {
        directions.Add(transform.forward);
        directions.Add(-transform.forward);
        directions.Add(transform.right);
        directions.Add(-transform.right);
    }
    void Update()
    {
        RaycastHit hit;

        destroTimer += 1 * Time.deltaTime;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1;

        Debug.DrawRay(transform.position, forward, Color.green);
        Debug.Log(destroTimer);
        if (destroTimer > destroyTime)
        {
            explosion.Play();
            for (int i = 0; i < RycastAmount; i++)
            {

                if (Physics.Raycast(transform.position, directions[i], out hit, range))
                {
                    Debug.Log(hit.collider.name);
                    Iterface isHit = hit.collider.GetComponent<Iterface>();

                    if (isHit != null)
                    {                       
                        isHit.damageable();
                        OnBoxDestroyed?.Invoke();
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
