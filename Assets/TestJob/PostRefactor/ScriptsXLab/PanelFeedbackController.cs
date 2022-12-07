using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using TMPro;

public class PanelFeedbackController : MonoBehaviour
{
    [SerializeField] 
    public Button X_button;
    [SerializeField]
    public Button Z_button;
    [SerializeField]
    public Button SPACE_button;

    [SerializeField] private CloudController cloudController;

    [SerializeField]
    private GameController gameController;

    [SerializeField] private float timeBeforeWhite = .3f;
    [SerializeField] private Text rockCounterOutput;
    [SerializeField] private Text raineyRaineyRain;

    ColorBlock colors;
    private float[] timeToShine;
    private bool[] timeToShineFlag;
    private int rainLook;
    private float rainTimeToChange = .7f;
    private float rainCurTime;

    private int rockCounterValue;
    private bool flag = false;


    // Start is called before the first frame update
    void Awake()
    {
        timeToShine = new float[] { .0f, .0f, .0f };
        timeToShineFlag = new bool[] { false, false, false };
        rainLook = 1;
        rainCurTime = 0f;
        rockCounterValue = 0;
        rockCounterOutput.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeToShine[0] > timeBeforeWhite && timeToShineFlag[0] == true)
        {
            timeToShineFlag[0] = false;
            setWhite(X_button);
        }
        if (Time.time - timeToShine[1] > timeBeforeWhite && timeToShineFlag[1] == true)
        {
            timeToShineFlag[1] = false;
            setWhite(Z_button);
        }
        if (Time.time - timeToShine[2] > timeBeforeWhite && timeToShineFlag[2] == true)
        {
            timeToShineFlag[2] = false;
            setWhite(SPACE_button);
        }

        if (cloudController.m_current != null)
        {
            if (Time.time - rainCurTime >= rainTimeToChange / 2)
            {
                ChangeCloudTravellinLook();
                rainCurTime = Time.time;
            }
        }
        else
        {
            if (rainCurTime != 0f)
            {
                if (rainLook >= 3)
                {
                    rainLook = 1;
                }
                if (Time.time - rainCurTime >= rainTimeToChange)
                {
                    ChangeRainLook();
                    rainCurTime = Time.time;
                }
            }
        }
    }
    public void SimulateButtonPressed(Button button, int index)
    {
        colors = button.colors;
        colors.normalColor = Color.red;
        button.colors = colors;
        timeToShine[index] = Time.time;
        timeToShineFlag[index] = true;
    }

    public void changeRockCount()
    {
        rockCounterOutput.text = (++rockCounterValue).ToString();
    }

    private void setWhite(Button button)
    {
        colors.normalColor = Color.white;
        button.colors = colors;
    }

    private void ChangeRainLook()
    {
        switch (rainLook)
        {
            case 1:
                raineyRaineyRain.text = "ヽ、｀ヽ、｀ヽ｀ヽ、、｀ヽ｀ヽ、｀ヽ、｀｀ヽ、";
                rainLook = 2;
                break;
            case 2:
                raineyRaineyRain.text = "、ヽ｀｀、ヽ｀、ヽ｀ヽ｀、、ヽ｀ヽ｀、ヽ｀、ヽ";
                rainLook = 1;
                break;
        }
    }
    private void ChangeCloudTravellinLook()
    {
        switch (rainLook)
        {
            case 1:
                raineyRaineyRain.text = "→━━━━";
                rainLook = 2;
                break;
            case 2:
                raineyRaineyRain.text = "━→━━━";
                rainLook = 3;
                break;
            case 3:
                raineyRaineyRain.text = "━━→━━";
                rainLook = 4;
                break;
            case 4:
                raineyRaineyRain.text = "━━━→━";
                rainLook = 5;
                break;
            case 5:
                raineyRaineyRain.text = "━━━━→";
                rainLook = 1;
                break;
        }
    }
}
