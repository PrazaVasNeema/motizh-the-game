using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform m_tool;
    

    public float range = 30f;
    public float speed = 1f;
    private float m_timer = 0f;

    private bool m_isDown = false;

    private void Update()
    {

        // Вектор углов снизу (локальный)
        var angels = m_tool.localEulerAngles;

        // Изменение от -1 до 1
        // Обычно препод обращается к косинусу
        m_timer += Time.deltaTime; // синхронизируем со временем
//        var x = Mathf.Cos(Mathf.PI * m_timer * speed) * range;
        var target = range * (m_isDown ? range -1f : 1f);
        var x = Mathf.MoveTowardsAngle(angels.x, target, speed * Time.deltaTime);
        angels.x = x;

        m_tool.localEulerAngles = angels;
    }

    public void OnDown()
    {
        Debug.Log("OnDown");
        m_isDown = true;
    }

    public void OnUp()
    {
        Debug.Log("OnUp");
        m_isDown = false;
    }
}
