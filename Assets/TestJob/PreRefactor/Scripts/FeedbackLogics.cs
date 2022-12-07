using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using TMPro;

public class FeedbackLogics : MonoBehaviour
{
    [SerializeField] private Button X_button;
    [SerializeField] private Button Z_button;
    [SerializeField] private Button SPACE_button;

    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject camera;

    [SerializeField] private float timeBeforeWhite = .3f;
    [SerializeField] private Text counterOutput;
    [SerializeField] private Text raineyRaineyRain;

    ColorBlock colors;
    private float[] timeToShine;
    private bool[] timeToShineFlag;
    private int rainLook;
    private float rainTimeToChange = .7f;
    private float rainCurTime;
    private bool lastFlag;


    // Start is called before the first frame update
    void Start()
    {
        timeToShine = new float[] { .0f, .0f, .0f };
        timeToShineFlag = new bool[] { false, false, false };
        rainLook = 1;
        rainCurTime = Time.time;
        lastFlag = cloud.GetComponent<CloudLogics>().GetMovingStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SpawnStone"))
        {
            SimulateButtonPressed(X_button, 0);
        }
        if (Input.GetButtonDown("MoveCloud"))
        {
            SimulateButtonPressed(Z_button, 1);
        }
        if (Input.GetButtonDown("SwapItems"))
        {
            SimulateButtonPressed(SPACE_button, 2);
        }
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
        counterOutput.text = stone.GetComponent<SpawnStone>().GetStoneCounterValue().ToString();

        if (cloud.GetComponent<CloudLogics>().GetMovingStatus() != true)
        {
            if (rainLook >= 3)
                rainLook = 1;
            if(lastFlag == true)
            {
                raineyRaineyRain.text = "、ヽ｀｀、ヽ｀、ヽ｀ヽ｀、、ヽ｀ヽ｀、ヽ｀、ヽ";
                lastFlag = false;
            }
            if (Time.time - rainCurTime >= rainTimeToChange)
            {
                ChangeRainLook();
                rainCurTime = Time.time;
            }
        }
        else
        {
            if (lastFlag == false)
                lastFlag = true;
            if (Time.time - rainCurTime >= rainTimeToChange / 2)
            {
                ChangeCloudTravellinLook();
                rainCurTime = Time.time;
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
    private void setWhite(Button button)
    {
        colors.normalColor = Color.white;
        button.colors = colors;
    }
    public void CallSpawnStoneFunc()
    {
        stone.GetComponent<SpawnStone>().SpawnStoneFunc();
    }
    public void CallMoveCloudFunc()
    {
        cloud.GetComponent<CloudLogics>().MoveCloudFunc();
    }
    public void CallSwapItemsFunc()
    {
        camera.GetComponent<SwapItems>().SwapItemsFunc();
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
