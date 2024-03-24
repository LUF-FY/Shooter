using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 100;
    public Slider Healthbar;

    public GameObject PlayerUI;
    public GameObject GameOverUI;


    public GameObject WinUI;
    public int enemyConut;


    float _currentValue;
    

    void Start()
    {
        //нахожу всех врагов
        enemyConut = FindObjectsOfType<EnemyHealth>().Length;

        _currentValue = MaxValue;
        UpdateHealthbar();
    }

    //Ее мы вызываем когда моб умирает
    public void DesraceEnemyCount()
    {
        enemyConut--;
        if (enemyConut <= 0)
        {
            WinUI.SetActive(true);
            EndGame();
        }
    }

    public void TakeDamage(float damage)
    {
        _currentValue -= damage;
        if (_currentValue <= 0)
        {
            _currentValue = 0;
            GameOver();
        }
        UpdateHealthbar();
    }

    void UpdateHealthbar()
    {
        Healthbar.value = _currentValue / MaxValue;
    }

    void GameOver()
    {
        PlayerUI.SetActive(false);
        GameOverUI.SetActive(true);
        EndGame();
    }

    void EndGame()
    {
        GetComponent<Player>().enabled = false;
        GetComponent<CameraController>().enabled = false;
    }


}
