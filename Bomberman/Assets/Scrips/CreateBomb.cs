using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform playerPos;
    private bool CoolDown;

    void Start()
    {
        CoolDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && CoolDown)
        {
            Instantiate(bomb, new Vector3(Mathf.Round(playerPos.position.x), 0.5f /**Mathf.Round(playerPos.position.y)*/,
                Mathf.Round(playerPos.position.z)), playerPos.rotation);
            CoolDown = !CoolDown;
            StartCoroutine(BombDelay());
        }
    }

    IEnumerator BombDelay()
    {
        yield return new WaitForSeconds(3);
        CoolDown = !CoolDown;
    }
}
