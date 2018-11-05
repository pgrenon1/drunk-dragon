using UnityEngine;
using System;
using System.Reflection;


/**
 * Derives basic logic from
 * https://github.com/DWilches/SerialCommUnity
 */

public class ArduinoSerialComm : MonoBehaviour
{

    #region
    public static ArduinoSerialComm instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    #endregion






    public GameObject controllerParent;
    //public SerialController serialController;

    public int currentScreen = 0;
    public bool firstChar = true;
    public string[] lcdTopTexts;
    public string[] lcdBottomTexts;
    public AudioClip sSelectorClip;
    public AudioClip[] keysClip;
    public AudioClip powerOnClip;

    void Start()
    {
        //// default to serial controller object
        //if (controllerParent == null)
        //{
        //    serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        //}
        //else
        //{
        //    serialController = controllerParent.GetComponent<SerialController>();
        //}
    }

    //internal void UpdateTotalAmount(int tractorBeamID, Source harvestedSource)
    //{
    //    string serialMsg;
    //    serialMsg = "TA " + tractorBeamID + " " + harvestedSource.amount;
    //    Debug.Log("Sending Serial Message: " + serialMsg);
    //    serialController.SendSerialMessage(serialMsg);
    //}

    //internal void UpdateCurrentAmount(int tractorBeamID, Source harvestedSource)
    //{
    //    string serialMsg;
    //    serialMsg = "CA " + tractorBeamID + " " + harvestedSource.amount;
    //    Debug.Log("Sending Serial Message: " + serialMsg);
    //    serialController.SendSerialMessage(serialMsg);
    //}

    internal void Ready()
    {
        string serialMsg;
        serialMsg = "CA ";
        Debug.Log("Sending Serial Message: " + serialMsg);
        //serialController.SendSerialMessage(serialMsg);
    }

    internal void ReadAll()
    {
        string serialMsg;
        serialMsg = "RA ";
        Debug.Log("Sending Serial Message: " + serialMsg);
        //serialController.SendSerialMessage(serialMsg);
    }

    internal void BeamOff(int tractorBeamID)
    {
        string serialMsg;
        serialMsg = "OFF " + tractorBeamID;
        Debug.Log("Sending Serial Message: " + serialMsg);
        //serialController.SendSerialMessage(serialMsg);
    }

    internal void Depleated(int tractorBeamID)
    {
        string serialMsg;
        serialMsg = "DEP " + tractorBeamID;
        Debug.Log("Sending Serial Message: " + serialMsg);
        //serialController.SendSerialMessage(serialMsg);
    }

    void Update()
    {

    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        //if (!GameManager.instance.intro)
        //{
        //    if (msg[0] == 's')
        //    {
        //        S(msg);
        //    }
        //    else if (msg[0] == 'r')
        //    {
        //        R(msg);
        //    }
        //    else if (msg[0] == 'k')
        //    {
        //        K(msg);
        //    }
        //    else if (msg[0] == 'a' || msg[0] == 'b' || msg[0] == 'c' || msg[0] == 'd')
        //    {
        //        Abcd(msg);
        //    }
        //    else if (msg[0] == 'e')
        //    {
        //        E(msg);
        //    }
        //    else if (msg[0] == 'l')
        //    {
        //        L(msg);
        //    }
        //    else
        //    {
        //        Debug.Log("Unhandled message arrived: " + msg);
        //    }
        //}
        //else
        //{
        //    if (msg[0] == 'l')
        //    {
        //        if (msg[1] == '1')
        //        {
        //            AudioManager.instance.Play(powerOnClip, false);
        //            introManager.BeginGame();
        //        }
        //    }
        //}
    }

    // Arrow Selector handler
    public void S(string data)
    {
        //Debug.Log("Arrow Selector Handler function received: " + data);

        ////if (data[1] > 3) return;

        //switch (data[1])
        //{
        //    case '0':
        //        currentScreen = 0;
        //        NoBlinkAll();
        //        if (resourceManager.tractorBeams[0].inUse)
        //            return;

        //        StartBlink(0);
        //        AudioManager.instance.Play(sSelectorClip, false);
        //        ClearRow(0, 0);
        //        break;
        //    case '1':
        //        currentScreen = 1;
        //        NoBlinkAll();
        //        if (resourceManager.tractorBeams[1].inUse)
        //            return;

        //        StartBlink(1);
        //        AudioManager.instance.Play(sSelectorClip, false);
        //        ClearRow(1, 0);
        //        break;
        //    case '2':
        //        currentScreen = 2;
        //        NoBlinkAll();
        //        if (resourceManager.tractorBeams[2].inUse)
        //            return;

        //        StartBlink(2);
        //        AudioManager.instance.Play(sSelectorClip, false);
        //        ClearRow(2, 0);
        //        break;
        //    case '3':
        //        currentScreen = 3;
        //        NoBlinkAll();
        //        if (resourceManager.tractorBeams[3].inUse)
        //            return;

        //        StartBlink(3);
        //        AudioManager.instance.Play(sSelectorClip, false);
        //        ClearRow(3, 0);
        //        break;
        //}

        //firstChar = true;
    }

    private void WriteCodeChar(int lcdIndex, char c)
    {
        string debugMsg;
        string serialMsg;

        serialMsg = "WCC " + lcdIndex.ToString() + " " + c;
        debugMsg = "Sending serial message: " + serialMsg;
        Debug.Log(debugMsg);

        //serialController.SendSerialMessage(serialMsg);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        //else
        //    Debug.Log("Connection attempt failed or disconnection detected");
    }
}
