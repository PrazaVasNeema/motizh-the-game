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

        /*        private Vector3 m_plowForwardVector;
                private Vector3[] m_impulseDirections;*/
        /*  [SerializeField]
          private Transform m_plowTransform;*/
        [SerializeField]
        private Player player;
        private bool isDown = false;

    private void Start()
    {
        StartGame();
    }

/*        public void SetForwardOnStart(Vector3 plowForwardVector)
        {
            m_plowForwardVector = plowForwardVector;
            m_impulseDirections = new Vector3[2];
            m_impulseDirections[0] = new Vector3(plowForwardVector.x, 1f, plowForwardVector.z);
            m_impulseDirections[1] = new Vector3(-plowForwardVector.x, 1f, -plowForwardVector.z);
        }*/

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

    public void OnCollisionStone(Collision collision, Vector3 plowForwardVector)
    {
        // Понять, что это камень, можно через тег или через слой или через компонент
        if(collision.gameObject.TryGetComponent<Stone>(out var stone)) // Можно динамически создавать переменные
        {

            stone.SetAffect(false);
            var contact = collision.contacts[0]; // Лучше делать так, а не постоянно вызывать дальше
                Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);

                // А еще лучше сделать отдельный метод
                var body = contact.otherCollider.GetComponent<Rigidbody>();
                var m_impulseDirectionPositive = new Vector3(plowForwardVector.x, 1f, plowForwardVector.z);
                var m_impulseDirectionNegative = new Vector3(-plowForwardVector.x, 1f, -plowForwardVector.z);
                Debug.Log($"{contact.normal.x} {contact.normal.y} {contact.normal.z}");
                //            body.AddForce(-contact.normal * m_power, ForceMode.Impulse);
                //                body.AddForce((contact.normal.x * m_impulseDirections[0].x < 0 ? m_impulseDirections[0] : m_impulseDirections[1]) * m_power, ForceMode.Impulse);
                //body.AddForce((Vector3.Cross(m_plowTransform.forward, contact.normal).y > 0 ? m_impulseDirectionPositive : m_impulseDirectionNegative) * m_power, ForceMode.Impulse);
                body.AddForce((isDown ? m_impulseDirectionNegative : m_impulseDirectionPositive) * m_power, ForceMode.Impulse);
                foreach (var item in collision.contacts)
            {
                Debug.DrawRay(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
            }

                /*            if (stone.gameObject.tag == "Stone2") // Очень тяжело
                            {

                            }

                            if (stone.gameObject.CompareTag("Stone2")) // Почти бесплатно
                            {

                            }*/

            }
    }

        public void ChangePowlState()
        {
            isDown = !isDown;
            player.setIsDown(isDown);
        }

    private void OnDestroy()
    {
        GameEvents.onGameOver -= OnGameOver;
    }

}
}

// Коллизия - класс, содержащий информацию о столкновении двух тел
// Коллизия есть всегда