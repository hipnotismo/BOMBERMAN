using UnityEngine;

namespace bomberman
{
    public class Options : MonoBehaviour
    {
        public static Options inst;

        private void Awake()
        {
            if (Options.inst == null)
            {
                Options.inst = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }

    }
}