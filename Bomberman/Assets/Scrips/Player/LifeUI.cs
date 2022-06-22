using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private Text lifesLeft;
   

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    void Start()
    {
        lifesLeft.text = PlayerPrefs.GetInt("PlayerLife").ToString();
    }

    void Update()
    {
        lifesLeft.text = "Lifes left: " + PlayerPrefs.GetInt("PlayerLife").ToString();
    }
}
