using UnityEngine;
using UnityEngine.UI;

public class BananaBombLauncher : MonoBehaviour
{
    public BananaBomb BananaBombPrefab;
    public float Cooldown = 10f;
    public Image SpellIcon;
    float _timer = 0f;
    void Update()
    {
      
            //Обновляем таймер и иконку
            _timer += Time.deltaTime;
            UpdateUltimateIcon();

            //Если нажата клавиша способности и таймер больше времени перезарядки
            if (Input.GetMouseButtonDown(1) && _timer >= Cooldown)
            {
                FireBullet();
            }
       
        
    }

    void FireBullet()
    {
        BananaBomb Grenade = Instantiate(BananaBombPrefab, transform.position, transform.rotation);
        Grenade.transform.LookAt(GetTargetPoint());
        _timer = 0f;
    }

    Vector3 GetTargetPoint()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return ray.GetPoint(100);
    }
    void UpdateUltimateIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = _timer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
