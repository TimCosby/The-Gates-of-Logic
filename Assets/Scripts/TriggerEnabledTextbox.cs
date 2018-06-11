using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerEnabledTextbox : MonoBehaviour
{

    [Header("Object:")]
    public string objectTextTitle;
    [TextArea]
    public string objectTextInfo;

    public GameObject Window;
    public TextMeshProUGUI displayTextTitle;
    public TextMeshProUGUI displayTextInfo;
    private bool hasUsed = false;
    public Trigger Trigger;

    private void Start()
    {
        Window.SetActive(false);
        if (Trigger == null)
        {
            Trigger = GetComponent<Trigger>();
        }
    }

    private void Update()
    {
        if (Trigger.Triggered)
        {
            Debug.Log("Triggered");
            if (!Trigger.SingleUse || (Trigger.SingleUse && !hasUsed))
            {
                if (Window != null)
                {
                    Debug.Log("Activate");
                    displayTextTitle.text = objectTextTitle;
                    displayTextInfo.text = objectTextInfo;
                    Window.SetActive(true);
                    hasUsed = true;
                }
            }
        }
        else
        {
            Window.SetActive(false);
        }
    }
}
