using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace bomberman
{
    public class LifeUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text lifeTrac;
  
        void Awake()
        {
            PlayerLife.OnLifeUpdate += UpdateUILife;
        }

        private void OnDisable()
        {
            PlayerLife.OnLifeUpdate -= UpdateUILife;

        }

        void UpdateUILife(int life)
        {
            lifeTrac.text = life.ToString();
        }
    }
}