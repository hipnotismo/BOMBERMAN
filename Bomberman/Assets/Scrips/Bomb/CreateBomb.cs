using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bomberman
{
    public class CreateBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bomb;
        private bool CoolDown;

        void Start()
        {
           
            CoolDown = true;
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump") && CoolDown)
            {
                Instantiate(bomb, new Vector3(Mathf.Round(transform.position.x), 0.5f,
                 transform.position.z), transform.rotation);
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
}
