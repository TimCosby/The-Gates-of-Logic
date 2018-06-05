using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimedTooltip : MonoBehaviour
{

    [Header("Object:")]
    public string objectTextTitle;
    [TextArea]
    public string objectTextInfo;

    public GameObject Window;
    public TextMeshProUGUI displayTextTitle;
    public TextMeshProUGUI displayTextInfo;
    public bool singleUse = false;
    private bool hasUsed = false;
    public float duration = 3;


    private void Start()
    {
        Window.SetActive(true);

        if (Window != null)
        {
            displayTextTitle.text = objectTextTitle;
            displayTextInfo.text = objectTextInfo;
        }

        hasUsed = true;
    }

    private void Update()
    {
       if (Time.time > duration)
        {
            Window.SetActive(false);
        }
    }
}
