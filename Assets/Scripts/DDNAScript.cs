using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DeltaDNA;

public class DDNAScript : MonoBehaviour
{
    public PopupImage imagePopup;
    public GameObject imagePrefab;

    private string decisionPoint;


    // Start is called before the first frame update
    void Start()
    {
        DDNA.Instance.SetLoggingLevel(DeltaDNA.Logger.Level.DEBUG);
        DDNA.Instance.ClientVersion = "1.0.0";
        DDNA.Instance.StartSDK();

        UpdateHud();
    }


    private void UpdateHud()
    {
        // Prints some handy things on the UI
        var txtUserID = GameObject.Find("txtUserID");
        txtUserID.GetComponent<Text>().text = "UserID : " + DDNA.Instance.UserID;

        var txtSdkVersion = GameObject.Find("txtSdkVersion");
        txtSdkVersion.GetComponent<Text>().text = "DDNA Sdk Version: " + Settings.SDK_VERSION;

        var txtUnityVersion = GameObject.Find("txtUnityVersion");
        txtUnityVersion.GetComponent<Text>().text = "Unity Version : " + Application.unityVersion;
    }

    public void OnButtonPress()
    {
        decisionPoint = "websiteLink";
        Instantiate(imagePrefab);

        GameObject popupPrefab = GameObject.Find("PopupImage(Clone)");
        imagePopup = popupPrefab.GetComponent<PopupImage>();

        imagePopup.EngageCall(decisionPoint);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
