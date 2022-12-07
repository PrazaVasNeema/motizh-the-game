using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    // Префаб - это шаблон, с чего делаем копию
    // Так как переменная публичная и класс наследуется от МоноБихейвора, то у нас есть описание
    [SerializeField]
    private GameObject[] stonePrefab; // Нельзя изменить извне, только можно и нужно настраивать именно в инспекторе
//    public GameObject stonePrefab;

    public void Spawn()
    {
//        this.gameObject // ссылка на свой гм
//        gameObject. // Тот, на котором висит скрипт
        Vector3 position = transform.position; // трансформ - это ссылка
        Quaternion rotation = transform.rotation;

        int index = Random.Range(0,stonePrefab.Length);

//        var i = 0; // var позволяет не писать тип переменной, при наведении пишет тип
        // Работать с var - стиль программирования

        GameObject.Instantiate(stonePrefab[index], position, rotation);
    }
}
