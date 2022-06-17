using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, Iterface
{
    int RycastAmount = 4;
    List<Vector3> directions = new List<Vector3>();
    List<Vector3> availableDirections = new List<Vector3>();
    int listRandom;
    private float m_Speed = 3f;

    Rigidbody m_Rigidbody;

    float range = 1f;
    float megaRange = 40f;
    float distance;
    int truncatedDistance;
    bool destiny;
    float redution = 0.75f;
    Vector3 TargetPos;

    private void Awake()
    {
        directions.Add(transform.forward);
        directions.Add(-transform.forward);
        directions.Add(transform.right);
        directions.Add(-transform.right);

        m_Rigidbody = GetComponent<Rigidbody>();
        destiny = true;
    }

    void Start()
    {
        
    }

    void Update()
    {


        if (destiny)
        {
            //Debug.Log("listRandom pimera: " + listRandom);
            Debug.LogWarning("listRandom pimera: " + listRandom);

            RaycastHit hit;

            for (int i = 0; i < RycastAmount; i++)
            {

                if (Physics.Raycast(transform.position, directions[i], out hit, range))
                {

                }
                else
                {
                    availableDirections.Add(directions[i]);
                }

            }

            listRandom = Random.Range(0, availableDirections.Count);

            destiny = true;


            if (Physics.Raycast(transform.position, availableDirections[listRandom], out hit, megaRange))
            {
                distance = Vector3.Distance(hit.transform.position, gameObject.transform.position);
                truncatedDistance = (int)distance;

            }
            TargetPos = transform.position+(truncatedDistance * availableDirections[listRandom]);
      //      Debug.Log("TargetPos: " + TargetPos);
            Vector3 jada = TargetPos;

            Debug.Log("TargetPos minus: " + jada);
            Debug.Log("listRandom segunda: " + listRandom);

            destiny = false;

        }
        else
        {

            switch (listRandom)
            {
                case 0:
                    if (transform.position.z >= TargetPos.z - redution)
                    {
                        destiny = true;
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 1:
                    if (transform.position.x >= TargetPos.x - redution)
                    {
                        destiny = true;
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 2:
                    if (transform.position.x <= TargetPos.x - redution)
                    {
                        destiny = true;
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 3:
                    if (transform.position.z <= TargetPos.z - redution)
                    {
                        destiny = true;
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
            }
        }

        Debug.DrawRay(transform.position, directions[0], Color.red);
        Debug.DrawRay(transform.position, directions[1], Color.green);
        Debug.DrawRay(transform.position, directions[2], Color.blue);
        Debug.DrawRay(transform.position, directions[3], Color.cyan);

        Debug.DrawRay(transform.position, availableDirections[listRandom] * megaRange, Color.red);
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
