using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{

public class GameController : MonoBehaviour
{
    [SerializeField] // Берем за привычку все защищать
    private StoneSpawner m_stoneSpawner;
    private float m_timer = 0f;
    [SerializeField]
    private float m_delay = 1f;

    [SerializeField]
    private float m_power = 100f;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameEvents.onGameOver += OnGameOver; // Подписались
    }

    private void OnGameOver()
    {
        GameEvents.onGameOver -= OnGameOver;
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_delay)
        {
            m_stoneSpawner.Spawn();
            m_timer -= m_delay;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Понять, что это камень, можно через тег или через слой или через компонент
        if(collision.gameObject.TryGetComponent<Stone>(out var stone)) // Можно динамически создавать переменные
        {
            stone.SetAffect(false);
            var contact = collision.contacts[0]; // Лучше делать так, а не постоянно вызывать дальше
            // А еще лучше сделать отдельный метод
            var body = contact.otherCollider.GetComponent<Rigidbody>();
            body.AddForce(contact.normal * m_power);
            Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);

            if (stone.gameObject.tag == "Stone2") // Очень тяжело
            {

            }

            if (stone.gameObject.CompareTag("Stone2")) // Почти бесплатно
            {

            }

        }
    }

    private void OnDestroy()
    {
        GameEvents.onGameOver -= OnGameOver;
    }

}
}

// Коллизия - класс, содержащий информацию о столкновении двух тел
// Коллизия есть всегда