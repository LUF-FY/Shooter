using UnityEngine;
using UnityEngine.UI;

public class UltimateHex : MonoBehaviour
{
    //Ссылка на префаб эффекта
    public GameObject HexEffectPrefab;
    //Ссылка на префаб утки
    public GameObject Duck;
    //Ссылка на иконку способности
    public Image SpellIcon;
    //Время перезарядки
    public float Cooldown = 10f;

    float _timer = 0f;

    void Update()
    {
        //Обновляем таймер и иконку
        _timer += Time.deltaTime;
        UpdateUltimateIcon();

        //Если нажата клавиша способности и таймер больше времени перезарядки
        if (Input.GetKeyDown(KeyCode.Q) && _timer >= Cooldown)
        {
            CastHex();
        }
    }
    
    void CastHex()
    {
        //Находим всех врагов
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        //Проходим по всем врагам
        foreach (EnemyHealth enemy in enemies)
        {
            //Уничтожаем врага, создаем на месте врага эффект превращения и утку
            Destroy(enemy.gameObject);
            Instantiate(HexEffectPrefab, enemy.transform.position, Quaternion.Euler(-90, 0, 0));
            Instantiate(Duck, enemy.transform.position + Vector3.up * 2, enemy.transform.rotation);
        }
        //Сбрасываем таймер
        _timer = 0;
    }

    void UpdateUltimateIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = _timer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
