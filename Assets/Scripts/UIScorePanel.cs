using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIScorePanel : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TextMeshProUGUI m_scoreTextNormal;
        [SerializeField]
        private TMPro.TextMeshProUGUI m_scoreTextHard;
        [SerializeField]
        private TMPro.TextMeshProUGUI m_scoreTextIngame;
        [SerializeField]
        private TMPro.TextMeshProUGUI m_scorePanelDifficultyLevel;

        public void SetScoreNormal(int score)
        {
            m_scoreTextNormal.text = score.ToString();
        }

        public void SetScoreHard(int score)
        {
            m_scoreTextHard.text = score.ToString();
        }

        public void SetScoreIngame(int score)
        {
            m_scoreTextIngame.text = score.ToString();
        }

        public void SetScorePanelDifficultyLevel(int difficultyLevel)
        {
            switch (difficultyLevel)
            {
                case 0:
                    m_scorePanelDifficultyLevel.text = "����������";
                    break;
                case 1:
                    m_scorePanelDifficultyLevel.text = "�������";
                    break;
            }
        }
    }
}
