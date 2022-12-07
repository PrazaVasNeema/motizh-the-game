using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Он будет разделять логику
public class GameController : MonoBehaviour
{
    [SerializeField]
    private StoneSpawner m_spawner;

    [SerializeField]
    private CloudController m_cloudController;

    [SerializeField]
    private ItemsController m_itemsController;

    [SerializeField]
    private ToolsChange m_toolsChange; //!

    [SerializeField]
    private PanelFeedbackController m_panelFeedbackController;
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.X)) // Инпут - статический класс
        {

            Debug.Log("X was pressed");
            m_panelFeedbackController.SimulateButtonPressed(m_panelFeedbackController.X_button, 0);
            CallSpawnStoneFunc();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z was pressed");
            m_panelFeedbackController.SimulateButtonPressed(m_panelFeedbackController.Z_button, 1);
            CallMoveCloudFunc();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
            m_panelFeedbackController.SimulateButtonPressed(m_panelFeedbackController.SPACE_button, 2);
            CallSwapItemsFunc();
        }
    }

    public void CallSpawnStoneFunc()
    {
        if (m_spawner != null) // Лучше всегда проверять
        {
            m_panelFeedbackController.changeRockCount();
            m_spawner.Spawn();
        }
        else
        {
            Debug.LogError("Спавнер равен нулю"); // Приложение уже не упадет
        }
    }
    public void CallMoveCloudFunc()
    {
        if (m_cloudController != null) // Лучше всегда проверять
        {
            m_cloudController.Action();
        }
        else
        {
            Debug.LogError("Контроллер облака равен нулю"); // Приложение уже не упадет
        }
    }
    public void CallSwapItemsFunc()
    {

        if (m_itemsController != null) // Лучше всегда проверять
        {
//            m_itemsController.SwapItemsFunc();
            m_toolsChange.Action();
        }
        else
        {
            Debug.LogError("Контроллер облака равен нулю"); // Приложение уже не упадет
        }
    }
}
