using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IDamageable
{
    int RycastAmount = 4;
    List<Vector3> directions = new List<Vector3>();
    List<Vector3> availableDirections = new List<Vector3>();
    int listRandom;
    int directionIs;

    [SerializeField] private float m_Speed;

    Rigidbody m_Rigidbody;

    int truncatedDistance;
    float range = 1f;
    float megaRange = 40f;
    float distance;
    float redutionZ = 1f;//0.80f;
    float redutionX = 1f;//0.80f;
    bool destiny;

    Vector3 TargetPos;

    private void Awake()
    {
        //4 direcciones a las que se tiran raycast
        directions.Add(transform.forward);
        directions.Add(-transform.forward);
        directions.Add(transform.right);
        directions.Add(-transform.right);

        m_Rigidbody = GetComponent<Rigidbody>();
        destiny =false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        // si no tengo un destino
        if (!destiny)
        {
            availableDirections.Clear();
            RaycastHit hit;
            //se tiran los 4 rayos, los que no tocan ningun bloqeu se guardan en una lsita
            for (int i = 0; i < RycastAmount; i++)
            {
                if (!Physics.Raycast(transform.position, directions[i], out hit, range))
                {
                    availableDirections.Add(directions[i]);
                }
            }

            //se elegi un elemento random de esa lista
            listRandom = Random.Range(0, availableDirections.Count);
            if (listRandom > 0)
            {
                listRandom = 0;
            }

            //error: redundancia
            destiny = true;

            //raycast mas largo para saber a cuanta distancia esta el proximo bloque
            if (Physics.Raycast(transform.position, availableDirections[listRandom], out hit, megaRange))
            {
                distance = Vector3.Distance(hit.transform.position, gameObject.transform.position);
                truncatedDistance = (int)distance;
            }

            TargetPos = transform.position+(truncatedDistance * availableDirections[listRandom]);
            Debug.Log(TargetPos);

            if (availableDirections[listRandom] == directions[0])
            {
                directionIs = 0;
            }

            for (int i = 0; i < RycastAmount; i++)
            {
                if (availableDirections[listRandom] == directions[i])
                {
                    directionIs = i;
                    Debug.Log(directionIs);
                }
            }

            //bool a negativo para que el proceso solo se haga un vez hasta que el jugador llegue al destino
            destiny = true;
            Debug.Log(destiny);
        }
        else
        {
            switch (directionIs)
            {              
                case 0:
                    if (transform.position.z >= TargetPos.z - redutionZ)
                    {
                        destiny = false;
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 1:
                    if (transform.position.z <= TargetPos.z + redutionZ)
                    {
                        destiny = false; 
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 2:
                    if (transform.position.x >= TargetPos.x - redutionX)
                    {
                        destiny = false;
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                    }
                    break;
                case 3:
                    if (transform.position.x <= TargetPos.x + redutionX)
                    {
                        destiny = false;
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
    }

    public void damageable()
    {
        Destroy(gameObject);
    }
}
