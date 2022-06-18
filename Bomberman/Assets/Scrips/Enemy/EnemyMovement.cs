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
    int directionIs;
    Rigidbody m_Rigidbody;

    float range = 1f;
    float megaRange = 40f;
    float distance;
    int truncatedDistance;
    bool destiny;
    float redution = 0.80f;
    Vector3 TargetPos;

    private void Awake()
    {
        //4 direcciones a las que se tiran raycast
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
            availableDirections.Clear();
            RaycastHit hit;
            //se tiran los 4 rayos, los que no tocan ningun bloqeu se guardan en una lsita
            for (int i = 0; i < RycastAmount; i++)
            {

                if (Physics.Raycast(transform.position, directions[i], out hit, range))
                {

                }
                else
                {
                    Debug.Log("DIR: " + directions[i]);
                    availableDirections.Add(directions[i]);
                }

            }
            //se elegi un elemento random de esa lista
            listRandom = Random.Range(0, availableDirections.Count);
            destiny = true;

            //raycast mas largo para saber a cuanta distancia esta el proximo bloque
            if (Physics.Raycast(transform.position, availableDirections[listRandom], out hit, megaRange))
            {
                distance = Vector3.Distance(hit.transform.position, gameObject.transform.position);
                truncatedDistance = (int)distance;

            }
            TargetPos = transform.position+(truncatedDistance * availableDirections[listRandom]);
            Debug.Log("listRandom: " + availableDirections[listRandom]);
            Debug.Log("Targetpos X: " + TargetPos.x );
            Debug.Log("Targetpos redsuction X: " + (TargetPos.x - redution));
            Debug.Log("Targetpos Z: " + TargetPos.z);
            Debug.Log("Targetpos redsuction Z: " + (TargetPos.z + redution));
            Vector3 jada = TargetPos;

            if (availableDirections[listRandom] == directions[0])
            {
                directionIs = 0;
            }

            for (int i = 0; i < RycastAmount; i++)
            {
                if (availableDirections[listRandom] == directions[i])
                {
                    directionIs = i;
                }
            }
            Debug.Log("directionIs: " + directionIs);

            //bool a negativo para que el proceso solo se haga un vez hasta que el jugador llegue al destino
            destiny = false;
        }
        else
        {
            switch (directionIs)
            {
                //case 0:
                //    if (transform.position.z >= TargetPos.z - redution)
                //    {
                //        destiny = true; Debug.Log("SALE0");
                //    }
                //    else
                //    {
                //        Debug.Log("Entra0");

                //        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                //    }
                //    break;
                //case 1:
                //    if (transform.position.z <= TargetPos.z + redution)
                //    {
                //        destiny = true; Debug.Log("SALE1");
                //    }
                //    else
                //    {
                //        Debug.Log("Entra1");

                //        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                //    }
                //    break;
                //case 2:
                //    if (transform.position.x >= TargetPos.x - redution)
                //    {
                //        Debug.Log("Sale2");
                //        destiny = true;
                //    }
                //    else
                //    {
                //        Debug.Log("Entra2");
                //        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                //    }
                //    break;
                //case 3:
                //    if (transform.position.x <= TargetPos.x + redution)
                //    {
                //        destiny = true;
                //        Debug.Log("SALE3");
                //    }
                //    else
                //    {
                //        Debug.Log("Entra3");
                //        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                //    }
                //    break;
                case 0:
                    if (transform.position.z >= TargetPos.z - redution)
                    {
                        destiny = true; Debug.Log("SALE0");
                    }
                    else
                    {
                        Debug.Log("Entra0");

                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 1:
                    if (transform.position.z <= TargetPos.z + redution)
                    {
                        destiny = true; Debug.Log("SALE1");
                    }
                    else
                    {
                        Debug.Log("Entra1");

                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 2:
                    if (transform.position.x >= TargetPos.x - redution)
                    {
                        Debug.Log("Sale2");
                        destiny = true;
                    }
                    else
                    {
                        Debug.Log("Entra2");
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 3:
                    if (transform.position.x <= TargetPos.x + redution)
                    {
                        destiny = true;
                        Debug.Log("SALE3");
                    }
                    else
                    {
                        Debug.Log("Entra3");
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
    }

    public void damageable()
    {
        Destroy(gameObject);
    }
}
