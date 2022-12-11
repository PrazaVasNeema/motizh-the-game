using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Можно дублировать классы
namespace Game{ // Чтобы скрывать доступ к реализациям, без namespace скрипт является глобальным
// Carx.gdfg.dffg библио подраздел



public class Stone : MonoBehaviour
{
    // Получить ссылку можно:
    [SerializeField] // Передав вручную
//    [RequireComponent](typeof(Rigidbody))
    private Rigidbody m_rigidbody;

    private bool m_isAffect = true;

    public void SetAffect(bool isAffect)
    {
        m_isAffect = isAffect;
    }

    private void Awake()
    {
        if( m_rigidbody == null) // Оставляем пространство для маневра
            m_rigidbody = GetComponent<Rigidbody>(); // Через это, но может не быть нужного компонента
        
//        Physics. // Можно запускать проверку с вшешним миром (через касты)
    }

    private void OnCollisionEnter(Collision other)
    {
//        Debug.Log(other.gameObject.name, this);
        if(other.gameObject.TryGetComponent<Stone>(out var stone))
        {
            if(m_isAffect && stone.m_isAffect) // Приватное поле этого же класса, но другого объекта
            {
                // LOSE
                GameEvents.onGameOver?.Invoke();
                m_isAffect = false;
            }
        }
    }
}

}


// Надо стараться всегда применять их метода (не изменять напрямую, к примеру, velocity)