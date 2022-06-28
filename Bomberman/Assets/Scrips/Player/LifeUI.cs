using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace bomberman
{
    public class LifeUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text lifeTrac;
        [SerializeField] private Button inmune;
        void Awake()
        {
            PlayerLife.OnLifeUpdate += UpdateUILife;
            PlayerLife.OnPlayerDamage += ActiveteButton;
            PlayerLife.OnPlayerInmunityEnd += DeactiveButton;
        }

        private void OnDisable()
        {
            PlayerLife.OnLifeUpdate -= UpdateUILife;
            PlayerLife.OnPlayerDamage -= ActiveteButton;
            PlayerLife.OnPlayerInmunityEnd -= DeactiveButton;
        }

        void UpdateUILife(int life)
        {
            lifeTrac.text = life.ToString();
        }

        void ActiveteButton()
        {
            inmune.gameObject.SetActive(true);
        }

        void DeactiveButton()
        {
            inmune.gameObject.SetActive(false);
        }
    }
}