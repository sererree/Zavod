using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 100;
    public Slider Healthbar;

    //Не забудь указать ссылки на эти UI элементы в сцене
    public GameObject PlayerUI;
    public GameObject GameOverUI;
    public float _currentValue;
    public GameObject WeaponGO;
    public GameObject End;

    public AudioSource Background;
    

    void Start()
    {
        _currentValue = MaxValue;
        UpdateHealthbar();
        End.GetComponent<AudioSource>().enabled = false;
    }

    public void TakeDamage(float damage)
    {
        _currentValue -= damage;
        if (_currentValue <= 0)
        {
            _currentValue = 0;
            //Если здоровья не осталось, вызвать метод конца игры
            GameOver();
        }
        UpdateHealthbar();
    }
    public void AddHealth(float amount)
    {
        _currentValue += amount;
        if (_currentValue > MaxValue)
        {
            _currentValue = MaxValue;
        }
        //HealEffect.GetComponent<ParticleSystem>().Play();
        UpdateHealthbar();
    }

    void UpdateHealthbar()
    {
        Healthbar.value = _currentValue / MaxValue;
    }

    void GameOver()
    {
        //включить или отключить объекты и компоненты
        PlayerUI.SetActive(false);
        GameOverUI.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        WeaponGO.GetComponent<Weapon>().enabled = false;
        WeaponGO.GetComponent<BananaBombLauncher>().enabled = false;
        Background.Pause();
        End.GetComponent<AudioSource>().enabled = true;
    }

    
}
