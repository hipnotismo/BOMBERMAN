using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, Iterface
{
    int RycastAmount = 4;
    List<Vector3> directions = new List<Vector3>();
    List<Vector3> AvailableDirections = new List<Vector3>();
    int ListRandom;
    private float m_Speed = 3f;

    Rigidbody m_Rigidbody;

    float range = 1f;
    float MegaRange = 40f;
    float distance;
    int TruncatedDistance;
    bool Destiny;
    bool There;
    Vector3 TargetPos;

    private void Awake()
    {
        directions.Add(transform.forward);
        directions.Add(-transform.forward);
        directions.Add(transform.right);
        directions.Add(-transform.right);

        m_Rigidbody = GetComponent<Rigidbody>();
        Destiny = true;
        There = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
       

        if (Destiny)
        {
            RaycastHit hit;

            Vector3 forward = transform.TransformDirection(Vector3.forward) * 1;

            Debug.DrawRay(transform.position, forward, Color.green);

            for (int i = 0; i < RycastAmount; i++)
            {

                if (Physics.Raycast(transform.position, directions[i], out hit, range))
                {

                }
                else
                {
                    AvailableDirections.Add(directions[i]);
                }

            }

            ListRandom = Random.Range(0, AvailableDirections.Count);
            Destiny = true;

            if (Physics.Raycast(transform.position, AvailableDirections[ListRandom], out hit, MegaRange))
            {
                distance = Vector3.Distance(hit.transform.position, gameObject.transform.position);
                TruncatedDistance = (int)distance;
                There = true;

            }
            TargetPos = transform.position+(TruncatedDistance* AvailableDirections[ListRandom]);
            Destiny = false;

        }
        else
        {
            if (transform.position == TargetPos)
            {
                Destiny = true;

            }
            else
            {
                m_Rigidbody.MovePosition(transform.position + AvailableDirections[ListRandom] * Time.deltaTime * m_Speed);
            }

        }

        //if (There)
        //{
        //    if (transform.position != AvailableDirections[ListRandom])
        //    {
        //        m_Rigidbody.MovePosition(transform.position + AvailableDirections[ListRandom] * Time.deltaTime * m_Speed);
        //    }
        //    else
        //    {
        //        There = false;
        //    }

        //}

    }

    public void damageable()
    {
        Destroy(gameObject);
    }
}
