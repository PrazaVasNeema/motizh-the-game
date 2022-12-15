using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "GameSettings", fileName ="GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public int num = 10;

        [Header("Stone")]
        /* public float minDelay = 1f;
         public float maxDelay = 5f;
         public float stepDelay = 0.25f;*/
        [SerializeField] private float m_minDelay = 1f;
        public float minDelay
        {
            get
            {
                return m_minDelay;
            }
        }
        [SerializeField] private float m_maxDelay = 5f;
        public float maxDelay => m_maxDelay;
        [SerializeField] private float m_stepDelay = 0.25f;
        public float stepDelay => m_stepDelay;

        // Защитили наши данные

        // Так быстрее, красивее и тд

        // Три способа защиты

        // Плохо тем, что часто копируютсяя данные
    }

}