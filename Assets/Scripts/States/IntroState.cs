using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class IntroState : MonoBehaviour
    {
        [SerializeField]
        private GameController m_gameController;
        [SerializeField]
        private GameObject m_introPanel;
        [SerializeField]
        private MainCamera m_mainCamera;
        [SerializeField]
        private Transform m_mainCameraTransform;

        private void OnEnable()
        {
            m_introPanel.SetActive(true);
        }

        private void OnDisable()
        {
            m_introPanel.SetActive(false);
        }

        public void EnterGame()
        {
            m_gameController.SetMainMenuState();
            m_mainCamera.StriveForTransform(m_mainCameraTransform);
        }
    }

}