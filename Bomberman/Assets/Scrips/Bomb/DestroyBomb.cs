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
    float sphereRadius = 0.5f;

    List<Vector3> directions = new List<Vector3>();
    [SerializeField] private LayerMask layer;

    public AudioSource explosion;

    private void Awake()
    {
        directions.Add(transform.forward);
        directions.Add(-transform.forward);
        directions.Add(transform.right);
        directions.Add(-transform.right);
        explosion = GetComponent<AudioSource>();
        explosion.Play();
        explosion.Pause();
    }
    public void Update()
    {
        RaycastHit hit;

        destroTimer += 1 * Time.deltaTime;     
        explosion.UnPause();
        explosion.Pause();

        if (destroTimer >= destroyTime)
        {
            // explosion.Play();
            explosion.UnPause();

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

                if (Physics.SphereCast(transform.position, sphereRadius, directions[i], out hit, 0.5f, layer, QueryTriggerInteraction.UseGlobal))
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

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < directions.Count; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(directions[i], sphereRadius);
        }
    }
}
